using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class LongSeriesTest
    {
        public static bool LongSeries(BitArray array)
        {
            int combo = 0;


            for (int i = 1; i < array.Length; i++)
            {
                

                bool a = array.Get(i);
                bool b = array.Get(i-1);
                if (a == b)
                {
                    combo++;
                }
                else
                {
                    {
                        combo = 0;
                    }
                }
            }

            if (combo == 25)
            {
                return false;
            }
            return true;

        }

    }
}
