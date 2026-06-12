namespace AutomatedTestingFramework;

public class GameOfLife
{
    public HashSet<(int x, int y)> NextGeneration(HashSet<(int x, int y)> liveCells)
    {
        var next = new HashSet<(int x, int y)>();

        foreach (var cell in liveCells)
        {
            var neighbors = CountLiveNeighbors(cell, liveCells);
            if (neighbors == 2 || neighbors == 3)
                next.Add(cell);
        }

        var deadCandidates = liveCells
            .SelectMany(GetNeighbors)
            .Where(c => !liveCells.Contains(c))
            .ToHashSet();

        foreach (var cell in deadCandidates)
        {
            if (CountLiveNeighbors(cell, liveCells) == 3)
                next.Add(cell);
        }

        return next;
    }

    private static IEnumerable<(int x, int y)> GetNeighbors((int x, int y) cell)
    {
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                if ((dx, dy) != (0, 0))
                    yield return (cell.x + dx, cell.y + dy);
    }

    private static int CountLiveNeighbors((int x, int y) cell, HashSet<(int x, int y)> liveCells)
    {
        int count = 0;
        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
                if ((dx, dy) != (0, 0) && liveCells.Contains((cell.x + dx, cell.y + dy)))
                    count++;
        return count;
    }
}
