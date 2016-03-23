using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);


            Assert.AreEqual(true, mock.Object.DoSomething("ping"));


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



}
