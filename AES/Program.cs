using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            var aes = new AesCypher();
            aes.GenerateKeyIV();
            aes.EncryptFile("smallFile.txt",CipherMode.ECB);
            aes.DecryptFile("AESsmallFile.txt", CipherMode.ECB);
        }
    }
}
