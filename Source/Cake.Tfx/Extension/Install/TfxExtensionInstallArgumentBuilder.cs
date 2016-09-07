using System.Collections.Generic;
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
        private readonly FilePath _vsixFilePath;
        private readonly ICollection<string> _accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionInstallArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="vsixFilePath">The FilePath to the VSIX.</param>
        /// <param name="accounts">The accounts to install the extension to.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionInstallArgumentBuilder(ICakeEnvironment environment, FilePath vsixFilePath, ICollection<string> accounts, TfxExtensionInstallSettings settings)
        {
            _environment = environment;
            _vsixFilePath = vsixFilePath;
            _accounts = accounts;
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

            builder.Append("--vsix");
            builder.AppendQuoted(_vsixFilePath.MakeAbsolute(_environment).FullPath);

            builder.Append("--accounts");

            foreach (var account in _accounts)
            {
                builder.AppendQuoted(account);
            }

            TfxArgumentBuilder.GetServerArguments(builder, _settings);
            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}