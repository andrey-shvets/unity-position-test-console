﻿namespace RockPaperScissorsGame.Players.Exceptions
{
    public class NextMoveCriticalFailureException : Exception
    {
        public NextMoveCriticalFailureException(string message, Exception internalException)
            : base(message, internalException)
        { }
    }
}
