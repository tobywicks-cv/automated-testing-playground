namespace AutomatedTestingFramework;

public class BowlingGame
{
    private readonly List<int> _rolls = new();

    public void Roll(int pinsKnockedDown)
    {
        _rolls.Add(pinsKnockedDown);
    }

    public int Score()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rollIndex >= _rolls.Count) break;

            if (_rolls[rollIndex] == 10) // strike
            {
                score += 10;
                if (rollIndex + 1 < _rolls.Count) score += _rolls[rollIndex + 1];
                if (rollIndex + 2 < _rolls.Count) score += _rolls[rollIndex + 2];
                rollIndex++;
            }
            else
            {
                score += _rolls[rollIndex];
                if (rollIndex + 1 < _rolls.Count) score += _rolls[rollIndex + 1];
                rollIndex += 2;
            }
        }

        return score;
    }
}
