using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class ShortSeriesTest
    {


        public static bool ShortSeries(BitArray array)
        {
            int[] counter = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; 
            
            int combo = 0;

            for (int i = 1; i < array.Length; i++)
            {

                bool a = array.Get(i);
                bool b = array.Get(i - 1);

                if (a == b)
                {
                    combo++;
                }
                else
                {
                    switch (combo)
                    {
                        case 0:
                        {
                            if (b == true)
                            {
                                counter[0] += 1;
                            }
                            else
                            {
                                counter[6] += 1;
                            }
                            
                            combo = 0;
                            break;
                        }
                        case 1:
                        {
                            if (b == true)
                            {
                                counter[1] += 1;
                            }
                            else
                            {
                                counter[7] += 1;
                            }
                            combo = 0;
                                break;
                        }
                        case 2:
                        {
                            if (b == true)
                            {
                                counter[2] += 1;
                            }
                            else
                            {
                                counter[8] += 1;
                            }
                            combo = 0;
                                break;
                        }
                        case 3:
                        {
                            if (b == true)
                            {
                                counter[3] += 1;
                            }
                            else
                            {
                                counter[9] += 1;
                            }
                            combo = 0;
                                break;
                        }
                        case 4:
                        {
                            if (b == true)
                            {
                                counter[4] += 1;
                            }
                            else
                            {
                                counter[10] += 1;
                            }
                            combo = 0;
                                break;
                        }
                        default:
                        {
                            if (b == true)
                            {
                                counter[5] += 1;
                            }
                            else
                            {
                                counter[11] += 1;
                            }
                            combo = 0;
                                break;
                        }
                    }
                }
            }


            return (counter[0] > 2315 && counter[0] < 2685 && counter[1] > 1114 && counter[1] < 1386 &&
                    counter[2] > 527 && counter[2] < 723 && counter[3] > 240 && counter[3] < 384 &&
                    counter[4] > 103 && counter[4] < 209 && counter[5] > 103 && counter[5] < 209 &&
                    counter[6] > 2315 && counter[6] < 2685 && counter[7] > 1114 && counter[7] < 1386 &&
                    counter[8] > 527 && counter[8] < 723 && counter[9] > 240 && counter[9] < 384 &&
                    counter[10] > 103 && counter[10] < 209 && counter[11] > 103 && counter[11] < 209);



        }

    }
}
