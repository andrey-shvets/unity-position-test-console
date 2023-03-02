﻿using FluentAssertions;
using NSubstitute;
using RockPaperScissorsGame.Move;
using RockPaperScissorsGame.Players;
using RockPaperScissorsGame.Players.Exceptions;

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

            Assert.Throws<InvalidMoveAttemptException>(() => player.NextMove());
        }

        [Test]
        public void NextMove_WhenThereIsUnexpectedError_ThrowsNextMoveCriticalFailureException()
        {
            var moveSource = Substitute.For<IMoveSource>();
            moveSource.NextMove().Returns(_ => throw new Exception("Something went wrong"));
            var parser = new RPSMoveParser();
            var player = new RPSPlayer("Player", moveSource, parser);

            Assert.Throws<NextMoveCriticalFailureException>(() => player.NextMove());
        }
    }
}