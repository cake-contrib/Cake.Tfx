using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// Contains settings used by <see cref="TfxExtensionCreateRunner"/>.
    /// </summary>
    public sealed class TfxExtensionCreateSettings : TfxSettings
    {
        /// <summary>
        /// Gets or sets the Root directory to be used when creating extension.
        /// </summary>
        public DirectoryPath Root { get; set; }

        /// <summary>
        /// Gets or sets the List of globs to find manifests.
        /// </summary>
        public ICollection<string> ManifestGlobs { get; set; }

        /// <summary>
        /// Gets or sets the JSON string which is merged into the manifests, overriding any values.
        /// </summary>
        public string Override { get; set; }

        /// <summary>
        /// Gets or sets the path to a JSON file with overrides. This partial manifest will always take precedence over any values in the manifests.
        /// </summary>
        public FilePath OverridesFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to bypass local validation.
        /// </summary>
        public bool BypassValidation { get; set; }

        /// <summary>
        /// Gets or sets a value to use as the publisher ID instead of what is specified in the manifest.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets a value to use as the extension ID instead of what is specified in the manifest.
        /// </summary>
        public string ExtensionId { get; set; }

        /// <summary>
        /// Gets or sets the Path to write the VSIX.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the Root of localization hierarchy
        /// </summary>
        public string LocRoot { get; set; }
    }
}