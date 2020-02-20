
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Bag.Cryptography.Tests
{
	[TestClass]
	public class EncryptTests
	{
		[TestMethod]
		public void SymmetricEncriptTest()
		{
			string plainText = "texto";
			string key = "Este texto é muito bom";

			var test = plainText.ToSymmetricEncrypt(key);
			var test2 = test.ToSymmetricDecrypt(key);

			Assert.AreEqual(plainText, test2);
		}
	}
}
