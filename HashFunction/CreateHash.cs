using System.Security.Cryptography;
using System.Text;

namespace HashFunction
{
    public class CreateHash
    {
        public string CalculateMD5(string message)
        {
            using var md5 = MD5.Create();
            var messageBytes = StringToBytes(message);
            var encodedMessage = md5.ComputeHash(messageBytes);

            return BytesToString(encodedMessage);
        }

        public string CalculateSHA1(string message)
        {
            using var sha1 = SHA1.Create();
            var messageBytes = StringToBytes(message);
            var encodedMessage = sha1.ComputeHash(messageBytes);

            return BytesToString(encodedMessage);
        }

        public string CalculateSHA256(string message)
        {
            using var sha2 = SHA256.Create();
            var messageBytes = StringToBytes(message);
            var encodedMessage = sha2.ComputeHash(messageBytes);

            return BytesToString(encodedMessage);
        }

        public string CalculateSHA384(string message)
        {
            using var sha2 = SHA384.Create();
            var messageBytes = StringToBytes(message);
            var encodedMessage = sha2.ComputeHash(messageBytes);

            return BytesToString(encodedMessage);
        }
        public string CalculateSHA512(string message)
        {
            using var sha2 = SHA512.Create();
            var messageBytes = StringToBytes(message);
            var encodedMessage = sha2.ComputeHash(messageBytes);

            return BytesToString(encodedMessage);
        }


        private byte[] StringToBytes(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            return bytes;
        }

        private string BytesToString(byte[] bytes)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sBuilder.Append(bytes[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
