using Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemo.Tests
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void TestDemo()
        {
            Program obj = new Program();
            Assert.AreEqual("Welcome to C# Programming...", obj.Hello());
        }


    }
}
