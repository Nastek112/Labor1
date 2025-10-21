using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApp;

namespace MobileApp.Tests
{
    [TestClass]
    public class MobileDevTests
    {
        [TestMethod]
        public void Defaults_ShouldBe_Firm_5_0_5000()
        {
            var d = new mobile_dev();
            Assert.AreEqual("firm", d.Firm);
            Assert.AreEqual(5.0, d.Size, 1e-9);
            Assert.AreEqual(5000, d.BatCapacity);
        }

        [TestMethod]
        public void Ctor_ValidValues_ShouldPersist()
        {
            var d = new mobile_dev("Samsung", 4000, 6.1);
            Assert.AreEqual("Samsung", d.Firm);
            Assert.AreEqual(6.1, d.Size, 1e-9);
            Assert.AreEqual(4000, d.BatCapacity);
        }

        [TestMethod]
        public void Properties_OutOfRange_ShouldClampToDefaults()
        {
            var d = new mobile_dev("", 20000, 100.0);
            Assert.AreEqual("firm", d.Firm);
            Assert.AreEqual(5.0, d.Size, 1e-9);
            Assert.AreEqual(5000, d.BatCapacity);
        }

        [TestMethod]
        public void Smart_RAM_OutOfRange_ShouldBecomeDefault6()
        {
            var s = new Smart(0, "Xiaomi", 5000, 6.5);
            Assert.AreEqual(6, s.RAM);
        }

        [TestMethod]
        public void Ebook_Backlight_ShouldPersist()
        {
            var e = new Ebook(true, "PocketBook", 1200, 6.0);
            Assert.IsTrue(e.Backlight);
        }
    }

}
