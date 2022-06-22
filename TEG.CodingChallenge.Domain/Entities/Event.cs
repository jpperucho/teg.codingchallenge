using System.Text.Json.Serialization;

namespace TEG.CodingChallenge.Domain.Entities
{
    /// <summary>
    /// Event entity.
    /// </summary>
    public class Event : Base
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }


        [JsonPropertyName("venueId")]
        public int VenueId { get; set; }
    }
}
