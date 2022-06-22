using System.Text.Json.Serialization;

namespace TEG.CodingChallenge.Domain.Entities
{
    /// <summary>
    /// Venue entity.
    /// </summary>
    public class Venue : Base
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

    }
}
