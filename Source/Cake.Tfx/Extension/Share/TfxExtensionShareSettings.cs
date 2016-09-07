using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Share
{
    /// <summary>
    /// Contains settings used by <see cref="TfxExtensionShareRunner"/>.
    /// </summary>
    public sealed class TfxExtensionShareSettings : TfxServerSettings
    {
        /// <summary>
        /// Gets or sets the Path to an existing VSIX (to publish or query for).
        /// </summary>
        public FilePath Vsix { get; set; }

        /// <summary>
        /// Gets or sets the List of accounts where to share the extension.
        /// </summary>
        public ICollection<string> ShareWith { get; set; }
    }
}