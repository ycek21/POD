using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCryptography
{
    class Program
    {
        static void Main(string[] args)
        {
         //   var bm = new Bitmap("E:/Studia/5 SEMESTR/Podstawy Ochrony Danych/POD/VisualCryptography/bin/Debug/picture2.png");

         //   Console.WriteLine(bm.GetPixel(0,0));
         //   Console.WriteLine(bm.GetPixel(0, 1));
         //   Console.WriteLine(bm.GetPixel(0, 2));
         //   Console.WriteLine(bm.GetPixel(0, 3));
         //   Console.WriteLine(bm.GetPixel(0, 4));
         //   Console.WriteLine(bm.GetPixel(0, 5));

         //   Console.WriteLine(bm.GetPixel(300, 150));

         //   var color = Color.Black;

         //   var white = Color.White;

         //   Console.WriteLine(color.R +""+ color.G + "" + color.B);
         //   Console.WriteLine(white.R + "" + white.G + "" + white.B);

         //   //bm.SetPixel(0,0,color);

         //   Console.WriteLine(bm.GetPixel(0, 0));
         //   //bm.Save("jacek.png", ImageFormat.Png);

         //   if(bm.GetPixel(0,0).R == 255 && bm.GetPixel(0, 0).G == 255 && bm.GetPixel(0,0).B == 255)
         //   {
         //       Console.WriteLine("DUPA");
         //   }



         //Color[,] sharesTable = new Color[,]{{Color.White, Color.Black, Color.Black, Color.White },
         //       { Color.Black, Color.White , Color.White , Color.Black},{ Color.White , Color.Black, Color.White , Color.Black},
         //       { Color.Black, Color.White, Color.Black,Color.White },{Color.Black,Color.Black,Color.White,Color.White},{Color.White,Color.White,Color.Black,Color.Black}};

         //   for (int i = 0; i <sharesTable.GetLength(0); i++)
         //   {
         //       for (var j = 0; j <sharesTable.GetLength(1); j++)
         //       {
         //           Console.WriteLine(sharesTable[i,j]);
         //       }
         //       Console.WriteLine("\n");
         //   }

         //   Console.WriteLine(sharesTable[0,0]);
         //   Console.WriteLine(sharesTable[0, 1]);

         //   Console.WriteLine(sharesTable[0,2]);
         //   Console.WriteLine(sharesTable[0, 3]);

         var visualCryptography = new VisualCryptography("E:/Studia/5 SEMESTR/Podstawy Ochrony Danych/POD/VisualCryptography/bin/Debug/picture.png");
         visualCryptography.CreatePictures();
         visualCryptography.SuperimposePictures();
         Console.ReadLine();

        }
    }
}
