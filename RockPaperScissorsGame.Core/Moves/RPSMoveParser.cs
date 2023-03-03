using RockPaperScissorsGame.Core.Moves.Exceptions;

namespace RockPaperScissorsGame.Core.Moves
{
    public class RPSMoveParser : IMoveParser<RPSMove>
    {
        public RPSMove Parse(string? move)
        {
            var isParsed = Enum.TryParse<RPSMove>(move, ignoreCase: true, out var parsedMove);

            if (!isParsed)
            {
                throw new ParseMoveException(
                    move,
                    $"Unknown rock-paper-scissors move '{move}'. "
                    + "Which is impressive, considering all the moves are in the name of the game. "
                    + "But you tried anyway. "
                    + "And you know what? You do you!");
            }

            return parsedMove;
        }
    }
}
