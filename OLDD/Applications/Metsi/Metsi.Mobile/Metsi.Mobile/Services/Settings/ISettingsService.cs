using System.Threading.Tasks;

namespace Metsi.Mobile.Services.Settings
{
    public interface ISettingsService
    {
        /// <summary>
        /// The authorization access token
        /// </summary>
        string AuthAccessToken { get; set; }

        /// <summary>
        /// The authorization identity token
        /// </summary>
        string AuthIdToken { get; set; }

        /// <summary>
        /// Should mockup services be used
        /// </summary>
        bool UseMocks { get; set; }

        /// <summary>
        /// Should a fake location be used
        /// </summary>
        bool UseFakeLocation { get; set; }

        /// <summary>
        /// The latitude of the device
        /// </summary>
        string Latitude { get; set; }

        /// <summary>
        /// The longitude of the device
        /// </summary>
        string Longitude { get; set; }

        /// <summary>
        /// Is gps location allowed
        /// </summary>
        bool AllowGpsLocation { get; set; }

        /// <summary>
        /// Get the value or the default of a specific setting as bool with a key
        /// </summary>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The default value as bool</param>
        /// <returns>The value or default</returns>
        bool GetValueOrDefault(string key, bool defaultValue);

        /// <summary>
        /// Get the value or the default of a specific setting as string with a key
        /// </summary>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The default value as string</param>
        /// <returns>The value or default</returns>
        string GetValueOrDefault(string key, string defaultValue);

        /// <summary>
        /// Adds or updates a value as a bool of a specific setting
        /// </summary>
        /// <param name="key">The settings key</param>
        /// <param name="value">The value to be updated as bool</param>
        Task AddOrUpdateValue(string key, bool value);

        /// <summary>
        /// Adds or updates a value as a string of a specific setting
        /// </summary>
        /// <param name="key">The settings key</param>
        /// <param name="value">The value to be updated as string</param>
        Task AddOrUpdateValue(string key, string value);
    }
}
