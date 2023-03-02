using RockPaperScissorsGame.Move;
using RockPaperScissorsGame.Move.Exceptions;
using RockPaperScissorsGame.Players.Exceptions;

namespace RockPaperScissorsGame.Players
{
    public class RPSPlayer
    {
        public string Name { get; }
        private IMoveSource MoveSource { get; }
        private IMoveParser MoveParser { get; }

        public RPSPlayer(string name, IMoveSource moveSource, IMoveParser moveParser)
        {
            Name = name;
            MoveSource = moveSource;
            MoveParser = moveParser;
        }

        public RPSMove NextMove()
        {
            try
            {
                var moveName = MoveSource.NextMove();
                var move = MoveParser.Parse(moveName);

                return move;
            }
            catch (ParseMoveException parseException)
            {
                throw new InvalidMoveAttemptException("Failed to parse the move name.", parseException);
            }
            catch (Exception ex)
            {
                throw new NextMoveCriticalFailureException($"Something went wrong during the move generation. Error: {ex.Message}", ex);
            }
        }
    }
}
