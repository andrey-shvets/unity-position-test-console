using RockPaperScissorsGame.Core.Players;
using RockPaperScissorsGame.Players;

namespace RockPaperScissorsGame.Tools
{
    internal static class GameHelper
    {
        public static (RPSPlayer FirstPlayer, RPSPlayer SecondPlayer) CreatePlayers(string firstPlayerName = "Player1", string secondPlayerName = "Player2")
        {
            Console.WriteLine("Press ENTER if you want to use default game configuration.");
            var choice = Console.ReadKey(true).Key;

            if (choice == ConsoleKey.Enter)
            {
                Console.WriteLine($"{firstPlayerName} is a Human, {secondPlayerName} is a AI and not a tiger in disguise.");
                return (PlayerFactory.CreateHumanPlayer(firstPlayerName), PlayerFactory.CreateAIPlayer(secondPlayerName));
            }

            var firstPlayer = CreatePlayer(firstPlayerName);
            var secondPlayer = CreatePlayer(secondPlayerName);

            return (firstPlayer, secondPlayer);
        }

        public static RPSPlayer CreatePlayer(string defaultName)
        {
            Console.WriteLine("Choose player's type: (H)uman, (A)I");

            while (true)
            {
                var choice = Console.ReadKey(true).Key;

                if (choice == ConsoleKey.H)
                {
                    var name = ChosePlayerName(defaultName);
                    return PlayerFactory.CreateHumanPlayer(name);
                }

                if (choice == ConsoleKey.A)
                {
                    Console.WriteLine($"Welcome to the rock-paper-scissors-and-definitely-no-tigers game, {defaultName}!");
                    return PlayerFactory.CreateAIPlayer(defaultName);
                }
            }
        }

        private static string ChosePlayerName(string defaultName)
        {
            Console.WriteLine("Please enter the name of the player: ");
            var chosenName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(chosenName))
                Console.WriteLine($"OK. {defaultName} it is.");
            else if (string.Equals(defaultName, chosenName))
                Console.WriteLine("Good choice!");
            else if (string.Equals(defaultName, chosenName, StringComparison.InvariantCultureIgnoreCase))
                Console.WriteLine($"Not a bad choice, but let's improve it a bit. How about '{defaultName}'?");
            else
                Console.WriteLine("Are you sure? Yeah, no. I think everyone will be confused by this. "
                                  + "Let's use our neural network to come up with a better name! "
                                  + $"Beep-boop... calculating... calculating... {defaultName}! Much better!");

            return defaultName;
        }
    }
}
