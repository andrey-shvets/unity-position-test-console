namespace RockPaperScissorsGame.Move
{
    public interface IMoveParser
    {
        RPSMove Parse(string moveName);
    }
}
