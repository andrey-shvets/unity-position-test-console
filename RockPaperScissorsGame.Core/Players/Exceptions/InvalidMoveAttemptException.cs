namespace RockPaperScissorsGame.Core.Players.Exceptions
{
    public class InvalidMoveAttemptException : Exception
    {
        public InvalidMoveAttemptException(string message, Exception internalException)
            : base(message, internalException)
        { }
    }
}
