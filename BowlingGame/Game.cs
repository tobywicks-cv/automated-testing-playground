using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll = 0;

        public void Roll(int pinsDown)
        {
            _rolls[_currentRoll++] = pinsDown;
        }

        public int Score()
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (_rolls[rollIndex] == 10) // strike
                {
                    score += 10 + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
                    rollIndex += 1;
                }
                else if (_rolls[rollIndex] + _rolls[rollIndex + 1] == 10) // spare
                {
                    score += 10 + _rolls[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    score += _rolls[rollIndex] + _rolls[rollIndex + 1];
                    rollIndex += 2;
                }
            }

            return score;
        }
    }
}
