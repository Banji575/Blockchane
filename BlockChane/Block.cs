using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlockChane
{

    [DataContract]
    public class Block
    {
        public int Id { get; private set; }

        [DataMember]
        public string Data { get; private set; }

        [DataMember]
        public DateTime Created { get; private set; }

        [DataMember]
        public string Hash { get; private set; }

        [DataMember]
        public string PrevHash { get; private set; }

        [DataMember]
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
        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Block));

            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static Block Deserilize(string json)
        {
            var jsonSeriliazer = new DataContractJsonSerializer(typeof(Block));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (Block)jsonSeriliazer.ReadObject(ms);

            }
        }
    }
}
