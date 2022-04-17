using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChane.Tests
{
    [TestClass()]
    public class ChaineTests
    {
        [TestMethod()]
        public void CheckTest()
        {
            var chain = new Chaine();
            chain.Add(";lkjsdfskjdf", "Admin");
            chain.Add("fjkals;fjasf", "het");

            Assert.IsTrue(chain.Check());
        }
    }
}