using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serverless_Pattern.Helpers;

namespace UnitTestServerless.Test
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestConexionDB()
        {
            Conexion conn = new Conexion();
            Assert.AreEqual(conn.state(),true);
        }
    }
}
