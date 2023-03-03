namespace RockPaperScissorsGame.Core.Moves
{
    public interface IMoveParser<out T> where T : Enum
    {
        T Parse(string? move);
    }
}
