namespace AutomatedTestingFramework;

public class GameOfLife
{
    public class State
    {
        private readonly int[] _data;

        public State(int[] data)
        {
            _data = data;
        }

        public int GetNeighboursCount(int position)
        {
            var count = 0;
            
            if (position + 1 < _data.Length && _data[position + 1] == 1)
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