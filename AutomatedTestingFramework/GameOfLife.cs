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
            
            if (LeftAlive(position)) count++;
            if (RightAlive(position)) count++;
            if (BelowAlive(position))
            {
                count++;
            }
            
            if (AboveAlive(position))
            {
                count++;
            }

            return count;
        }

        private bool AboveAlive(int position)
        {
            return position - _width >= 0 && _data[position - _width] == 1;
        }

        private bool BelowAlive(int position)
        {
            return position + _width < _data.Length && _data[position + _width] == 1;
        }

        private bool RightAlive(int position)
        {
            return position - 1 >= 0 && _data[position - 1] == 1;
        }

        private bool LeftAlive(int position)
        {
            return position + 1 < _data.Length && _data[position + 1] == 1;
        }
    }
    
    
    public static State NextGeneration(State currentGeneration)
    {

        throw new NotImplementedException();
    }
}