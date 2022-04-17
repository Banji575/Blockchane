using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlockChane
{
    class BlockchainContext : DbContext
    {
        public BlockchainContext()
            :base("BlockchainConnection")
        { }

        public DbSet<Block> Blocks { get; set; }
    }
}