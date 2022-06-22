using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TEG.CodingChallenge.Business.Interface.Repository;
using TEG.CodingChallenge.Domain.Entities;
using TEG.CodingChallenge.Infrastructure.Configuration;

namespace TEG.CodingChallenge.Business.Repository
{
    /// <summary>
    /// Venue repository.
    /// </summary>
    public class VenueRepository : BaseRepository, IVenueRepository
    {   
        private ILogger<VenueRepository> _logger;

        public IEnumerable<Venue> Venues { get; private set; }

        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="applicationSettings"></param>
        /// <param name="logger"></param>
        public VenueRepository(IOptions<ApplicationSettings> applicationSettings, ILogger<VenueRepository> logger) : base(applicationSettings)
        {
            _logger = logger;

            // Retrieve venues.
            Venues = Get();
        }

        /// <summary>
        /// Get venues.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Venue> Get()
        {
            try
            {
                using var httpClient = new HttpClient { BaseAddress = new Uri(ApplicationSettings.DatasetUrl) };
                
                var result = httpClient.GetAsync("/events/event-data.json").Result;

                if(result.StatusCode == HttpStatusCode.OK)
                {
                    var content =  result.Content.ReadAsStringAsync().Result;

                    var parsedObject = JObject.Parse(content);

                    var data = JsonConvert.DeserializeObject<List<Venue>>(parsedObject["venues"].ToString());

                    if(data != null)
                    {
                        return data;
                    }
                }

                return new List<Venue>();
            }
            catch (Exception ex)
            {
                // TODO: Better error exception.
                _logger.LogError(ex, "An error has occured");

                throw;
            }
        }
    }
}
