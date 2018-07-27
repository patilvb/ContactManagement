using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Data
{
    public class CustomerRepositary : ICustomerRepositary
    {
        Customer ICustomerRepositary.Create(Customer customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return customer;
        }

        void ICustomerRepositary.Delete(int customerId)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == customerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }

        List<Customer> ICustomerRepositary.GetAll()
        {
            CustomersEntities entities = new CustomersEntities();
            List<Customer> customers = entities.Customers.ToList();
            return customers;           
        }

        void ICustomerRepositary.Update(Customer customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.Email = customer.Email;
                updatedCustomer.PhoneNumber = customer.PhoneNumber;
                updatedCustomer.Status = customer.Status.Value;
                entities.SaveChanges();
            }
        }
    }
}
