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

            Boolean flag = true;
            var rsa = new RsaCypher();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Generate keys\n" + "2. Encrypt text\n" + "0. Exit\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                    {
                        
                        rsa.GenerateKeys();
                        Console.Clear();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Type text to encrypt");
                        var text = Console.ReadLine();
                        var encryptedText = rsa.EncryptText(text);

                        Console.WriteLine("Text encrypted with public key \n");
                        Console.WriteLine("Text : " + text + " encrypted: " + encryptedText + "\n");
                        Console.WriteLine("If you want to decrypt the message using private key press 1");
                        

                        int secondChoice = Convert.ToInt32(Console.ReadLine());

                        if (secondChoice == 1)
                        {
                            Console.WriteLine("Encrypted text: " + encryptedText + "\n");
                            var decryptedText = rsa.DecryptText(encryptedText);
                            Console.WriteLine("Decrypted text: " + decryptedText);
                            Console.WriteLine("To encrypt one more time press any key \n");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.Clear();
                            flag = false;
                        }

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
