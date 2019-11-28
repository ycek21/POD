using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diffi_Hellman
{
    class Program
    {
        static void Main(string[] args)
        {
            var df = new Difi_Hellman();
            var A = new Person();
            var B = new Person();

            df.GenerateN();
            df.GenerateG();

            A.GeneratePrivateKey();
            B.GeneratePrivateKey();

            A.CalculateX(df.g,df.n);
            B.CalculateX(df.g,df.n);

            A.GenPublicKey(B.X,df.n);
            B.GenPublicKey(A.X,df.n);

            Console.WriteLine("First person result: " + A.publicKey + "\n");
            Console.WriteLine("Second person result: " + B.publicKey + "\n");
            if (A.publicKey == B.publicKey)
            {
                Console.WriteLine("Keys are the same, operation went well");
            }
            else
            {
                Console.WriteLine("Oops something went wrong");

            }

            Console.ReadLine();


        }
    }
}
