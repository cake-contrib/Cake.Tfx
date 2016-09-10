using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Share
{
    /// <summary>
    /// The Argument Builder for the Share Extension method of the Tfx CLI.
    /// </summary>
    internal sealed class TfxExtensionShareArgumentBuilder : ITfxArgumentBuilder
    {
        private readonly ICakeEnvironment _environment;
        private readonly TfxExtensionShareSettings _settings;
        private readonly FilePath _vsixFilePath;
        private readonly ICollection<string> _shareWith;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionShareArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="vsixFilePath">The FilePath to the VSIX.</param>
        /// <param name="shareWith">The accounts to share the extension to.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionShareArgumentBuilder(ICakeEnvironment environment, FilePath vsixFilePath, ICollection<string> shareWith, TfxExtensionShareSettings settings)
        {
            _environment = environment;
            _vsixFilePath = vsixFilePath;
            _shareWith = shareWith;
            _settings = settings;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <returns>A populated <see cref="ProcessArgumentBuilder"/>.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("extension share");

            builder.Append("--vsix");
            builder.AppendQuoted(_vsixFilePath.MakeAbsolute(_environment).FullPath);

            builder.Append("--share-with");

            foreach (var account in _shareWith)
            {
                builder.AppendQuoted(account);
            }

            TfxArgumentBuilder.GetServerArguments(builder, _settings);
            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}