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
            steganography.HideImage("C:/Users/Jacek/Desktop/zdjecie12.png", "ja t");
            Console.WriteLine(steganography.bm.GetPixel(0, 0));
            Console.WriteLine(steganography.bm.GetPixel(0, 1));
            Console.WriteLine(steganography.bm.GetPixel(0, 2));
            Console.WriteLine(steganography.bm.GetPixel(0, 3));
            Console.WriteLine(steganography.bm.GetPixel(0, 4));
            Console.WriteLine(steganography.bm.GetPixel(0, 5));

            Console.WriteLine(steganography.bm.GetPixel(0, 6));
            Console.WriteLine(steganography.bm.GetPixel(0, 7));
            Console.WriteLine(steganography.bm.GetPixel(0, 8));
            Console.WriteLine(steganography.bm.GetPixel(0, 9));
            Console.WriteLine(steganography.bm.GetPixel(0, 10));
            Console.WriteLine(steganography.bm.GetPixel(0, 11));


            Console.ReadLine();
        }
    }
}
