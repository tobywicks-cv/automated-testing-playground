namespace AutomatedTestingFramework;

public class GameOfLifeTests
{
    private readonly GameOfLife _game = new();

    [Fact]
    public void DeadCell_WithNoNeighbors_StaysDead()
    {
        var liveCells = new HashSet<(int, int)>();

        var result = _game.NextGeneration(liveCells);

        Assert.Empty(result);
    }

    [Fact]
    public void LiveCell_WithFewerThanTwoNeighbors_Dies()
    {
        var liveCells = new HashSet<(int, int)> { (0, 0) };

        var result = _game.NextGeneration(liveCells);

        Assert.Empty(result);
    }

    [Fact]
    public void LiveCell_WithTwoOrThreeNeighbors_Survives()
    {
        // (0,0) has exactly 2 live neighbors: (1,0) and (0,1)
        var liveCells = new HashSet<(int, int)> { (0, 0), (1, 0), (0, 1) };

        var result = _game.NextGeneration(liveCells);

        Assert.Contains((0, 0), result);
    }

    [Fact]
    public void LiveCell_WithMoreThanThreeNeighbors_Dies()
    {
        // (0,0) has 4 live neighbors
        var liveCells = new HashSet<(int, int)> { (0, 0), (1, 0), (-1, 0), (0, 1), (0, -1) };

        var result = _game.NextGeneration(liveCells);

        Assert.DoesNotContain((0, 0), result);
    }

    [Fact]
    public void DeadCell_WithExactlyThreeNeighbors_BecomesAlive()
    {
        // (0,0) is dead, but its neighbors (1,0), (0,1), (1,1) are all alive
        var liveCells = new HashSet<(int, int)> { (1, 0), (0, 1), (1, 1) };

        var result = _game.NextGeneration(liveCells);

        Assert.Contains((0, 0), result);
    }

    [Fact]
    public void Blinker_OscillatesEveryGeneration()
    {
        var horizontal = new HashSet<(int, int)> { (0, -1), (0, 0), (0, 1) };
        var vertical   = new HashSet<(int, int)> { (-1, 0), (0, 0), (1, 0) };

        var gen1 = _game.NextGeneration(horizontal);
        var gen2 = _game.NextGeneration(gen1);

        Assert.Equal(vertical, gen1);
        Assert.Equal(horizontal, gen2);
    }
}
