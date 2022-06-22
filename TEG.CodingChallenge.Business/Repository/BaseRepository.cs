using Microsoft.Extensions.Options;
using TEG.CodingChallenge.Infrastructure.Configuration;

namespace TEG.CodingChallenge.Business.Repository
{
    public class BaseRepository
    {
        protected ApplicationSettings ApplicationSettings;

        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="applicationSettings"></param>
        public BaseRepository(IOptions<ApplicationSettings> applicationSettings)
        {
            ApplicationSettings = applicationSettings.Value;
        }
    }
}
