using GameOfLife;

namespace AutomatedTestingFramework;

public class CellsMatrixTests
{
    [Fact]
    public void LivingCell_WithLessThanTwoNeighbours_Dies()
    {
        var matrix = CreateMatrix((1, 1), (1, 0));

        matrix.Step();

        Assert.False(matrix[1, 1]);
    }

    [Fact]
    public void LivingCell_WithTwoNeighbours_Survives()
    {
        var matrix = CreateMatrix((1, 1), (1, 0), (0, 1));

        matrix.Step();

        Assert.True(matrix[1, 1]);
    }

    [Fact]
    public void LivingCell_WithThreeNeighbours_Survives()
    {
        var matrix = CreateMatrix((1, 1), (1, 0), (0, 1), (2, 1));

        matrix.Step();

        Assert.True(matrix[1, 1]);
    }

    [Fact]
    public void LivingCell_WithMoreThanThreeNeighbours_Dies()
    {
        var matrix = CreateMatrix((1, 1), (1, 0), (0, 1), (2, 1), (1, 2));

        matrix.Step();

        Assert.False(matrix[1, 1]);
    }

    [Fact]
    public void DeadCell_WithExactlyThreeNeighbours_BecomesAlive()
    {
        var matrix = CreateMatrix((1, 0), (0, 1), (2, 1));

        matrix.Step();

        Assert.True(matrix[1, 1]);
    }

    [Fact]
    public void Step_UpdatesAllCellsSimultaneously_BlinkerOscillates()
    {
        var matrix = CreateMatrix((0, 1), (1, 1), (2, 1));

        matrix.Step();

        AssertMatrix(matrix,
            "...",
            "XXX",
            "...");

        matrix.Step();

        AssertMatrix(matrix,
            ".X.",
            ".X.",
            ".X.");
    }

    private static CellsMatrix CreateMatrix(params (int Row, int Col)[] aliveCells)
    {
        var matrix = new CellsMatrix();

        foreach (var (row, col) in aliveCells)
        {
            matrix[row, col] = true;
        }

        return matrix;
    }

    private static void AssertMatrix(CellsMatrix matrix, string row0, string row1, string row2)
    {
        AssertRow(matrix, 0, row0);
        AssertRow(matrix, 1, row1);
        AssertRow(matrix, 2, row2);
    }

    private static void AssertRow(CellsMatrix matrix, int row, string expected)
    {
        Assert.Equal(CellsMatrix.Size, expected.Length);

        for (var col = 0; col < CellsMatrix.Size; col++)
        {
            var expectedAlive = expected[col] == 'X';
            Assert.Equal(expectedAlive, matrix[row, col]);
        }
    }
}
