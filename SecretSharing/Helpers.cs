using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing
{
    public class Helpers
    {

        public static int GeneratePrime(int min, int max)
        {
            var rnd = new Random();

            int randomPrime;
            do
            {
                randomPrime = rnd.Next(min, max);
            } while (!IsPrime(randomPrime));

            return randomPrime;
        }


        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (var i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                {
                    return false;
                }

            return true;
        }
    }
}
