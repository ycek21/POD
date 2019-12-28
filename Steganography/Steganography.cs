using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Steganography
{
    public class Steganography
    {
        //public Bitmap bm;

        public void HideImage(string filePath, string message)
        {
            var bm = new Bitmap(filePath);

            var pixelColorIndex = 0;
            var messageIndex = 0;
            var currentChar = 0;

            for (var i = 0; i < bm.Height; i++)
            {
                for (var j = 0; j < bm.Width; j++)
                {
                    var pixel = bm.GetPixel(i, j);

                    var R = pixel.R - pixel.R % 2;
                    var G = pixel.G - pixel.G % 2;
                    var B = pixel.B - pixel.B % 2;


                    for (var k = 0; k < 3; k++)
                    {
                        if (pixelColorIndex == 0)
                        {
                            currentChar = message[0];
                        }

                        if (pixelColorIndex % 8 == 0)
                        {

                           
                            if (pixelColorIndex != 0)
                            {
                                messageIndex++;

                                if (messageIndex == message.Length)
                                {
                                    
                                        switch (pixelColorIndex % 3)
                                        {
                                            case 0:
                                            {
                                                R = 0;
                                                G = 0;
                                                B = 0;
                                                bm.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                                                bm.SetPixel(i, j + 1, Color.FromArgb(0, 0, 0));
                                                bm.SetPixel(i, j + 2, Color.FromArgb(0, 0, bm.GetPixel(i,j+2).B));
                                                break;
                                            }
                                            case 1:
                                            {
                                                G = 0;
                                                B = 0;
                                                bm.SetPixel(i, j, Color.FromArgb(R, G, B));
                                                R = 0;
                                                bm.SetPixel(i, j + 1, Color.FromArgb(R, G, B));
                                                bm.SetPixel(i, j + 2, Color.FromArgb(R, G, B));
                                                break;
                                            }
                                            case 2:
                                            {
                                                B = 0;
                                                bm.SetPixel(i, j, Color.FromArgb(R, G, B));
                                                R = 0;
                                                G = 0;
                                                bm.SetPixel(i, j + 1, Color.FromArgb(R, G, B));
                                                bm.SetPixel(i, j + 2, Color.FromArgb(R, G, B));
                                                bm.SetPixel(i, j + 3, Color.FromArgb(R, bm.GetPixel(i, j + 3).G, bm.GetPixel(i, j + 3).B));
                                                break;
                                            }
                                        }

                                    bm.Save("result.png", ImageFormat.Png);
                                    

                                    //Console.WriteLine(bm.GetPixel(0, 0));
                                    //Console.WriteLine(bm.GetPixel(0, 1));
                                    //Console.WriteLine(bm.GetPixel(0, 2));
                                    //Console.WriteLine(bm.GetPixel(0, 3));
                                    //Console.WriteLine(bm.GetPixel(0, 4));
                                    //Console.WriteLine(bm.GetPixel(0, 5));

                                    //Console.WriteLine(bm.GetPixel(0, 6));
                                    //Console.WriteLine(bm.GetPixel(0, 7));
                                    //Console.WriteLine(bm.GetPixel(0, 8));
                                    //Console.WriteLine(bm.GetPixel(0, 9));
                                    //Console.WriteLine(bm.GetPixel(0, 10));
                                    //Console.WriteLine(bm.GetPixel(0, 11));

                                    //Console.WriteLine(bm.GetPixel(0, 12));
                                    //Console.WriteLine(bm.GetPixel(0, 13));
                                    //Console.WriteLine(bm.GetPixel(0, 14));
                                    //Console.WriteLine(bm.GetPixel(0, 15));
                                    //Console.WriteLine(bm.GetPixel(0, 16));
                                    //Console.WriteLine(bm.GetPixel(0, 17));

                                    bm.Dispose();

                                    return;
                                }
                                else
                                {
                                    currentChar = message[messageIndex];
                                }

                            }

                        }

                        switch (pixelColorIndex % 3)
                        {

                            case 0:
                            {
                                R += currentChar % 2;
                                currentChar /= 2;
                                pixelColorIndex++;
                                bm.SetPixel(i, j, Color.FromArgb(R, G, B));
                                    break;
                            }
                            case 1:
                            {
                                G += currentChar % 2;
                                currentChar /= 2;
                                pixelColorIndex++;
                                bm.SetPixel(i, j, Color.FromArgb(R, G, B));
                                    break;
                            }
                            case 2:
                            {
                                B += currentChar % 2;
                                currentChar /= 2;
                                pixelColorIndex++;
                                bm.SetPixel(i, j, Color.FromArgb(R, G, B));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string DecryptText(string filePath)
        {
            var text = String.Empty;

            var bm = new Bitmap(filePath);
            var pixelColorIndex = 0;
            int charValue = 0;

            for (var i = 0; i < bm.Height; i++)
            {
                for (var j = 0; j < bm.Width; j++)
                {
                    var pixel = bm.GetPixel(i, j);

                    for (var k = 0; k < 3; k++)
                    {
                        switch (pixelColorIndex % 3)
                        {
                            case 0:
                            {
                                charValue = charValue * 2 + pixel.R % 2;
                                break;
                            }
                            case 1:
                            {
                                charValue = charValue * 2 + pixel.G % 2;
                                break;
                            }
                            case 2:
                            {
                                charValue = charValue * 2 + pixel.B % 2;
                                break;
                            }
                        }
                        pixelColorIndex++;

                        if (pixelColorIndex % 8 == 0)
                        {
                            charValue = ReverseBits(charValue);

                            if (charValue == 0)
                            {
                                return text;
                            }

                            char c = (char)charValue;

                            text += c.ToString();
                        }

                        
                    }
                }
            }

            return text;
        }


        public static int ReverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
    }
}
