using System;
using System.Collections.Generic;

namespace SecretSharing
{
    public class ShamirScheme
    {
        private int _p;
        private int _n;
        private int _t;
        private List<int> _shares = new List<int>();
        private List<int> _aArray = new List<int>();

        public void ShareSecret(int secretNumber, int shareNumber, int conditionShareNumber)
        {
            var random = new Random();
            this._aArray.Add(secretNumber);
            this._n = shareNumber;
            this._t = conditionShareNumber;
            this._p = (secretNumber >= shareNumber)
                ? Helpers.GeneratePrime(secretNumber +1, secretNumber + 500)
                : Helpers.GeneratePrime(shareNumber +1, shareNumber + 500);
            for (var i = 0; i < _t-1; i++)
            {
                _aArray.Add(random.Next(0,500));
            }

            for (var j = 1; j <= _n; j++)
            {
                var result = 0;

                result += _aArray[0];

                for (var k = 1; k <= _t-1; k++)
                {
                    result += (_aArray[k] * (int)Math.Pow(j,k));
                }

                result = result % _p;

                _shares.Add(result);
            }
        }

    }
}
