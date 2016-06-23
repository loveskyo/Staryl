using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject1
{

    [DeploymentItem(@"add.xml")]
    [TestClass]
    public class UnitTest1
    {
        List<testdata> list = new List<testdata>();

        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //string id = Convert.ToString(TestContext.DataRow["id"]);
            // string name = Convert.ToString(TestContext.DataRow["name"]);
            //string type = Convert.ToString(TestContext.DataRow["type"]);


            //list.Add(new testdata { id = int.Parse(id), name = name, type = type });



        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\add.xml", "row", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

            string id = Convert.ToString(TestContext.DataRow["id"]);
            string name = Convert.ToString(TestContext.DataRow["name"]);
            string type = Convert.ToString(TestContext.DataRow["type"]);

            Assert.AreEqual(true, mock.Object.DoSomething("ping"));


            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            Assert.AreEqual(true, mock.Object.DoSomething("ping"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var mock = new Mock<IFoo>();
            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            Assert.AreEqual(true, mock.Object.DoSomething("ping"));
        }
    }

    public interface IFoo
    {
        bool DoSomething(string s);
        bool TryParse(string s, out string v);
    }

    public class testdata
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }


}
