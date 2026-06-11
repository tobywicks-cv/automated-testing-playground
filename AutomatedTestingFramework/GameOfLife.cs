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
            
            if (position + 1 < _data.Length && _data[position + 1] == 1)
            {
                count++;
            }

            if (position - 1 >= 0 && _data[position - 1] == 1)
            {
                count++;
            }

            return count;
        }
    }
    
    
    public static State NextGeneration(State currentGeneration)
    {

        throw new NotImplementedException();
    }
}