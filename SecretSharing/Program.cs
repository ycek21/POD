using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing
{
    class Program
    {
        static void Main(string[] args)
        {
            var trivialMethod = new TrivialSecretSharing();

            trivialMethod.ShareSecret(4, 200, 153);
            var number = trivialMethod.RetrieveSecret();

            Console.WriteLine("The secret number is: " + number);
            Console.ReadLine();

        }
    }
}
