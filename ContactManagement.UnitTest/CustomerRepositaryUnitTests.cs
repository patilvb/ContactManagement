using System;
using ContactManagement.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagement.UnitTest
{
    [TestClass]
    public class CustomerRepositaryUnitTests
    {
        [TestMethod]
        public void SaveShouldReturnSavedId()
        {

            ICustomerRepositary customerRepository = new CustomerRepositary();
            Data.Customer customer = new Data.Customer()
            {
                CustomerId = 0,
                FirstName = "test name",
                LastName="last name",
                Email = "testemail@email.com",
                PhoneNumber = "123456",
                Status =true
            };
            int id = customerRepository.Create(customer).CustomerId;
            Assert.AreNotEqual(0, id);
        }
    }
}
