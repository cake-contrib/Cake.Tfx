using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx.Extension.Install
{
    /// <summary>
    /// The Tfx Install Runner used to install extensions.
    /// </summary>
    public sealed class TfxExtensionInstallRunner : TfxTool<TfxExtensionInstallSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionInstallRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public TfxExtensionInstallRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Installs an extension using the specified settings.
        /// </summary>
        /// <param name="vsixFilePath">The path to the VSIX.</param>
        /// <param name="accounts">The accounts to install the extension to.</param>
        /// <param name="settings">The settings.</param>
        public void Install(FilePath vsixFilePath, ICollection<string> accounts, TfxExtensionInstallSettings settings)
        {
            if (vsixFilePath == null)
            {
                throw new ArgumentNullException(nameof(vsixFilePath));
            }

            if (accounts == null || accounts.Count == 0)
            {
                throw new ArgumentNullException(nameof(accounts));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunTfx(settings, new TfxExtensionInstallArgumentBuilder(_environment, vsixFilePath, accounts, settings));
        }
    }
}