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
    public class BlockTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            Block block = new Block();
            string result = block.Serialize();

            var resutlBlock = Block.Deserilize(result);
            Assert.AreEqual(block.Hash, resutlBlock.Hash);
            Assert.AreEqual(block.Created, resutlBlock.Created);
            Assert.AreEqual(block.Data, resutlBlock.Data);
            Assert.AreEqual(block.PrevHash, resutlBlock.PrevHash);
            Assert.AreEqual(block.User, resutlBlock.User);
        }
    }
}