using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChane
{
    public class Block
    {
        public int Id { get; private set; }
        public string Data { get; private set; }
        public DateTime Created { get; private set; }
        public string Hash { get; private set; }
        public string PrevHash { get; private set; }
        public string User { get; private set; }

        public Block()
        {
            Id = 1;
            Data = "Hello world";
            Created = DateTime.UtcNow;
            PrevHash = "111111";
            User = "Admin";

            var blockData = GetData();
            Hash = GetHash(blockData);
        }
        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("Empty argument data", nameof(data));
            }

            if (block == null)
            {
                throw new ArgumentNullException("Empty argument block", nameof(block));
            }

            if (string.IsNullOrEmpty(user))
            {
                throw new ArgumentNullException("Empty argument user", nameof(user));
            }

            Data = data;
            User = user;
            PrevHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;

            var blockData = GetData();
            Hash = GetHash(blockData);
        }
        private string GetData()
        {
            string result = "";

            result += Id.ToString();
            result += Created.ToString("G");
            result += PrevHash;
            result += User;

            return result;
        }

        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);

            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public override string ToString()
        {
            return Data;
        }
    }
}
