using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MockExample
{
    [TestFixture]
    internal class DetailsTest
    {
        [Test]
        public void TestShowStudent()
        {
            Mock<IDetails> mock = new Mock<IDetails>();
            mock.Setup(d => d.ShowStudent()).Returns("Hi i am Madhu..");
            Assert.AreEqual("Hi i am Madhu..", mock.Object.ShowStudent());
        }

        [Test]
        public void TestShowCompany()
        {
            Mock<IDetails> obj = new Mock<IDetails>();
            obj.Setup(d => d.ShowCompany()).Returns("Its from wipro Bangalore..");
            Assert.AreEqual("Its from wipro Bangalore..", obj.Object.ShowCompany());
        }
    }
}
