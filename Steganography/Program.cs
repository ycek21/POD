using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
    class Program
    {
        static void Main(string[] args)
        {

            var steganography = new Steganography();

            var condition = true;

            while (condition)
            {
                Console.Clear();
                Console.WriteLine("Choose what do you want to do \n"+"1. Encrypt text\n" + "2. Decrypt text\n" + "0. Exit\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                string text;

                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("Pass text do encode");
                        text = Console.ReadLine();
                        steganography.HideImage("E:/Studia/5 SEMESTR/Podstawy Ochrony Danych/POD/Steganography/bin/Debug/cat.png", text);
                        Console.WriteLine("Encryption successful \n");
                        Console.WriteLine("Press enter to go on");
                        Console.ReadLine();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Decoding image...\n");
                        text = steganography.DecryptText("E:/Studia/5 SEMESTR/Podstawy Ochrony Danych/POD/Steganography/bin/Debug/result.png");
                        Console.WriteLine("text: " + text);
                        Console.WriteLine("Press enter to go on");
                        Console.ReadLine();
                        break;
                    }
                    case 0:
                    {
                        condition = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Bad choice, try one more time \n");
                        Console.ReadLine();
                        break;
                    }
                }

            }


        }
    }
}
