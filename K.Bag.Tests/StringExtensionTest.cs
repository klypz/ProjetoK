using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Bag.Tests
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        [TestCategory("String Extension")]
        public void TestCamelCase()
        {
            string message = " this COde is à HightCode #hash";
            var camelCaseDefault = message.ToCamelCase();
            var camelCaseCode = message.ToCamelCase(true);

            var upperCamelCaseDefault = message.ToUpperCamelCase();
            var upperCamelCaseCode = message.ToUpperCamelCase(true);

            var lowerCamelCaseDefault = message.ToLowerCamelCase();
            var lowerCamelCaseCode = message.ToLowerCamelCase(true);

            Assert.AreEqual(" This Code Is À Hightcode #Hash", camelCaseDefault);
            Assert.AreEqual(" This Code Is À Hightcode #Hash", upperCamelCaseDefault);

            Assert.AreEqual("ThisCodeIsAHightcodeHash", camelCaseCode);
            Assert.AreEqual("ThisCodeIsAHightcodeHash", upperCamelCaseCode);

            Assert.AreEqual(" this Code Is À Hightcode #Hash", lowerCamelCaseDefault);
            Assert.AreEqual("thisCodeIsAHightcodeHash", lowerCamelCaseCode);
        }

        [TestMethod]
        [TestCategory("String Extension")]
        public void TestAlias()
        {
            string message = " this COde is_á Alias #test01 02";
            string result = message.ToAlias();
            Assert.AreEqual("this-code-is_a-alias-test01-02", result);
        }

        [TestMethod]
        [TestCategory("String Extension")]
        public void TestNoSpecialCharacters()
        {
            string message = " this COde is_á Alias #test01 02";
            string result = message.NoSpecialCharacters();
            Assert.AreEqual(" this COde isa Alias test01 02", result);
        }

        [TestMethod]
        [TestCategory("String Extension")]
        public void TestNoAccents()
        {
            string message = " this COde is_á Alias #test01 02";
            string result = message.NoAccents();
            Assert.AreEqual(" this COde is_a Alias #test01 02", result);
        }

        [TestMethod]
        [TestCategory("String Extension")]
        public void TestCode()
        {
            string message = " this COde is_á Alias #test01 02";
            string result = message.ToCode();
            Assert.AreEqual("thisCOdeis_aAliastest0102", result);
        }


        [TestMethod]
        [TestCategory("String Extension")]
        public void TestReverse()
        {
            string message = " this COde is_á Alias #test01 02";
            string result = message.ToReverse();
            Assert.AreEqual("20 10tset# sailA á_si edOC siht ", result);
        }
    }
}
