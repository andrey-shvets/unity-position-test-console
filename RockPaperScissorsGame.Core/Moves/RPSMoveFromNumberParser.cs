﻿using RockPaperScissorsGame.Core.Moves.Exceptions;

namespace RockPaperScissorsGame.Core.Moves
{
    public class RPSMoveFromNumberParser : IMoveParser<RPSMove>
    {
        private static int TotalMovesCount { get; } = Enum.GetNames<RPSMove>().Length;

        public RPSMove Parse(string? move)
        {
            var isParsed = int.TryParse(move, out var moveId);

            if (!isParsed)
                throw new ParseMoveException(
                    move,
                    $"Failed to parse `{move}` to a number... or let's call it rock-paper-scissors move id, it sounds like it is something serious.");

            var normalizedMoveId = IntToMoveId(moveId);
            return GetMove(normalizedMoveId);
        }

        private static int IntToMoveId(int moveId)
        {
            var normalizedMoveId = moveId % TotalMovesCount;

            if (normalizedMoveId < 0)
                normalizedMoveId += TotalMovesCount;

            return normalizedMoveId;
        }

        private static RPSMove GetMove(int moveId) =>
            moveId switch
            {
                0 => RPSMove.Rock,
                1 => RPSMove.Paper,
                2 => RPSMove.Scissors,
                _ => throw new ParseMoveException($"Can't map '{moveId}' value to rock-paper-scissors move.")
            };
    }
}
