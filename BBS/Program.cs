using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace BBS
{
    
    class Program
    {
        

        static void Main(string[] args)
        {
           BBS table = new BBS();
           

            Console.WriteLine("X N: "+ table.x +" " + table.N);
            Console.WriteLine(table.resultArray.Get(0) +" " + table.resultArray.Get(1) + " " + table.resultArray.Get(19999));
            

            bool singleBit = SingleBitTest.SingleBit(table.resultArray);

            Console.WriteLine("Single bit Test: "+ singleBit);

            bool longSeries = LongSeriesTest.LongSeries(table.resultArray);

            Console.WriteLine("longSeries Test: " + longSeries);

            bool shortSeries = ShortSeriesTest.ShortSeries(table.resultArray);

            Console.WriteLine("shortSeries Test: " + shortSeries);

            Console.ReadLine();


        }
    }
}
