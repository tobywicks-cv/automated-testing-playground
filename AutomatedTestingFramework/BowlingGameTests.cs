using BowlingGame;

namespace AutomatedTestingFramework
{
    public class BowlingGameTests
    {
        private readonly Game _game = new();

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
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
        public void Spare_BonusIsNextRoll()
        {
            _game.Roll(5);
            _game.Roll(5); // spare
            _game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, _game.Score()); // 10+3 + 3
        }

        [Fact]
        public void Strike_BonusIsNextTwoRolls()
        {
            _game.Roll(10); // strike
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, _game.Score()); // 10+3+4 + 3+4
        }

        [Fact]
        public void PerfectGame_Scores300()
        {
            RollMany(12, 10);
            Assert.Equal(300, _game.Score());
        }

        [Fact]
        public void TenthFrameSpare_AllowsOneExtraRoll()
        {
            RollMany(18, 0);
            _game.Roll(5);
            _game.Roll(5); // spare in 10th
            _game.Roll(7); // bonus roll
            Assert.Equal(17, _game.Score());
        }

        [Fact]
        public void TenthFrameStrike_AllowsTwoExtraRolls()
        {
            RollMany(18, 0);
            _game.Roll(10); // strike in 10th
            _game.Roll(3);
            _game.Roll(6); // two bonus rolls
            Assert.Equal(19, _game.Score());
        }

        [Fact]
        public void MultipleSpares_ScoresCorrectly()
        {
            // 5+5 spare, 5+5 spare, then all zeros — tests chained spare bonuses
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            RollMany(16, 0);
            Assert.Equal(25, _game.Score()); // (10+5) + (10+0) + 0*16
        }

        [Fact]
        public void MultipleStrikes_ScoresCorrectly()
        {
            // Three strikes followed by zeros — tests chained strike bonuses
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(10);
            RollMany(14, 0);
            Assert.Equal(60, _game.Score()); // (10+10+10) + (10+10+0) + (10+0+0)
        }
    }
}
