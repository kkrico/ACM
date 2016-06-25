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
    public class StringExtensionTests
    {
        [TestMethod()]
        public void ToTitleCaseTest()
        {
            var source = "the return of the king";
            var expected = "The Return Of The King";

            var result = source.ToTitleCase();

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }
    }
}