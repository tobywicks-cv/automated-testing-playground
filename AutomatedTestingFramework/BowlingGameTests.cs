namespace AutomatedTestingFramework;

public class BowlingGameTests
{
    private readonly BowlingGame _game = new();

    private void RollMany(int rolls, int pins)
    {
        for (int i = 0; i < rolls; i++)
            _game.Roll(pins);
    }

    [Fact]
    public void GutterGame_ScoresZero()
    {
        RollMany(20, 0);
        Assert.Equal(0, _game.Score());
    }

    [Fact]
    public void AllOnes_ScoresTwenty()
    {
        RollMany(20, 1);
        Assert.Equal(20, _game.Score());
    }

    [Fact]
    public void OneSpare_ScoresSixteen()
    {
        _game.Roll(5);
        _game.Roll(5); // spare
        _game.Roll(3);
        RollMany(17, 0);
        Assert.Equal(16, _game.Score());
    }

    [Fact]
    public void OneStrike_ScoresTwentyFour()
    {
        _game.Roll(10); // strike
        _game.Roll(3);
        _game.Roll(4);
        RollMany(16, 0);
        Assert.Equal(24, _game.Score());
    }

    [Fact]
    public void PerfectGame_ScoresThreeHundred()
    {
        RollMany(12, 10);
        Assert.Equal(300, _game.Score());
    }
}
