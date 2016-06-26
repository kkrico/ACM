using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
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