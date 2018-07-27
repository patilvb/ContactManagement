using ContactManagement.Services.Contracts;
using System.Collections.Generic;

namespace ContactManagement.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        Customer Create(Customer customer);

        void Update(Customer customer);

        void Delete(int customerId);
         
    }
}
