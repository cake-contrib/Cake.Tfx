using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Install
{
    /// <summary>
    /// The Argument Builder for the Install Extension method of the Tfx CLI.
    /// </summary>
    internal sealed class TfxExtensionInstallArgumentBuilder : ITfxArgumentBuilder
    {
        private readonly ICakeEnvironment _environment;
        private readonly TfxExtensionInstallSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionInstallArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionInstallArgumentBuilder(ICakeEnvironment environment, TfxExtensionInstallSettings settings)
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

            builder.Append("extension install");

            if (!string.IsNullOrWhiteSpace(_settings.Publisher))
            {
                builder.Append("--publisher");
                builder.AppendQuoted(_settings.Publisher);
            }

            if (!string.IsNullOrWhiteSpace(_settings.ExtensionId))
            {
                builder.Append("--extension-id");
                builder.AppendQuoted(_settings.ExtensionId);
            }

            if (_settings.Vsix != null)
            {
                builder.Append("--vsix");
                builder.AppendQuoted(_settings.Vsix.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.Accounts != null)
            {
                builder.Append("--accounts");

                foreach (var account in _settings.Accounts)
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