namespace RockPaperScissorsGame.Move
{
    public class RPSMoveParser : IMoveParser
    {
        public RPSMove Parse(string moveName)
        {
            var isParsed = Enum.TryParse<RPSMove>(moveName, ignoreCase: true, out var move);

            if (!isParsed)
                throw new ParseMoveException(moveName,
                    $"Unknown rock-paper-scissors move '{moveName}'. "
                    + "Which is impressive, considering all the moves are in the name of the game. "
                    + "But you tried anyway. "
                    + "And you know what? You do you!");

            return move;
        }
    }
}
