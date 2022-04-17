using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChane
{
    public class Chaine
    {
        public List<Block>Blocks { get; private set; } = new List<Block>();

        public Block Last { get; private set; }
        public Chaine()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();

            Blocks.Add(genesisBlock);
            Last = genesisBlock;
        }

        public void Add(string data, string user)
        {
            var block = new Block(data, user , Last);
            Blocks.Add(block);
            Last = block;

            Save(block);
        }

        public bool Check()
        {
            Block genesisBlock = new Block();
            var previousHash = genesisBlock.Hash;

            foreach (var block in Blocks.Skip(1))
            {
                var hash = block.PrevHash;
                if(previousHash != hash)
                {
                    return false;
                }
                previousHash = block.Hash;
            }

            return true;
        }

        private void Save(Block block)
        {
            using (var db = new BlockchainContext())
            {
                db.Blocks.Add(block);
                db.SaveChanges();
            }
        }
    }
}
