using ContactManagement.Services;
using ContactManagement.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace ContactManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;    
        
        public HomeController(ICustomerService customerService)
        {
            this._customerService = customerService;          
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAll();

             var customersModel= (from c in customers
                                  select new CustomerModel
                                  {
                                      CustomerId = c.CustomerId,
                                      FirstName = c.FirstName,
                                      LastName = c.LastName,
                                      Email = c.Email,
                                      PhoneNumber = c.PhoneNumber,
                                      Status = c.Status
                                  }).ToList();

            ViewBag.Count = customersModel.Count;
            if (customersModel.Count == 0)
            {
                customersModel.Add(new CustomerModel());
            }

          

            return View(customersModel);
        }
    }
}