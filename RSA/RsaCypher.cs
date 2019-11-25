using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSA
{
    public class RsaCypher
    {
        private BigInteger _p;
        private BigInteger _q;
        private BigInteger _n;
        private BigInteger _phi;
        private BigInteger _e;
        private BigInteger _d;

         private void GeneratePhi()
        {
            do
            {
                _p = BigInteger.genPseudoPrime(4, 100, new Random());
                _q = BigInteger.genPseudoPrime(4, 100, new Random());
            } 
            while (_p == _q);
            

            _n = _p * _q;

            _phi = (_p - 1) * (_q - 1);

            

        }

         private void GenerateE()
         {
             do
             {
                 _e = BigInteger.genPseudoPrime(4, 100, new Random());

                while ( _phi.gcd(_e) != 1 )
                {
                    _e = BigInteger.genPseudoPrime(4, 100, new Random());

                }
             } 
             while (!_e.isProbablePrime(100));
         }

         private void GenerateD()
         {
            int x = 1;

            while (((_e * x) % _phi) != 1)
            {
                x++;
            }

            _d = x;

         }



        public void GenerateKeys()
         {
            GeneratePhi();
            GenerateE();
            GenerateD();
         }

         public string EncryptText(string message)
         {
             StringBuilder sb = new StringBuilder();

             foreach (var character in message)
             {
                 sb.Append(EncryptChar(character));
             }
             return sb.ToString();
        }

         public char EncryptChar(char character)
         {
             var c = new BigInteger(character);

             var result = PositivePow(c, _e);

             result %= _n;

             var resultString = result.ToString();

             int j = 0;


             Int32.TryParse(resultString, out j);

             char encryptedCharacter = (char) j;

             return encryptedCharacter;
         }


         public char DecryptChar(char character)
         {
             
             var c = new BigInteger(character);

            var result = PositivePow(c, _d);

            result %= _n;

            var resultString = result.ToString();

            int j = 0;

            Int32.TryParse(resultString, out j);

            char encryptedCharacter = (char)j;

            return encryptedCharacter;
        }

        
       

        public string DecryptText(string decrypted)
         {
             StringBuilder sb = new StringBuilder();

             foreach (var character in decrypted)
             {
                 sb.Append(DecryptChar(character));
             }

             return sb.ToString();
         }


        public BigInteger PositivePow(BigInteger uno, BigInteger dos)
         {
            BigInteger result = new BigInteger(1);

            if (dos < 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dos; i++)
                {
                    BigInteger multiple = new BigInteger(uno);
                    result *= multiple;
                }
                return result;
            }
         }


    }
}
