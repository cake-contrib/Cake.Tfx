using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Install
{
    /// <summary>
    /// Contains settings used by <see cref="TfxExtensionInstallRunner"/>.
    /// </summary>
    public sealed class TfxExtensionInstallSettings : TfxServerSettings
    {
        /// <summary>
        /// Gets or sets the publisher ID instead of what is specified in the manifest.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the extension ID instead of what is specified in the manifest.
        /// </summary>
        public string ExtensionId { get; set; }

        /// <summary>
        /// Gets or sets the Path to an existing VSIX (to publish or query for).
        /// </summary>
        public FilePath Vsix { get; set; }

        /// <summary>
        /// Gets or sets the List of accounts where to install the extension.
        /// </summary>
        public ICollection<string> Accounts { get; set; }
    }
}