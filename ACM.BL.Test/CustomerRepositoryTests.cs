using ACM.BL;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _customerRepo;
        private CustomerTypeRepository _customerTypeRepo;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _customerRepo = new CustomerRepository();
            _customerTypeRepo = new CustomerTypeRepository();
        }


        [TestMethod()]
        public void FindTest()
        {
            var list = _customerRepo.Retrieve();

            var result = _customerRepo.Find(list, 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTestWichNotExists()
        {
            var list = _customerRepo.Retrieve();

            var result = _customerRepo.Find(list, 42);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void SortByNameTest()
        {
            var list = _customerRepo.Retrieve();

            var result = _customerRepo.SortByName(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerId);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod()]
        public void SortByNameInReverseTest()
        {
            var list = _customerRepo.Retrieve();
            var result = _customerRepo.SortByNameInReverse(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Last().CustomerId);
            Assert.AreEqual("Baggins", result.Last().LastName);
            Assert.AreEqual("Bilbo", result.Last().FirstName);
        }

        [TestMethod()]
        public void SortByTypeTest()
        {
            var list = _customerRepo.Retrieve();
            var result = _customerRepo.SortByType(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Last().CustomerTypeId);

        }

        [TestMethod()]
        public void GetNamesTest()
        {
            var customerList = _customerRepo.Retrieve();

            var query = _customerRepo.GetNames(customerList);

            foreach (var item in query)
            {
                TestContext.WriteLine(item);
            }

            Assert.IsNotNull(query);
        }

        [TestMethod()]
        public void GetNamesAndEmailsTest()
        {

            var customerList = _customerRepo.Retrieve();

            var query = _customerRepo.GetNamesAndEmails(customerList);
        }

        [TestMethod()]
        public void GetNamesAndTypeTest()
        {
            var customerList = _customerRepo.Retrieve();
            var customerTypeList = _customerTypeRepo.Retrieve();

            var query = _customerRepo.GetNamesAndTypeName(customerList, customerTypeList);
        }

        [TestMethod()]
        public void GetOverdueCustomersTest()
        {
            var customerList = _customerRepo.Retrieve();

            var query = _customerRepo.GetOverdueCustomers(customerList);

            foreach (var item in query)
            {
                TestContext.WriteLine(item.LastName + " " + item.FirstName);
            }

            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetInvoiceTotalByCustomerType()
        {
            var customerList = _customerRepo.Retrieve();
            var customerTypeList = _customerTypeRepo.Retrieve();

            var query = _customerRepo.GetInvoiceTotalByCustomerType(customerList, customerTypeList);
        }
    }
}