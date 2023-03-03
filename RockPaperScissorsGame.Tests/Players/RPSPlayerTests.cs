using System.Net;
using NSubstitute;
using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Players;
using RockPaperScissorsGame.Core.Players.Exceptions;

namespace RockPaperScissorsGame.Tests.Players
{
    internal class RPSPlayerTests
    {
        [Test]
        public void NextMove_ReturnsRockPaperScissorsMove_BasedOnMoveSource()
        {
            var expectedMove = RPSMove.Paper;
            var moveName = expectedMove.ToString();

            var moveSource = Substitute.For<IMoveSource>();
            moveSource.NextMove().Returns(moveName);
            var parser = new RPSMoveParser();
            var player = new RPSPlayer("Player", moveSource, parser);

            var move = player.NextMove();

            move.Should().Be(expectedMove);
        }

        [Test]
        public void NextMove_WhenProvidedWithInvalidMoveName_ThrowsInvalidMoveAttemptException()
        {
            var invalidMoveName = "Invalid move";
            var moveSource = Substitute.For<IMoveSource>();
            moveSource.NextMove().Returns(invalidMoveName);
            var parser = new RPSMoveParser();
            var player = new RPSPlayer("Player", moveSource, parser);

            Assert.That(() => player.NextMove(), Throws.Exception.TypeOf<InvalidMoveAttemptException>());
        }

        [Test]
        public void NextMove_WhenThereIsUnexpectedError_ThrowsNextMoveCriticalFailureException()
        {
            var moveSource = Substitute.For<IMoveSource>();
            _ = moveSource.NextMove().Returns(_ => throw new WebException("Something went wrong... in the Internets!!!"));
            var parser = new RPSMoveParser();
            var player = new RPSPlayer("Player", moveSource, parser);

            Assert.That(() => player.NextMove(), Throws.Exception.TypeOf<NextMoveCriticalFailureException>());
        }
    }
}
