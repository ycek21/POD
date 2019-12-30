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
