namespace RockPaperScissorsGame.Core.Moves
{
    public interface IMoveParser
    {
        RPSMove Parse(string? moveName);
    }
}
