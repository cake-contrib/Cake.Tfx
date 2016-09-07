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

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionShareArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionShareArgumentBuilder(ICakeEnvironment environment, TfxExtensionShareSettings settings)
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

            builder.Append("extension share");

            if (_settings.Vsix != null)
            {
                builder.Append("--vsix");
                builder.AppendQuoted(_settings.Vsix.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.ShareWith != null)
            {
                builder.Append("--share-with");

                foreach (var account in _settings.ShareWith)
                {
                    builder.AppendQuoted(account);
                }
            }

            TfxArgumentBuilder.GetServerArguments(builder, _settings);
            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}