using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Results;

namespace RockPaperScissorsGame.Tests.Results
{
    internal class RPSResultProcessingExtensionsTests
    {
        [TestCase(RPSMove.Rock)]
        [TestCase(RPSMove.Paper)]
        [TestCase(RPSMove.Scissors)]
        public void Against_ReturnsTie_ForSameMove(RPSMove move)
        {
            var result = move.Against(move);

            result.Should().Be(Result.Tie);
        }

        [Test]
        public void PaperBeatsByRock()
        {
            var result = RPSMove.Paper.Against(RPSMove.Rock);

            result.Should().Be(Result.Beats);
        }

        [Test]
        public void RockIsBeatenByPaper()
        {
            var result = RPSMove.Rock.Against(RPSMove.Paper);

            result.Should().Be(Result.Beaten);
        }

        [Test]
        public void RockBeatsScissors()
        {
            var result = RPSMove.Rock.Against(RPSMove.Scissors);

            result.Should().Be(Result.Beats);
        }

        [Test]
        public void ScissorsAreBeatenByRock()
        {
            var result = RPSMove.Scissors.Against(RPSMove.Rock);

            result.Should().Be(Result.Beaten);
        }

        [Test]
        public void ScissorsBeatsPaper()
        {
            var result = RPSMove.Scissors.Against(RPSMove.Paper);

            result.Should().Be(Result.Beats);
        }

        [Test]
        public void PaperIsBeatenByScissors()
        {
            var result = RPSMove.Paper.Against(RPSMove.Scissors);

            result.Should().Be(Result.Beaten);
        }

        [Test]
        public void Against_WithInvalidMove_ThrowsArgumentOutOfRangeException()
        {
            var notRealMove = (RPSMove)99;

            Assert.Multiple(() =>
            {
                Assert.That(() => RPSMove.Rock.Against(notRealMove), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => notRealMove.Against(RPSMove.Paper), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            });
        }
    }
}
