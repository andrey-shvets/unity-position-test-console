using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Players;

namespace RockPaperScissorsGame.Players
{
    internal static class PlayerFactory
    {
        public static RPSPlayer CreateHumanPlayer(string name)
        {
            ValidateName(name);

            return new RPSPlayer(name, new ReadConsoleInputSource(), new RPSMoveParser());
        }

        public static RPSPlayer CreateAIPlayer(string name)
        {
            ValidateName(name);

            return new RPSPlayer(name, new AIFromWebMoveSource(), new RPSMoveFromNumberParser());
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Player name can not be empty.", name);
        }
    }
}
