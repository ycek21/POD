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
            //var rsa = new RsaCypher();

            //rsa.GenerateKeys();
            //char jacek = 'a';
            //BigInteger jacek2 = new BigInteger(100);

            ////var result = rsa.PositivePow(jacek, jacek2);

            //var decrypted = rsa.EncryptText("jacek chyba nie wie za bardzo o co chodzi");

            //var encrypted = rsa.DecryptText(decrypted);

            Boolean flag = true;

            do
            {
                Console.WriteLine("1. Generate keys\n" + "2. Encrypt text\n" + "3. Decipher text\n" + "0. Exit\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                var rsa = new RsaCypher();
                switch (choice)
                {
                    case 1:
                    {
                        
                        rsa.GenerateKeys();
                        break;
                    }
                    case 2:
                    {
                        var text = Console.ReadLine();
                        var encryptedText = rsa.EncryptText(text);
                        Console.WriteLine("Text: " + text + "encrypted: " + encryptedText);

                        break;
                    }
                    case 3:
                    {
                            break;
                    }
                    case 0:
                    {
                        flag = false;
                        break;
                    }
                }

            } while (flag);

        }
    }
}
