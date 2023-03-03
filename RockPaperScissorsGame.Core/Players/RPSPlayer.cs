using RockPaperScissorsGame.Core.Moves;
using RockPaperScissorsGame.Core.Moves.Exceptions;
using RockPaperScissorsGame.Core.Players.Exceptions;

namespace RockPaperScissorsGame.Core.Players
{
    public class RPSPlayer : IPlayer<RPSMove>
    {
        public string Name { get; }
        private IMoveSource MoveSource { get; }
        private IMoveParser<RPSMove> MoveParser { get; }

        public RPSPlayer(string name, IMoveSource moveSource, IMoveParser<RPSMove> moveParser)
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
