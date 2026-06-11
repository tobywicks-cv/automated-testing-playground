namespace AutomatedTestingFramework;

public class UnitTest1
{
    // a living cell with less than 2 neighbours dies
    // a living cell with 2 or 3 neighbours lives
    // a living cell with more than 3 neighbours dies
    // a dead cell with exactly 3 neighbours becomes a living cell

    [Fact]
    public void GivenACellWithAliveRightAdjacentNeighbour_WhenGettingNeighbours_ThenReturns1()
    {
        var data = new GameOfLife.State([0, 1]);
        var neighbours = data.GetAliveNeighboursCount(0);

        Assert.Equal(1, neighbours);
    }

    [Fact]
    public void GivenACellWithDeadRightAdjacentNeighbour_WhenGettingNeighbours_ThenReturns1()
    {
        var data = new GameOfLife.State([0, 0]);
        var neighbours = data.GetAliveNeighboursCount(0);

        Assert.Equal(0, neighbours);
    }

    [Fact]
    public void GivenACellWithAliveLeftAdjacentNeighbour_WhenGettingNeighbours_ThenReturns1()
    {
        var data = new GameOfLife.State([1, 0]);
        var neighbours = data.GetAliveNeighboursCount(1);

        Assert.Equal(1, neighbours);
    }

    [Fact]
    public void GivenACellWithDeadLeftAdjacentNeighbour_WhenGettingNeighbours_ThenReturns0()
    {
        var data = new GameOfLife.State([0, 0]);
        var neighbours = data.GetAliveNeighboursCount(1);

        Assert.Equal(0, neighbours);
    }

    [Fact]
    public void GivenAliveCellBelow_WhenGettingNeighbours_ThenReturns1()
    {
        var data = new GameOfLife.State(
        [0, 0,
              1, 0], 2);
        var neighbours = data.GetAliveNeighboursCount(0);

        Assert.Equal(1, neighbours);
    }

    
    [Fact]
    public void GivenDeadCellBelow_WhenGettingNeighbours_ThenReturns0()
    {
        var data = new GameOfLife.State(
        [0, 0,
              0, 0], 2);
        var neighbours = data.GetAliveNeighboursCount(0);

        Assert.Equal(0, neighbours);
    }

}