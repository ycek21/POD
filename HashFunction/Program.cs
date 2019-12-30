using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condition = true;

            Stopwatch stopwatch = new Stopwatch();

            do
            {
                Console.WriteLine("1.Write down text to create hash functions\n" +
                                  "Any other key will shut down the app");
                var switchCondition = Console.ReadLine();

                switch (switchCondition)
                {
                    case "1":
                    {
                        Console.WriteLine("Type text to cypher");
                        var text = Console.ReadLine();

                        stopwatch.Start();
                        var md5 = new CreateHash().CalculateMD5(text);
                        stopwatch.Stop();

                        var md5Time = stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        stopwatch.Start();
                        var sha1 = new CreateHash().CalculateSHA1(text);
                        stopwatch.Stop();

                        var sha1Time = stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        stopwatch.Start();
                        var sha256 = new CreateHash().CalculateSHA256(text);
                        stopwatch.Stop();

                        var sha256Time = stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        stopwatch.Start();
                        var sha384 = new CreateHash().CalculateSHA384(text);
                        stopwatch.Stop();

                        var sha384Time = stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        stopwatch.Start();
                        var sha512 = new CreateHash().CalculateSHA512(text);
                        stopwatch.Stop();

                        var sha512Time = stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        Console.WriteLine("\nMD5 " + md5 + " " + md5.Length *4 + "\n" + "Elapsed time(miliseconds): " + md5Time);
                        Console.WriteLine("SHA1 " + sha1 + " " + sha1.Length*4 + "\n" + "Elapsed time(miliseconds): " + sha1Time);
                        Console.WriteLine("SHA256 " + sha256 + " " + sha256.Length*4 + "\n" + "Elapsed time(miliseconds): " + sha256Time);
                        Console.WriteLine("SHA384 " + sha384 + " " + sha384.Length*4 + "\n" + "Elapsed time(miliseconds): " + sha384Time);
                        Console.WriteLine("SHA512 "+ sha512 + " " + sha512.Length*4 + "\n" + "Elapsed time(miliseconds): " + sha512Time);

                        break;
                    }
                    default:
                    {
                        condition = false;
                        break;
                    }
                }

            } while (condition == true);


        }
    }
}
