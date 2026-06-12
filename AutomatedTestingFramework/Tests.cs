namespace AutomatedTestingFramework
{
    public class GameOfLifeTests
    {
        private readonly GameOfLife _game = new GameOfLife();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void NextCellState_LivingCellWithFewerThanTwoNeighbours_Dies(int neighbours)
        {
            var isCellAlive = _game.NextCellState(true, neighbours);
            Assert.False(isCellAlive);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void NextCellState_LivingCellWithTwoOrThreeNeighbours_Lives(int neighbours)
        {
            var isCellAlive = _game.NextCellState(true, neighbours);
            Assert.True(isCellAlive);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void NextCellState_LivingCellWithMoreThanThreeNeighbours_Dies(int neighbours)
        {
            var isCellAlive = _game.NextCellState(true, neighbours);
            Assert.False(isCellAlive);
        }

        [Fact]
        public void NextCellState_DeadCellWithThreeNeighbours_BecomesAlive()
        {
            var isCellAlive = _game.NextCellState(false, 3);
            Assert.True(isCellAlive);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void NextCellState_DeadCellWithoutThreeNeighbours_StaysDead(int neighbours)
        {
            var isCellAlive = _game.NextCellState(false, neighbours);
            Assert.False(isCellAlive);
        }
    }
}
