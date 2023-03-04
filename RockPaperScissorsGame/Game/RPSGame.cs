using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Moves.Exceptions;
using RockPaperScissorsGame.Core.Players;
using RockPaperScissorsGame.Core.Players.Exceptions;
using RockPaperScissorsGame.Core.Results;
using static RockPaperScissorsGame.Tools.ConsoleTools;

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
            var firstMove = await PlayerMakesAMove(FirstPlayer);
            var secondMove = await PlayerMakesAMove(SecondPlayer);

            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine($"{firstMove} VS {secondMove}");

            await BeforeDisplayingResult();

            var result = firstMove.Against(secondMove);

            DisplayResult(result, FirstPlayer.Name, SecondPlayer.Name);
        }

        private static async Task<RPSMove> PlayerMakesAMove(IPlayer<RPSMove> player)
        {
            var startLine = Console.CursorTop;
            RPSMove move;

            while (true)
            {
                try
                {
                    Console.Write($"{player.Name}, your move: ");
                    move = player.NextMove();
                }
                catch (InvalidMoveAttemptException invalidMove)
                {
                    Console.WriteLine();
                    var intException = invalidMove.InnerException as ParseMoveException;
                    var attemptedMove = intException!.AttemptedMove;

                    Console.WriteLine($"Good attempt, but no. {attemptedMove} is not a thing. Let's try one more time.");
                    await Task.Delay(TimeSpan.FromSeconds(1));

                    continue;
                }
                catch (NextMoveCriticalFailureException)
                {
                    Console.WriteLine($"Something went very wrong. The space-time continuum is broken. {player.Name}, YOU BAST~!!!");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    Console.WriteLine("[Everything explodes]");
                    await Task.Delay(TimeSpan.FromSeconds(1));

                    throw;
                }

                break;
            }

            DeleteLinesToCurrent(startLine);
            Console.WriteLine($"{player.Name}, good choice!");

            return move;
        }

        private static async Task BeforeDisplayingResult()
        {
            Console.WriteLine("Calculating results!");

            var kindOfRandomNumber = DateTime.Now.Ticks % 4 + 1;
            await StartConsoleSpinner(kindOfRandomNumber);
            DeleteCurrentLine();

            Console.WriteLine("Calculification successful!");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        private static void DisplayResult(Result result, string firstPlayerName, string secondPlayerName)
        {
            switch (result)
            {
                case Result.Beats:
                    Console.WriteLine($"{firstPlayerName} won!");

                    break;
                case Result.BeatenBy:
                    Console.WriteLine($"{secondPlayerName} won!");

                    break;
                case Result.Tie:
                    Console.WriteLine($"{firstPlayerName} wo... oh wait, no... it is tie!");
                    break;
            }
        }
    }
}
