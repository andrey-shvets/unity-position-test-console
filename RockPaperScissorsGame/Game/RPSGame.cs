using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Players;
using RockPaperScissorsGame.Core.Results;

namespace RockPaperScissorsGame.Game
{
    internal class RPSGame
    {
        private IPlayer<RPSMove> FirstPlayer { get; }
        private IPlayer<RPSMove> SecondPlayer { get; }

        public RPSGame(IPlayer<RPSMove> firstPlayer, IPlayer<RPSMove> secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }

        public async Task PlayRound()
        {
            Console.Write($"{FirstPlayer.Name}, make your move: ");
            var firstMove = FirstPlayer.NextMove();

            Console.WriteLine($"{FirstPlayer.Name}: {firstMove}");

            Console.Write($"{SecondPlayer.Name}, make your move: ");
            var secondMove = SecondPlayer.NextMove();
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("*****");

            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine($"{firstMove} VS {secondMove}");
            Console.WriteLine("Calculating results!");

            Console.Write("3...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("2...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("5...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("Wait! 5?..");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("1...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("Ah, OK...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("0!");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Calculification successful!");
            await Task.Delay(TimeSpan.FromSeconds(1));

            var result = firstMove.Against(secondMove);

            switch (result)
            {
                case Result.Beats:
                    Console.WriteLine("You win!");
                    break;
                case Result.BeatenBy:
                    Console.WriteLine("You lost!");
                    break;
                case Result.Tie:
                    Console.WriteLine("You wi... oh wait, no... it is tie!");
                    break;
            }
        }
    }
}
