using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diffi_Hellman
{
    public class Difi_Hellman
    {
        public BigInteger n;
        public BigInteger g;

        public void GenerateN()
        {
            this.n = BigInteger.genPseudoPrime(48, 100, new Random());
        }

        public void GenerateG()
        {
            this.g = Help.findPrimitive(this.n);
        }





    }
}
