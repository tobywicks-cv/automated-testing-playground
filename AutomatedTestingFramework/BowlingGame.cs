namespace AutomatedTestingFramework;

public class BowlingGame
{
    private readonly int[] _rolls = new int[21];
    private int _currentRoll;

    public void Roll(int pins) => _rolls[_currentRoll++] = pins;

    public int Score()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (IsStrike(rollIndex))
            {
                score += 10 + StrikeBonus(rollIndex);
                rollIndex += 1;
            }
            else if (IsSpare(rollIndex))
            {
                score += 10 + SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else
            {
                score += FrameScore(rollIndex);
                rollIndex += 2;
            }
        }

        return score;
    }

    private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;
    private bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
    private int StrikeBonus(int rollIndex) => _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
    private int SpareBonus(int rollIndex) => _rolls[rollIndex + 2];
    private int FrameScore(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1];
}
