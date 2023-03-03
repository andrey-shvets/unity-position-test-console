using RockPaperScissorsGame.Core.Players;

namespace RockPaperScissorsGame.Players
{
    internal sealed class ReadConsoleInputSource : IMoveSource
    {
        public string? NextMove() => Console.ReadLine();
    }
}
