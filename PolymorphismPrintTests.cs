using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApp;
using System;
using System.IO;
using System.Text;
using System.Globalization;

namespace MobileApp.Tests
{
    [TestClass]
    public class PolymorphismPrintTests
    {
        [TestMethod]
        public void Print_ShouldIncludeTypeSpecificFields()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var list = new mobile_dev[]
            {
                new mobile_dev("Nokia", 3000, 5.0),
                new Smart(8, "Realme", 6000, 6.4),
                new Ebook(true, "PB", 1200, 6.0)
            };

            var sw = new StringWriter(CultureInfo.InvariantCulture);
            var oldOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                foreach (var d in list)
                {
                    d.print();
                    Console.WriteLine();
                }
            }
            finally
            {
                Console.SetOut(oldOut);
            }

            var output = sw.ToString();

            StringAssert.Contains(output, "Фирма: Nokia");
            StringAssert.Contains(output, "Размер экрана: 5.0\"");
            StringAssert.Contains(output, "Оперативная память: 8 ГБ");
            StringAssert.Contains(output, "Подсветка экрана: Есть");
        }
    }
}
