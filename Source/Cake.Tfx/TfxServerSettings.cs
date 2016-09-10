namespace Cake.Tfx
{
    /// <summary>
    /// Contains the common server settings used by some commands in Tfx.
    /// </summary>
    public abstract class TfxServerSettings : TfxSettings
    {
        /// <summary>
        /// Gets or sets the method of authentication.
        /// </summary>
        public TfxAuthType AuthType { get; set; }

        /// <summary>
        /// Gets or sets the Username to use for basic authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password to use for basic authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Personal Access Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the URL to the VSS Marketplace
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets the proxy server for HTTP traffic
        /// </summary>
        public string Proxy { get; set; }
    }
}