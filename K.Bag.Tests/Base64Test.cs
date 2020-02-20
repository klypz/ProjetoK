using Microsoft.VisualStudio.TestTools.UnitTesting;
using K.Bag;

namespace K.Bag.Tests
{
    [TestClass]
    public class Base64Test
    {
        [TestMethod]
        public void StringToBase64()
        {
            var st = "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ";
            var a = st.FromBase64UrlString();
            Assert.AreEqual(a, "{\"sub\":\"1234567890\",\"name\":\"John Doe\",\"iat\":1516239022}", "");
        }
    }
}
