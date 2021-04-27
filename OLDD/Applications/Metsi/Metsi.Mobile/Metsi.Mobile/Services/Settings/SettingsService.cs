using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Metsi.Mobile.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        #region Setting Constants

        private const string AccessToken = "access_token";
        private const string IdToken = "id_token";
        private const string IdUseMocks = "use_mocks";
        private const string IdIdentityBase = "url_base";
        private const string IdGatewayMarketingBase = "url_marketing";
        private const string IdGatewayShoppingBase = "url_shopping";
        private const string IdUseFakeLocation = "use_fake_location";
        private const string IdLatitude = "latitude";
        private const string IdLongitude = "longitude";
        private const string IdAllowGpsLocation = "allow_gps_location";
        private readonly string AccessTokenDefault = string.Empty;
        private readonly string IdTokenDefault = string.Empty;
        private readonly bool UseMocksDefault = true;
        private readonly bool UseFakeLocationDefault = false;
        private readonly bool AllowGpsLocationDefault = false;
        private readonly double FakeLatitudeDefault = 47.604610d;
        private readonly double FakeLongitudeDefault = -122.315752d;

        #endregion

        #region Settings Properties

        /// <summary>
        /// The authorization access token
        /// </summary>
        public string AuthAccessToken
        {
            get => GetValueOrDefault(AccessToken, AccessTokenDefault);
            set => AddOrUpdateValue(AccessToken, value);
        }

        /// <summary>
        /// The authorization identity token
        /// </summary>
        public string AuthIdToken
        {
            get => GetValueOrDefault(IdToken, IdTokenDefault);
            set => AddOrUpdateValue(IdToken, value);
        }

        /// <summary>
        /// Should mockup services be used
        /// </summary>
        public bool UseMocks
        {
            get => GetValueOrDefault(IdUseMocks, UseMocksDefault);
            set => AddOrUpdateValue(IdUseMocks, value);
        }

        /// <summary>
        /// Should a fake location be used
        /// </summary>
        public bool UseFakeLocation
        {
            get => GetValueOrDefault(IdUseFakeLocation, UseFakeLocationDefault);
            set => AddOrUpdateValue(IdUseFakeLocation, value);
        }

        /// <summary>
        /// The latitude of the device
        /// </summary>
        public string Latitude
        {
            get => GetValueOrDefault(IdLatitude, FakeLatitudeDefault.ToString());
            set => AddOrUpdateValue(IdLatitude, value);
        }

        /// <summary>
        /// The longitude of the device
        /// </summary>
        public string Longitude
        {
            get => GetValueOrDefault(IdLongitude, FakeLongitudeDefault.ToString());
            set => AddOrUpdateValue(IdLongitude, value);
        }

        /// <summary>
        /// Is gps location allowed
        /// </summary>
        public bool AllowGpsLocation
        {
            get => GetValueOrDefault(IdAllowGpsLocation, AllowGpsLocationDefault);
            set => AddOrUpdateValue(IdAllowGpsLocation, value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the value or the default of a specific setting as bool with a key
        /// </summary>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The default value as bool</param>
        /// <returns>The value or default</returns>
        public Task AddOrUpdateValue(string key, bool value) => AddOrUpdateValueInternal(key, value);

        /// <summary>
        /// Get the value or the default of a specific setting as string with a key
        /// </summary>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The default value as string</param>
        /// <returns>The value or default</returns>
        public Task AddOrUpdateValue(string key, string value) => AddOrUpdateValueInternal(key, value);

        /// <summary>
        /// Adds or updates a value as a bool of a specific setting
        /// </summary>
        /// <param name="key">The settings key</param>
        /// <param name="value">The value to be updated as bool</param>
        public bool GetValueOrDefault(string key, bool defaultValue) => GetValueOrDefaultInternal(key, defaultValue);

        /// <summary>
        /// Adds or updates a value as a string of a specific setting
        /// </summary>
        /// <param name="key">The settings key</param>
        /// <param name="value">The value to be updated as string</param>
        public string GetValueOrDefault(string key, string defaultValue) => GetValueOrDefaultInternal(key, defaultValue);

        #endregion

        #region Internal Implementation

        /// <summary>
        /// The internal implementation of the add or update value method
        /// </summary>
        /// <typeparam name="T">The type of the value of the setting</typeparam>
        /// <param name="key">The setting key</param>
        /// <param name="value">The new setting value</param>
        async Task AddOrUpdateValueInternal<T>(string key, T value)
        {
            if (value == null)
            {
                await Remove(key);
            }

            Application.Current.Properties[key] = value;
            try
            {
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
            }
        }

        /// <summary>
        /// The internal generic implementation of the get value method
        /// </summary>
        /// <typeparam name="T">The type of the value of the setting</typeparam>
        /// <param name="key">The setting key</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The retrieved value</returns>
        T GetValueOrDefaultInternal<T>(string key, T defaultValue = default(T))
        {
            object value = null;
            if (Application.Current.Properties.ContainsKey(key))
            {
                value = Application.Current.Properties[key];
            }
            return null != value ? (T)value : defaultValue;
        }

        async Task Remove(string key)
        {
            try
            {
                if (Application.Current.Properties[key] != null)
                {
                    Application.Current.Properties.Remove(key);
                    await Application.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove: " + key, " Message: " + ex.Message);
            }
        }

        #endregion
    }
}