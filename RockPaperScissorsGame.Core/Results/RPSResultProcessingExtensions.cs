using RockPaperScissorsGame.Core.Moves;

namespace RockPaperScissorsGame.Core.Results
{
    public static class RPSResultProcessingExtensions
    {
        public static Result Against(this RPSMove move, RPSMove opponentsMove) =>
            (move, opponentsMove) switch
            {
                (RPSMove.Rock, RPSMove.Rock) => Result.Tie,
                (RPSMove.Rock, RPSMove.Scissors) => Result.Beats,
                (RPSMove.Scissors, RPSMove.Rock) => Result.BeatenBy,
                (RPSMove.Paper, RPSMove.Paper) => Result.Tie,
                (RPSMove.Paper, RPSMove.Rock) => Result.Beats,
                (RPSMove.Rock, RPSMove.Paper) => Result.BeatenBy,
                (RPSMove.Scissors, RPSMove.Scissors) => Result.Tie,
                (RPSMove.Scissors, RPSMove.Paper) => Result.Beats,
                (RPSMove.Paper, RPSMove.Scissors) => Result.BeatenBy,
                _ => throw new ArgumentOutOfRangeException(nameof(move), $"Not expected values: {move} VS {opponentsMove}"),
            };
    }
}
