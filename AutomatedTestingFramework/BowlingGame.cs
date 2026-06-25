namespace AutomatedTestingFramework;

public class BowlingGame
{
    private int _score;

    public void Roll(int pinsKnockedDown)
    {
        _score += pinsKnockedDown;
    }

    public int Score()
    {
        return _score;
    }
}