$(function () {

    if ($("#hdnTotalCount").val() === "0") {
        var row = $("#tblCustomers tr:last-child");
        row.find(".Edit").hide();
        row.find(".Delete").hide();
        row.find("span").html('&nbsp');
        row.find("input").hide();
    }
});

function AppendRow(row, customerId, firstName, lastName, email, phoneNumber, status) {
    //Bind CustomerId.
    $(".CustomerId", row).find("span").html(customerId);

    //Bind FIsrt Name.
    $(".FirstName", row).find("span").html(firstName);
    $(".FirstName", row).find("input").val(firstName);

    //Bind Last Name.
    $(".LastName", row).find("span").html(lastName);
    $(".LastName", row).find("input").val(lastName);

    //Bind Email.
    $(".Email", row).find("span").html(email);
    $(".Email", row).find("input").val(email);

    //Bind Phone Number.
    $(".PhoneNumber", row).find("span").html(phoneNumber);
    $(".PhoneNumber", row).find("input").val(phoneNumber);

    $(".Status", row).find("span").html(status ? "Active" : "Inactive");
    $(".Status", row).find("input").prop('checked', status);

    row.find(".Edit").show();
    row.find(".Delete").show();

    $("#tblCustomers").append(row);
}

//Add event handler.
$("body").on("click", "#btnAdd", function () {
    var isvalid = $("#customerForm").valid();
    if (isvalid) {
        var txtFirstName = $("#txtFirstName");
        var txtLastName = $("#txtLastName");
        var txtEmail = $("#txtEmail");
        var txtPhoneNumber = $("#txtPhoneNumber");
        var cbStatus = $('#cbStatus');

        var _customer = {};
        _customer.FirstName = txtFirstName.val();
        _customer.LastName = txtLastName.val();
        _customer.Email = txtEmail.val();
        _customer.PhoneNumber = txtPhoneNumber.val();
        var status = false;
        if (cbStatus.attr('checked')) {
            status = true;
        }
        _customer.Status = status;

        $.ajax({
            type: "POST",
            url: "/api/Customer",
            data: JSON.stringify(_customer),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var row = $("#tblCustomers tr:last-child");
                if ($("#tblCustomers tr:last-child span").eq(0).html() !== "&nbsp;") {
                    row = row.clone();
                }
                AppendRow(row, r.CustomerId, r.FirstName, r.LastName, r.Email, r.PhoneNumber, r.Status);
                txtFirstName.val("");
                txtLastName.val("");
                txtEmail.val("");
                txtPhoneNumber.val("");
                cbStatus.prop('checked', false);
            }
        });
    }
});

//Edit event handler.
$("body").on("click", "#tblCustomers .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

//Update event handler.
$("body").on("click", "#tblCustomers .Update", function () {
    var isvalid = $("#customerUpdateForm").valid();
    if (isvalid) {
        var row = $(this).closest("tr");
        $("td", row).each(function () {
            if ($(this).find("input").length > 0) {
                var span = $(this).find("span");
                var input = $(this).find("input");
                if (input.prop("id") === "Status") {
                    span.html("Inactive");
                    if (input.attr('checked'))
                        span.html("Active");
                }
                else {
                    span.html(input.val());
                }
                span.show();
                input.hide();
            }
        });
        row.find(".Edit").show();
        row.find(".Delete").show();
        row.find(".Cancel").hide();
        $(this).hide();
        var _customer = {};
        _customer.CustomerId = row.find(".CustomerId").find("span").html();
        _customer.FirstName = row.find(".FirstName").find("span").html();
        _customer.LastName = row.find(".LastName").find("span").html();
        _customer.Email = row.find(".Email").find("span").html();
        _customer.PhoneNumber = row.find(".PhoneNumber").find("span").html();
        _customer.Status = row.find(".Status").find("span").html() === "Active" ? true : false;
        $.ajax({
            type: "POST",
            url: "/api/Customer/Update",
            data: JSON.stringify(_customer),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });
    }
});

//Cancel event handler.
$("body").on("click", "#tblCustomers .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//Delete event handler.
$("body").on("click", "#tblCustomers .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var _customer = {};
        _customer.CustomerId = row.find("span").html();
        $.ajax({
            type: "POST",
            url: "/api/Customer/Delete",
            data: JSON.stringify(_customer),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if ($("#tblCustomers tr").length > 2) {
                    row.remove();
                } else {
                    row.find(".Edit").hide();
                    row.find(".Delete").hide();
                    row.find("span").html('&nbsp;');
                }
            }
        });
    }
});