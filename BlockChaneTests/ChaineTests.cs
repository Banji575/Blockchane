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
        public void ChaineTest()
        {
           var chane = new Chaine();
            chane.Add("G5 Games", "SCh");

            Assert.AreEqual(2, chane.Blocks.Count);
            Assert.AreEqual("G5 Games", chane.Last.Data);
        }


    }
}