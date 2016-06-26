using System.Collections.Generic;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// Contains settings used by <see cref="TfxExtensionCreateRunner"/>.
    /// </summary>
    public sealed class TfxExtensionCreateSettings : TfxCommonSettings
    {
        public DirectoryPath Root { get; set; }

        public ICollection<string> ManifestGlobs { get; set; }

        public string Override { get; set; }

        public FilePath OverridesFile { get; set; }

        public bool BypassValidation { get; set; }

        public string Publisher { get; set; }

        public string ExtensionId { get; set; }

        public DirectoryPath OutputPath { get; set; }

        public string LocRoot { get; set; }
    }
}