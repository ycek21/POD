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
        public Bitmap bm;



        public void HideImage(string filePath, string message)
        {
            this.bm = new Bitmap(filePath);
            Console.WriteLine("Height: " + bm.Height);
            Console.WriteLine("Width: " + bm.Width);

            var pixelColorIndex = 0;
            var charIndex = 0;
            var messageIndex = 0;
            var currentChar = 0;
            var finish = false;
          
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
                                    bm.Save("result.png", ImageFormat.Png);
                                    //bm.Dispose();
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
