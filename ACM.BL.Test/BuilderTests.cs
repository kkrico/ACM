using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass()]
    public class BuilderTests
    {
        public TestContext TestContext { get; set; }

        private Builder _builder;

        [TestInitialize]
        public void TestInitialize()
        {
            _builder = new Builder();
        }


        [TestMethod()]
        public void BuildIntegerSequenceTest()
        {

            var result = _builder.BuildIntegerSequence();

            foreach (var integer in result)
            {
                TestContext.WriteLine(integer.ToString());
            }

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void BuildStringSequenceTest()
        {
            var result = _builder.BuildStringSequence();

            foreach (var resultString in result)
            {
                TestContext.WriteLine(resultString);
            }

            Assert.IsNotNull(result);
        }
    }
}