using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diffi_Hellman
{
    public class Person
    {
        private BigInteger privateKey;
        public BigInteger X;
        public BigInteger publicKey;

        public void GeneratePrivateKey()
        {
            this.privateKey = BigInteger.genPseudoPrime(48,100,new Random());
        }

        public void CalculateX(BigInteger g,BigInteger n)
        {
            this.X = g.modPow(privateKey, n);
        }

        public void GenPublicKey(BigInteger partnerNumber, BigInteger n)
        {
            this.publicKey = partnerNumber.modPow(privateKey, n);
        }

    }
}
