namespace AutomatedTestingFramework;

public class GameOfLife
{
    public class State
    {
        private readonly int[] _data;
        private readonly int _width;

        public State(int[] data, int width = 2)
        {
            _data = data;
            _width = width;
        }

        public int GetAliveNeighboursCount(int position)
        {
            var count = 0;
            
            if (LeftAdjacentNeightbourAlive(position)) count++;
            if (RightAdjacentAlive(position)) count++;
            
            if (position + _width < _data.Length && _data[position + _width] == 1)
            {
                count++;
            }

            return count;
        }

        private bool RightAdjacentAlive(int position)
        {
            return position - 1 >= 0 && _data[position - 1] == 1;
        }

        private bool LeftAdjacentNeightbourAlive(int position)
        {
            return position + 1 < _data.Length && _data[position + 1] == 1;
        }
    }
    
    
    public static State NextGeneration(State currentGeneration)
    {

        throw new NotImplementedException();
    }
}