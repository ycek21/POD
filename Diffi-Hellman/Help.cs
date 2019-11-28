using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diffi_Hellman
{
    public class Help
    {

        // Utility function to store prime factors of a number 
        static void findPrimefactors(HashSet<BigInteger> s, BigInteger n)
        {
            // Print the number of 2s that divide n 
            while (n % 2 == 0)
            {
                s.Add(2);
                n = n / 2;
            }

            // n must be odd at this point. So we can skip 
            // one element (Note i = i +2) 
            for (BigInteger i = 3; i <= n.sqrt() ; i = i + 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    s.Add(i);
                    n = n / i;
                }
            }

            // This condition is to handle the case when 
            // n is a prime number greater than 2 
            if (n > 2)
            {
                s.Add(n);
            }
        }

        // Function to find smallest primitive root of n 
        public static BigInteger findPrimitive(BigInteger n)
        {
            HashSet<BigInteger> s = new HashSet<BigInteger>();

            // Check if n is prime or not 
            if (!n.isProbablePrime(100))
            {
                return -1;
            }
            

            

            // Find value of Euler Totient function of n 
            // Since n is a prime number, the value of Euler 
            // Totient function is n-1 as there are n-1 
            // relatively prime numbers. 
            BigInteger phi = n - 1;

            // Find prime factors of phi and store in a set 
            findPrimefactors(s, phi);

            // Check for every number from 2 to phi 
            for (BigInteger r = 2; r <= phi; r++)
            {
                // Iterate through all prime factors of phi. 
                // and check if we found a power with value 1 
                bool flag = false;
                foreach (BigInteger a in s)
                {

                    // Check if r^((phi)/primefactors) mod n 
                    // is 1 or not 
                    /*power(r, phi / (a), n)*/
                    if (r.modPow(phi/a,n) == 1)
                    {
                        flag = true;
                        break;
                    }
                }

                // If there was no power with value 1. 
                if (flag == false)
                {
                    return r;
                }
            }

            // If no primitive root found 
            return -1;
        }
    }
}
