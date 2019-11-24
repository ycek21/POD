using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RsaCypher();

            rsa.GenerateKeys();
            char jacek = 'a';
            BigInteger jacek2 = new BigInteger(100);

            //var result = rsa.PositivePow(jacek, jacek2);

            var decrypted = rsa.EncryptText("jacek chyba nie wie za bardzo o co chodzi");

            var encrypted = rsa.DecryptText(decrypted);



        }
    }
}
