using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class BBS
    {

        public BBS()
        {
            resultArray = GenerateArray();
        }

        public BitArray resultArray;

        public BigInteger p;
        public BigInteger q;
        public BigInteger N;
        public BigInteger x;


        private void CheckModulo4()
        {

            bool a = true;
            bool b = true;

            p = BigInteger.genPseudoPrime(128, 100, new Random());
            q = BigInteger.genPseudoPrime(128, 100, new Random());

            while (a || b == true)
            {
                if (p % 4 != 3)
                {
                    p = BigInteger.genPseudoPrime(128, 100, new Random());
                }
                else
                {
                    a = false;
                }

                if (q % 4 != 3)
                {
                    q = BigInteger.genPseudoPrime(128, 100, new Random());
                }
                else
                {
                    b = false;
                }
            }
        }


        private void CheckX()
        {
            x= BigInteger.genPseudoPrime(128, 100, new Random());
            
            while (N.gcd(x) != 1)
            {
                x = BigInteger.genPseudoPrime(128, 100, new Random());
            }
        }




        public BitArray GenerateArray()
        {
            CheckModulo4();
            N = p * q;
            CheckX();

            resultArray = new BitArray(20000);

            BigInteger xO = new BigInteger();
            xO = (x * x) % N;

            for (int i=0; i<20000; i++)
            {
                //if (i == 0)
                {
                    if (xO % 2 == 0)
                    {
                        resultArray.Set(i,false);
                    }
                    else
                    {
                        resultArray.Set(i,true);
                    }

                    xO = (xO * xO) % N;
                }
                /*else
                {
                    if (xO % 2 == 0)
                    {
                        resultArray.Set(i, false);
                    }
                    else
                    {
                        resultArray.Set(i, true);
                    }

                    xO = (xO * xO) % N;
                }*/

            }
            return resultArray;

        }
    }
}
