using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace K.Bag.Tests
{
    [TestClass]
    public class EnumExtensionTest
    {
        enum EnumTest
        {
            [EnumDescription("Esta é uma descrição para o item.1", "pt-BR")]
            [EnumDescription("Esta é uma descrição para o item.1")]
            [EnumDescription("This is description for item.1", "en-US")]
            Teste1 = 0
        };

        [TestMethod]
        [TestCategory("Enum Extension")]
        public void TestGetDescriptionCurrent()
        {
            string descCurrent = EnumTest.Teste1.GetDescription();

            Assert.IsTrue(!string.IsNullOrEmpty(descCurrent));
        }

        [TestMethod]
        [TestCategory("Enum Extension")]
        public void TestGetDescriptionPTBR()
        {
            string descPTBR = EnumTest.Teste1.GetDescription(new CultureInfo("pt-BR"));
            Assert.AreEqual("Esta é uma descrição para o item.1", descPTBR);
        }

        [TestMethod]
        [TestCategory("Enum Extension")]
        public void TestGetDescriptionENUS()
        {
            string descENUS = EnumTest.Teste1.GetDescription(new CultureInfo("en-US"));
            Assert.AreEqual("This is description for item.1", descENUS);
        }

        [TestMethod]
        [TestCategory("Enum Extension")]
        public void TestGetDescriptionENGB()
        {
            string descENGB = EnumTest.Teste1.GetDescription(new CultureInfo("en-GB"));
            string descENGBHard = EnumTest.Teste1.GetDescription(new CultureInfo("en-GB"), true);

            Assert.AreEqual("This is description for item.1", descENGB);
            Assert.AreEqual(null, descENGBHard);
        }
    }
}
