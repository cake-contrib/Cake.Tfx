using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Tfx.Extension.Create;
using Cake.Tfx.Extension.Publish;

namespace Cake.Tfx.Extension
{
    /// <summary>
    /// Contains common settings used by <see cref="TfxExtensionCreateRunner"/> and <see cref="TfxExtensionPublishRunner"/>.
    /// </summary>
    public interface ICreatePublishSettings
    {
        /// <summary>
        /// Gets or sets the Root directory to be used when creating extension.
        /// </summary>
        DirectoryPath Root { get; set; }

        /// <summary>
        /// Gets or sets the List of globs to find manifests.
        /// </summary>
        ICollection<string> ManifestGlobs { get; set; }

        /// <summary>
        /// Gets or sets the JSON string which is merged into the manifests, overriding any values.
        /// </summary>
        string Override { get; set; }

        /// <summary>
        /// Gets or sets the path to a JSON file with overrides. This partial manifest will always take precedence over any values in the manifests.
        /// </summary>
        FilePath OverridesFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to bypass local validation.
        /// </summary>
        bool BypassValidation { get; set; }

        /// <summary>
        /// Gets or sets a value to use as the publisher ID instead of what is specified in the manifest.
        /// </summary>
        string Publisher { get; set; }

        /// <summary>
        /// Gets or sets a value to use as the extension ID instead of what is specified in the manifest.
        /// </summary>
        string ExtensionId { get; set; }

        /// <summary>
        /// Gets or sets the Path to write the VSIX.
        /// </summary>
        DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the Root of localization hierarchy
        /// </summary>
        string LocRoot { get; set; }
    }
}
