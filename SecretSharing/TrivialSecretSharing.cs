using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing
{
    public class TrivialSecretSharing
    {
        private List<int> _players;
        private int _secretNumber;
        private int _numberRange;
        private Random _random = new Random();

        public void ShareSecret(int numberOfPlayers, int numberRange, int secretNumber)
        {
            this._secretNumber = secretNumber;
            this._numberRange = numberRange;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (i == numberOfPlayers - 1)
                {
                    _players.Add(_random.Next(0, this._numberRange - 1));
                }
                else
                {
                    this._players.Add((_secretNumber - this._players.Sum()) % this._numberRange);
                }
            }
        }

        public void RetrieveSecret()
        {

        }
    }
}
