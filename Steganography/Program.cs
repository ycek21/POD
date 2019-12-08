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
            //steganography.HideImage("C:/Users/Jacek/Desktop/cat.jpeg", "dziala gowno pierdolone w koncu bo juz naprawde");
            var text = steganography.DecryptText("C:/Users/Jacek/Desktop/result.png");
            Console.WriteLine("text: " + text);
            Console.ReadLine();
        }
    }
}
