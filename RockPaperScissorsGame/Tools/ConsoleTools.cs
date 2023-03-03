using System.Diagnostics;

namespace RockPaperScissorsGame.Tools
{
    internal static class ConsoleTools
    {
        public static void DeleteLinesToCurrent(int fromLine)
        {
            var currentLine = Console.CursorTop;

            for (var i = fromLine; i <= currentLine; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, fromLine);
        }

        public static void DeleteCurrentLine() =>
            DeleteLinesToCurrent(Console.CursorTop);

        public static async Task StartConsoleSpinner(long seconds) =>
            await StartConsoleSpinner(TimeSpan.FromSeconds(seconds));

        public static async Task StartConsoleSpinner(TimeSpan duration)
        {
            var counter = 0;
            const int SpinSpeed = 100;

            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.Elapsed < duration)
            {
                switch (counter++)
                {
                    case 0:
                        Console.Write("/");
                        break;
                    case 1:
                        Console.Write("-");
                        break;
                    case 2:
                        Console.Write("\\");
                        break;
                    case 3:
                        Console.Write("|");
                        counter = 0;
                        break;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(SpinSpeed));

                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
