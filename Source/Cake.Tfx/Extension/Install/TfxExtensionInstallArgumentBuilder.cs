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
        private readonly TfxExtensionInstallSettings _installSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionInstallArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="installSettings">The installSettings.</param>
        public TfxExtensionInstallArgumentBuilder(ICakeEnvironment environment, TfxExtensionInstallSettings installSettings)
        {
            _environment = environment;
            _installSettings = installSettings;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <returns>A populated <see cref="ProcessArgumentBuilder"/>.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("extension install");

            if (!string.IsNullOrWhiteSpace(_installSettings.Publisher))
            {
                builder.Append("--publisher");
                builder.AppendQuoted(_installSettings.Publisher);
            }

            if (!string.IsNullOrWhiteSpace(_installSettings.ExtensionId))
            {
                builder.Append("--extension-id");
                builder.AppendQuoted(_installSettings.ExtensionId);
            }

            if (_installSettings.Vsix != null)
            {
                builder.Append("--vsix");
                builder.AppendQuoted(_installSettings.Vsix.MakeAbsolute(_environment).FullPath);
            }

            if (_installSettings.Accounts != null)
            {
                builder.Append("--accounts");

                foreach (var account in _installSettings.Accounts)
                {
                    builder.AppendQuoted(account);
                }
            }

            TfxArgumentBuilder.GetServerArguments(builder, _installSettings);
            TfxArgumentBuilder.GetCommonArguments(builder, _installSettings);

            return builder;
        }
    }
}