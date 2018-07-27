using ContactManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositary _customerRepositary;

        public CustomerService(ICustomerRepositary customerRepositary)
        {
            this._customerRepositary = customerRepositary;         
        }

        Contracts.Customer ICustomerService.Create(Contracts.Customer customer)
        {
            Data.Customer customerEntity = MapCustomer(customer);
            var customerResult = _customerRepositary.Create(customerEntity);
            customer.CustomerId = customerResult.CustomerId;
            return customer;
        }

        void ICustomerService.Delete(int customerId)
        {
            _customerRepositary.Delete(customerId);
        }

        List<Contracts.Customer> ICustomerService.GetAll()
        {
            var customers = _customerRepositary.GetAll();

            return (from c in customers
                    select new Contracts.Customer
                    {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Status = c.Status.Value
                    }).ToList();
        }

        void ICustomerService.Update(Contracts.Customer customer)
        {
            Data.Customer customerEntity = MapCustomer(customer);
            _customerRepositary.Update(customerEntity);
        }

        private Data.Customer MapCustomer(Contracts.Customer customer)
        {
            Data.Customer customerEntity = new Data.Customer()
            {
                CustomerId = customer.CustomerId,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Status = customer.Status
            };
            return customerEntity;
        }
    }
}
