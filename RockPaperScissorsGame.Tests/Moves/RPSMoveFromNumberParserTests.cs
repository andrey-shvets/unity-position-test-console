using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Moves.Exceptions;

namespace RockPaperScissorsGame.Tests.Moves
{
    internal class RPSMoveFromNumberParserTests
    {
        [TestCase("0", RPSMove.Rock)]
        [TestCase("1", RPSMove.Paper)]
        [TestCase("2", RPSMove.Scissors)]
        public void Parse_ForRockPaperScissorsMoveNumber_ReturnsCorrespondingEnum(string moveId, RPSMove expectedMove)
        {
            var parser = new RPSMoveFromNumberParser();

            var move = parser.Parse(moveId);

            move.Should().Be(expectedMove);
        }

        [TestCase("3", RPSMove.Rock)]
        [TestCase("4", RPSMove.Paper)]
        [TestCase("-1", RPSMove.Scissors)]
        public void Parse_ForRockPaperScissorsMoveName_IgnoresCase(string name, RPSMove expectedMove)
        {
            var parser = new RPSMoveFromNumberParser();

            var move = parser.Parse(name);

            move.Should().Be(expectedMove);
        }

        [TestCase("Axe")]
        [TestCase("Rock")]
        [TestCase("paper")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Parse_ForInvalidMoveName_ThrowsParseMoveException(string? name)
        {
            var parser = new RPSMoveFromNumberParser();

            Assert.Throws<ParseMoveException>(() => parser.Parse(name));
        }
    }
}
