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

            /*var ecbEncryptS = aes.EncryptFile("smallFile.txt",CipherMode.ECB);
            var ecbDecryptS = aes.DecryptFile("AESsmallFile.txt", CipherMode.ECB);

            Console.WriteLine("ECB Encrypt time for smallFile: " + ecbEncryptS + " miliseconds");
            Console.WriteLine("ECB Decrypt time for smallFile: " + ecbDecryptS + " miliseconds");*/

            //var ecbEncryptM = aes.EncryptFile("mediumFile.txt", CipherMode.ECB);
            var ecbDecryptM = aes.DecryptFile("AESmediumFile.txt", CipherMode.ECB);

            /*Console.WriteLine("ECB Encrypt time for mediumFile: " + ecbEncryptM + " miliseconds");
            Console.WriteLine("ECB Decrypt time for mediumFile: " + ecbDecryptM + " miliseconds");

            var ecbEncryptL = aes.EncryptFile("bigFile.txt", CipherMode.ECB);
            var ecbDecryptL = aes.DecryptFile("AESbigFile.txt", CipherMode.ECB);

            Console.WriteLine("ECB Encrypt time for bigFile: " + ecbEncryptL + " miliseconds");
            Console.WriteLine("ECB Decrypt time for bigFile: " + ecbDecryptL + " miliseconds");*/

            Console.ReadLine();

            /*var cbcEncryptS = aes.EncryptFile("smallFile.txt", CipherMode.CBC);
            var cbcDecryptS = aes.DecryptFile("AESsmallFile.txt", CipherMode.CBC);

            Console.WriteLine("CBC Encrypt time for smallFile: " + cbcEncryptS + " miliseconds");
            Console.WriteLine("CBC Decrypt time for smallFile: " + cbcDecryptS + " miliseconds");

            var cbcEncryptM = aes.EncryptFile("mediumFile.txt", CipherMode.CBC);
            var cbcDecryptM = aes.DecryptFile("AESmediumFile.txt", CipherMode.CBC);

            Console.WriteLine("CBC Encrypt time for mediumFile: " + cbcEncryptM + " miliseconds");
            Console.WriteLine("CBC Decrypt time for mediumFile: " + cbcDecryptM + " miliseconds");

            var cbcEncryptL = aes.EncryptFile("bigFile.txt", CipherMode.CBC);
            var cbcDecryptL = aes.DecryptFile("AESbigFile.txt", CipherMode.CBC);

            Console.WriteLine("CBC Encrypt time for bigFile: " + cbcEncryptL + " miliseconds");
            Console.WriteLine("CBC Decrypt time for bigFile: " + cbcDecryptL + " miliseconds");

            Console.ReadLine();*/

            }
    }
}
