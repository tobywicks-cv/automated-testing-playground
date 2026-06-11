namespace AutomatedTestingFramework;

public class UnitTest1
{
    // a living cell with less than 2 neighbours dies
    // a living cell with 2 or 3 neighbours lives
    // a living cell with more than 3 neighbours dies
    // a dead cell with exactly 3 neighbours becomes a living cell
    
    [Fact]
    public void GivenACellWith1AdjacentNeighbour_WhenGettingNeighbours_ThenReturns1()
    {
        var data = new GameOfLife.State([0, 1]);
        var neighbours = data.GetNeighboursCount(0);
        
        Assert.Equal(1, neighbours);
    }
    
    // todo 
    
    [Fact]
    public async Task DemoVerifyTest()
    {
        await Verifier.Verify(new
        {
            Name = "Test",
            Number = 123
        });
    }
}