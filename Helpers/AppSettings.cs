namespace WebApi.Helpers
{
    /// <summary>
    /// AppSettings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        /// <value>
        /// The secret.
        /// </value>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the token expiry in days.
        /// </summary>
        /// <value>
        /// The token expiry in days.
        /// </value>
        public int TokenExpiryInDays { get; set; }
    }
}