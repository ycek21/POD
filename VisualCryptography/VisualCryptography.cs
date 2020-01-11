using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCryptography
{
    public class VisualCryptography
    {
        private Bitmap _originalFile;

        public VisualCryptography(string filePath)
        {
            this._originalFile = new Bitmap(filePath);
        }



    }
}
