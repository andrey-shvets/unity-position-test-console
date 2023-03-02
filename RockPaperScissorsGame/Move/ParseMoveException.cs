namespace RockPaperScissorsGame.Move
{
    public class ParseMoveException : Exception
    {
        public string AttemptedMove { get; }

        public ParseMoveException(string attemptedMove) =>
            AttemptedMove = attemptedMove;

        public ParseMoveException(string attemptedMove, string message) : base(message) =>
            AttemptedMove = attemptedMove;
    }
}
