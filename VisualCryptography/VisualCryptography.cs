using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCryptography
{
    public class VisualCryptography
    {
        private readonly Bitmap _originalFile;
        public Bitmap FirstPicture;
        public Bitmap SecondPicture;
        public Bitmap ResultPicture;
        private readonly Random _random = new Random();

        private readonly Color[,] _sharesTable = new Color[,]{{Color.White, Color.Black, Color.Black, Color.White },
            { Color.Black, Color.White , Color.White , Color.Black},{ Color.White , Color.Black, Color.White , Color.Black},
            { Color.Black, Color.White, Color.Black,Color.White },{Color.Black,Color.Black,Color.White,Color.White},{Color.White,Color.White,Color.Black,Color.Black}};
        public VisualCryptography(string filePath)
        {
            this._originalFile = new Bitmap(filePath);
        }

        public void CreatePictures()
        {
            this.FirstPicture = new Bitmap(_originalFile.Width *2 , _originalFile.Height*2);
            this.SecondPicture = new Bitmap(_originalFile.Width * 2, _originalFile.Height * 2);

            for (var x = 0; x < _originalFile.Width; x++)
            {
                for (var y = 0; y < _originalFile.Height; y++)
                {
                    var index = _random.Next(0, 5);

                    FirstPicture.SetPixel(x * 2, y * 2, this._sharesTable[index, 0]);
                    FirstPicture.SetPixel((x * 2) + 1, y * 2, this._sharesTable[index, 1]);
                    FirstPicture.SetPixel(x * 2, (y * 2) + 1, this._sharesTable[index, 2]);
                    FirstPicture.SetPixel((x * 2) + 1, (y * 2) + 1, this._sharesTable[index, 3]);

                    if (_originalFile.GetPixel(x, y).R == 255 && _originalFile.GetPixel(x, y).B == 255 &&
                        _originalFile.GetPixel(x, y).B == 255)
                    {
                        SecondPicture.SetPixel(x * 2, y * 2, this._sharesTable[index, 0]);
                        SecondPicture.SetPixel((x * 2) + 1, y * 2, this._sharesTable[index, 1]);
                        SecondPicture.SetPixel(x * 2, (y * 2) + 1, this._sharesTable[index, 2]);
                        SecondPicture.SetPixel((x * 2) + 1, (y * 2) + 1, this._sharesTable[index, 3]);
                    }
                    else
                    {
                        switch (index % 2)
                        {
                            case 0:
                            {
                                SecondPicture.SetPixel(x * 2, y * 2, this._sharesTable[index + 1, 0]);
                                SecondPicture.SetPixel((x * 2) + 1, y * 2, this._sharesTable[index + 1, 1]);
                                SecondPicture.SetPixel(x * 2, (y * 2) + 1, this._sharesTable[index + 1, 2]);
                                SecondPicture.SetPixel((x * 2) + 1, (y * 2) + 1, this._sharesTable[index + 1, 3]);
                                break;
                            }
                            case 1:
                            {
                                SecondPicture.SetPixel(x * 2, y * 2, this._sharesTable[index - 1, 0]);
                                SecondPicture.SetPixel((x * 2) + 1, y * 2, this._sharesTable[index - 1, 1]);
                                SecondPicture.SetPixel(x * 2, (y * 2) + 1, this._sharesTable[index - 1, 2]);
                                SecondPicture.SetPixel((x * 2) + 1, (y * 2) + 1, this._sharesTable[index - 1, 3]);
                                break;
                            }
                        }
                    }

                }
            }

            FirstPicture.Save("firstPicture.png",ImageFormat.Png);
            SecondPicture.Save("secondPicture.png", ImageFormat.Png);

        }

        public void SuperimposePictures()
        {
            this.ResultPicture = new Bitmap(FirstPicture.Width,FirstPicture.Height);



            ResultPicture.Save("resultPicture.png",ImageFormat.Png);
        }

    }
}
