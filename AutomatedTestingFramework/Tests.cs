namespace AutomatedTestingFramework;

public class BowlingGameTests
{
    [Fact]
    public void GivenGameStarted_WhenPlayRollsNotAllPins_ThenScoreReturnedIsPinsKnockedDown()
    {
        var game = new BowlingGame();
        game.Roll(8);
        
        var score = game.Score();
        Assert.Equal(8, score);
    }
    
    [Fact]
    public void GivenFrame1WasStrike_WhenPlayerKnocks8Pins_ThenFrame2ScoreIsAddedToFrame1Score()
    {
        var game = new BowlingGame();
        game.Roll(10);
        game.Roll(8);
        var score = game.Score();
        
        Assert.Equal(26, score);
    }
}