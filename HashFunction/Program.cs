using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var md5 = new CreateHash().CalculateMD5("jacek");
            Console.WriteLine(md5);
            Console.ReadLine();
        }
    }
}
