using PrimeTabler.PrimeTablerConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeTabler.PrimeTablerTest
{
    [TestClass]
    public class PrimeConsoleHelperTest
    {
        PrimeConsoleHelper consoleHelper;

        [TestInitialize()]
        public void Initialize()
        {
            consoleHelper = new PrimeConsoleHelper();
        }

        [TestMethod]
        public void NegativeInput_ShouldReturnNegativeOne()
        {
            Assert.AreEqual(-1, consoleHelper.ValidateInput("-1"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("-89"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("-2,147,483,647"));

        }

        [TestMethod]
        public void ZeroOrWhitespaceInput_ShouldReturnNegativeOne()
        {
            Assert.AreEqual(-1, consoleHelper.ValidateInput(" "));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("0"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("                    "));
        }

        [TestMethod]
        public void TextOrChracterInput_ShouldReturnNegativeOne()
        {
            Assert.AreEqual(-1, consoleHelper.ValidateInput("a"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("bananas"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("!£$%*'@"));
        }

        [TestMethod]
        public void LargeNumberInput_ShouldReturnNegativeOne()
        {
            Assert.AreEqual(-1, consoleHelper.ValidateInput("2147483648"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("99999999999999"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("12345E32"));
        }

        [TestMethod]
        public void DecimalNumberInput_ShouldReturnNegativeOne()
        {
            Assert.AreEqual(-1, consoleHelper.ValidateInput("1.908798266"));
            Assert.AreEqual(-1, consoleHelper.ValidateInput("12345.678E-02"));
        }

        [TestMethod]
        public void IntNumberInput_ShouldReturnCorrectInt()
        {
            Assert.AreEqual(1, consoleHelper.ValidateInput("1"));
            Assert.AreEqual(56, consoleHelper.ValidateInput("           56           "));
            Assert.AreEqual(2147483647, consoleHelper.ValidateInput("2147483647"));
        }
    }
}
