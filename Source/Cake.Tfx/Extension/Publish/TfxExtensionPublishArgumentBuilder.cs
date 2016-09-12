using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Publish
{
    /// <summary>
    /// The Argument Builder for the Publish Extension method of the Tfx CLI.
    /// </summary>
    internal sealed class TfxExtensionPublishArgumentBuilder : ITfxArgumentBuilder
    {
        private readonly ICakeEnvironment _environment;
        private readonly TfxExtensionPublishSettings _settings;
        private readonly FilePath _vsixFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionPublishArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="vsixFilePath">The path to the VSIX.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionPublishArgumentBuilder(ICakeEnvironment environment, FilePath vsixFilePath, TfxExtensionPublishSettings settings)
        {
            _environment = environment;
            _vsixFilePath = vsixFilePath;
            _settings = settings;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionPublishArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionPublishArgumentBuilder(ICakeEnvironment environment, TfxExtensionPublishSettings settings)
        {
            _environment = environment;
            _settings = settings;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <returns>A populated <see cref="ProcessArgumentBuilder"/>.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("extension publish");

            if (_vsixFilePath != null)
            {
                builder.Append("--vsix");
                builder.AppendQuoted(_vsixFilePath.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.ShareWith != null && _settings.ShareWith.Count != 0)
            {
                builder.Append("--share-with");

                foreach (var account in _settings.ShareWith)
                {
                    builder.AppendQuoted(account);
                }
            }

            TfxArgumentBuilder.GetServerArguments(builder, _settings);
            TfxArgumentBuilder.GetCreatePublishArgument(builder, _environment, _settings);
            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}
