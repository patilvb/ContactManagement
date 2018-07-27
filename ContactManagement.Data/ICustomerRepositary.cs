using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Data
{
    public interface ICustomerRepositary
    {
        List<Customer> GetAll();

        Customer Create(Customer customer);

        void Update(Customer customer);

        void Delete(int customerId);
    }
}
