using RestSharp;
using RockPaperScissorsGame.Core.Players;

namespace RockPaperScissorsGame.Players
{
    internal sealed class AIFromWebMoveSource : IMoveSource
    {
        private const string RandomNumberApiUrl = $"http://www.randomnumberapi.com/api/v1.0/";

        public string? NextMove()
        {
            var client = new RestClient(RandomNumberApiUrl);
            var request = new RestRequest("random")
                .AddParameter("min", 0)
                .AddParameter("max", 2)
                .AddParameter("count", 1);

            var randomNumbers = client.Get<int[]>(request);

            if (randomNumbers is null || !randomNumbers.Any())
                throw new InvalidOperationException($"Failed to retrieve a random number from the {RandomNumberApiUrl}");

            return randomNumbers.First().ToString();
        }
    }
}
