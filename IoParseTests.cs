using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApp;
using System.Globalization;

namespace MobileApp.Tests
{
    [TestClass]
    public class IoParseTests
    {
        [TestMethod]
        public void ParseInt_ShouldAccept_SignsAndDigits()
        {
            Assert.IsTrue(io.parse_int("  -123abc", out int v1) && v1 == -123);
            Assert.IsTrue(io.parse_int("+42", out int v2) && v2 == 42);
            Assert.IsTrue(io.parse_int("--5", out int v3) && v3 == -5);
        }

        [TestMethod]
        public void ParseDouble_ShouldAccept_DotAndComma()
        {
            Assert.IsTrue(io.parse_double("6.1", out double a) && a == 6.1);
            Assert.IsTrue(io.parse_double("  6,55  ", out double b) && b.ToString(CultureInfo.InvariantCulture) == "6.55");
            Assert.IsTrue(io.parse_double("+2,0", out double c) && c == 2.0);
            Assert.IsFalse(io.parse_double(".", out _));
            

        }
    }
}
