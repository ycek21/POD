using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class SingleBitTest
    {
        public static bool SingleBit(BitArray array)
        {
            int count = 0;
            foreach (bool o in array)
            {
                if (o == true)
                {
                    count++;
                }
            }

            return (count > 9725 && count < 10275);
            

        }

    }
}
