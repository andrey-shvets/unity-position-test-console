using RockPaperScissorsGame.Game;
using static RockPaperScissorsGame.Tools.GameHelper;

Console.WriteLine("[The music from the movie Saw is playing]");
Console.WriteLine("You don't know me, but I know you. I want to play a game. Here's what happens if you lose.");
Console.WriteLine("First of all, you're going to be a bit disappointed with the whole situation.");
Console.WriteLine("I mean, it is not rocket surgery. How hard can it be?");
Console.WriteLine("Press something to continue...");
Console.ReadKey(true);

Console.WriteLine("Welcome to the game ROCK-PAPER-SCISSORS-TIGE... Wait! Why the cage is open?.. Hold on a second...");
await Task.Delay(TimeSpan.FromSeconds(2));
Console.WriteLine("It is fine. Everything is fine.");
Console.WriteLine("I mean... Welcome to the game ROCK-PAPER-SCISSORS and nothing else, there is no tiger on the loose...");
Console.WriteLine("Who told you that?!.. Yeah, there is nothing to worry about.");
await Task.Delay(TimeSpan.FromSeconds(2));

var (firstPlayer, secondPlayer) = CreatePlayers();

Console.WriteLine("Let's GO!");

var rpsGame = new RPSGame(firstPlayer, secondPlayer);

while (true)
{
    await rpsGame.PlayRound();

    Console.WriteLine("Press ESC to stop this madness.");
    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Escape)
        break;
}
