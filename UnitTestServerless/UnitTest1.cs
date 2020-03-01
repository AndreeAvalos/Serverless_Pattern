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
            conn.close();
        }

        [TestMethod()]
        public void TestRegistroUsuario() {
            Conexion conn = new Conexion();
            if (conn.state() == true) {

                Registro_function registo = new Registro_function(conn);

                Assert.IsFalse(registo.valido("", "", "", "", "", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "", "", "", "", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "", "", "", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "", "", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "guatemala", "", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "guatemala", "mixco", "", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "guatemala", "mixco", "11122", "", ""));
                Assert.IsFalse(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "guatemala", "mixco", "11122", "1/2/2020", ""));
                Assert.IsTrue(registo.valido("andreeavalos", "andree", "avalos", "1/2/2020", "guatemala", "mixco", "11122", "1/2/2020", "1/2/2020"));

                Assert.AreEqual(registo.insertar_registro("andreeavalos", "aavalosoto@gmail.com","carlos",
                    "andree", "avalos", "soto","35385252", "1/2/2020", "guatemala", "mixco", "11122", "1/2/2020", "1/2/2020"), "Registro Exitoso");

                return;
            }
            Assert.Fail();
        }
    }
}
