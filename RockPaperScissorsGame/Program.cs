using RockPaperScissorsGame.Game;
using RockPaperScissorsGame.Players;

Console.WriteLine("[The music from the movie Saw is playing]");
Console.WriteLine("You don't know me, but I know you. I want to play a game. Here's what happens if you lose.");
Console.WriteLine("First of all, you're going to be a bit disappointed with the whole situation. And that's about it.");

var firstPlayer = PlayerFactory.CreateHumanPlayer("Player1");
var secondPlayer = PlayerFactory.CreateAIPlayer("Player2");

var rpsGame = new RPSGame(firstPlayer, secondPlayer);

while (true)
{
    await rpsGame.PlayRound();

    Console.WriteLine("Press ESC to stop this madness.");
    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Escape)
        break;
}
