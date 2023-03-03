namespace RockPaperScissorsGame.Core.Players
{
    public interface IPlayer<out T> where T : Enum
    {
        string Name { get; }

        T NextMove();
    }
}
