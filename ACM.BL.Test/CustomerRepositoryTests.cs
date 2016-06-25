using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new CustomerRepository();
        }


        [TestMethod()]
        public void FindTest()
        {
            var list = _repo.Retrieve();

            var result = _repo.Find(list, 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTestWichNotExists()
        {
            var list = _repo.Retrieve();

            var result = _repo.Find(list, 42);

            Assert.IsNull(result);
        }
    }
}