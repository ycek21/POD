using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class Poker
    {

        public static bool PokerTest(BitArray array)
        {

            float min = 2.16f;

            float max = 46.17f;

            bool result;

            float x = 0f;


            Dictionary<String, int> dictionary = new Dictionary<string, int>()
            {
                {"0000", 0},
                {"0001", 0},
                {"0010", 0},
                {"0011", 0},
                {"0100", 0},
                {"0101", 0},
                {"0110", 0},
                {"0111", 0},
                {"1000", 0},
                {"1001", 0},
                {"1010", 0},
                {"1011", 0},
                {"1100", 0},
                {"1101", 0},
                {"1110", 0},
                {"1111", 0}
            };

            var stringBuilder = new StringBuilder();

            foreach (bool bit in array)
            {
                stringBuilder.Append(bit ? 1 : 0);
            }

            var bitsString = stringBuilder.ToString();

            string[] bits = new string[5000];

            for (int i = 0; i < bitsString.Length / 4; i++)
            {
                bits[i] = bitsString.Substring(i * 4, 4);
            }

            foreach (var bit in bits)
            {
                dictionary[bit]++;
            }

            float sum = 0;

            for (int i = 0; i < dictionary.Count; i++)
            {
                sum += dictionary.Values.ToList()[i] * dictionary.Values.ToList()[i];
            }

            x = ((16.0f / 5000.0f) * sum) - 5000;


            result = x >min && x < max;

            return result;

        }

    }
}
