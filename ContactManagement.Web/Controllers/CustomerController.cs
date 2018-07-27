using ContactManagement.Services;
using ContactManagement.Services.Contracts;
using ContactManagement.Web.Models;
using System.Web.Http;

namespace ContactManagement.Web.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [Route("api/Customer")]
        [HttpPost]
        public CustomerModel InsertCustomer(CustomerModel customer)
        {
            Customer customerComtract = MapCustomer(customer);
            var customerContractResult = _customerService.Create(customerComtract);
            customer.CustomerId = customerContractResult.CustomerId;
            return customer;
        }

        [Route("api/Customer/Update")]
        [HttpPost]
        public bool UpdateCustomer(CustomerModel customer)
        {
            Customer customerComtract = MapCustomer(customer);
            _customerService.Update(customerComtract);
            return true;
        }

        [Route("api/Customer/Delete")]
        [HttpPost]
        public void DeleteCustomer(CustomerModel customer)
        {
            _customerService.Delete(customer.CustomerId);
        }

        private Customer MapCustomer(CustomerModel customer)
        {
            Customer customerComtract = new Customer()
            {
                CustomerId = customer.CustomerId,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Status = customer.Status
            };
            return customerComtract;
        }
    }
}
