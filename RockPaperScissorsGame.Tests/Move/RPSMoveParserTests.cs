using FluentAssertions;
using RockPaperScissorsGame.Move;

namespace RockPaperScissorsGame.Tests.Move
{
    internal class RPSMoveParserTests
    {
        [TestCase("Rock", RPSMove.Rock)]
        [TestCase("Paper", RPSMove.Paper)]
        [TestCase("Scissors", RPSMove.Scissors)]
        public void Parse_ForRockPaperScissorsMoveName_ReturnsCorrespondingEnum(string name, RPSMove expectedMove)
        {
            var parser = new RPSMoveParser();

            var move = parser.Parse(name);

            move.Should().Be(expectedMove);
        }

        [TestCase("rock", RPSMove.Rock)]
        [TestCase("PAPER", RPSMove.Paper)]
        [TestCase("ScIsSoRs", RPSMove.Scissors)]
        public void Parse_ForRockPaperScissorsMoveName_IgnoresCase(string name, RPSMove expectedMove)
        {
            var parser = new RPSMoveParser();

            var move = parser.Parse(name);

            move.Should().Be(expectedMove);
        }

        [TestCase("Axe")]
        [TestCase("Rock.")]
        [TestCase("-Paper")]
        public void Parse_ForInvalidMoveName_ThrowsParseMoveException(string name)
        {
            var parser = new RPSMoveParser();

            Assert.Throws<ParseMoveException>(() => parser.Parse(name));
        }
    }
}
