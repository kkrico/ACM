using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Test
{
    [TestClass()]
    public class InvoiceRepositoryTests
    {
        private InvoiceRepository _invoiceRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _invoiceRepo = new InvoiceRepository();
        }

        [TestMethod()]
        public void CalculateTotalAmountInvoicedTest()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.CalculateTotalAmountInvoiced(invoiceList);
            Assert.AreEqual(1333.14M, actual);
        }

        [TestMethod()]
        public void CalculateTotalUnitSoldTest()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.CalculateTotalUnitSold(invoiceList);
            Assert.AreEqual(136, actual);
        }

        [TestMethod()]
        public void GetInvoiceTotalByIsPaidTest()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.GetInvoiceTotalByIsPaid(invoiceList);
        }

        [TestMethod()]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.GetInvoiceTotalByIsPaidAndMonth(invoiceList);
        }

        [TestMethod]
        public void CalculateMeanTest()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.CalculateMean(invoiceList);
        }


        [TestMethod]
        public void CalculateMedian()
        {
            var invoiceList = _invoiceRepo.Retrieve();
            var actual = _invoiceRepo.CalculateMedian(invoiceList);

            Assert.AreEqual(10M, actual);
        }

        [TestMethod]
        public void CalculateMode()
        {
            var invoiceList = _invoiceRepo.Retrieve();

            var actual = _invoiceRepo.CalculateMode(invoiceList);

            Assert.IsNotNull(actual);
            Assert.AreEqual(10M, actual);
        }
    }
}