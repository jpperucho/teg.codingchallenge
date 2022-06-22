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
    /// Event repository.
    /// </summary>
    public class EventRepository : BaseRepository, IEventRepository
    {
        private ILogger<EventRepository> _logger;

        public IEnumerable<Event> Events { get; private set; }

        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="applicationSettings"></param>
        /// <param name="logger"></param>
        public EventRepository(IOptions<ApplicationSettings> applicationSettings, ILogger<EventRepository> logger)  : base(applicationSettings)
        {
            _logger = logger;

            // Retrieve events.
            Events = Get();
        }

        /// <summary>
        /// Get event.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Event> Get()
        {
            try
            {
                using var httpClient = new HttpClient { BaseAddress = new Uri(ApplicationSettings.DatasetUrl) };

                var result = httpClient.GetAsync("/events/event-data.json").Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = result.Content.ReadAsStringAsync().Result;

                    var parsedObject = JObject.Parse(content);

                    var data = JsonConvert.DeserializeObject<List<Event>>(parsedObject["events"].ToString());

                    if (data != null)
                    {
                        return data;
                    }
                }

                return new List<Event>();
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
