using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing
{
    public class TrivialSecretSharing
    {
        private readonly List<int> _players = new List<int>();
        private int _secretNumber;
        private int _numberRange;
        private readonly Random _random = new Random();

        public void ShareSecret(int numberOfPlayers, int numberRange, int secretNumber)
        {
            this._secretNumber = secretNumber;
            this._numberRange = numberRange;

            for (var i = 0; i < numberOfPlayers; i++)
            {
                if (i != numberOfPlayers - 1)
                {
                    _players.Add(_random.Next(0, _numberRange - 1));
                }
                else
                {
                    this._players.Add(Mod((_secretNumber-this._players.Sum()),_numberRange));
                }
            }
        }

        public int RetrieveSecret()
        {

            var resolvedSecret = _players.Sum() % _numberRange;

            return resolvedSecret;
        }

        private int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
