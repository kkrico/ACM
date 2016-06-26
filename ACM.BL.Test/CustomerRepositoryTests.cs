using ACM.BL;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repo;
        public TestContext TestContext { get; set; }

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

        [TestMethod()]
        public void SortByNameTest()
        {
            var list = _repo.Retrieve();

            var result = _repo.SortByName(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerId);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod()]
        public void SortByNameInReverseTest()
        {
            var list = _repo.Retrieve();
            var result = _repo.SortByNameInReverse(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Last().CustomerId);
            Assert.AreEqual("Baggins", result.Last().LastName);
            Assert.AreEqual("Bilbo", result.Last().FirstName);
        }

        [TestMethod()]
        public void SortByTypeTest()
        {
            var list = _repo.Retrieve();
            var result = _repo.SortByType(list);

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Last().CustomerTypeId);

        }

        [TestMethod()]
        public void GetNamesTest()
        {
            var customerList = _repo.Retrieve();

            var query = _repo.GetNames(customerList);

            foreach (var item in query)
            {
                TestContext.WriteLine(item);
            }

            Assert.IsNotNull(query);
        }
    }
}