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
            var player = new List<int> {1, 2, 3, 4, 5};

            var sum = player.Sum();

            Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}
