using System.Collections.Generic;
using System.Linq;

namespace AutomatedTestingFramework
{
    public class GameOfLife
    {
        // a living cell with less than 2 neighbours dies
        // a living cell with 2 or 3 neighbours lives
        // a living cell with more than 3 neighbours dies
        // a dead cell with exactly 3 neighbours becomes a living cell

        public bool NextCellState(bool isAlive, int neighbours)
        {
            if (isAlive)
            {
                return neighbours is 2 or 3;
            }

            return neighbours == 3;
        }
    }
}