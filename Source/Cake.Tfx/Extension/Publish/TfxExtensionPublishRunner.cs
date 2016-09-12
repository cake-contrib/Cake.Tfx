using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx.Extension.Publish
{
    /// <summary>
    /// The Tfx Publish Runner used to publish extensions.
    /// </summary>
    public sealed class TfxExtensionPublishRunner : TfxTool<TfxExtensionPublishSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionPublishRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public TfxExtensionPublishRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Installs an extension using the specified publishSettings.
        /// </summary>
        /// <param name="vsixFilePath">The path to the VSIX.</param>
        /// <param name="publishSettings">The publishSettings.</param>
        public void Publish(FilePath vsixFilePath, TfxExtensionPublishSettings publishSettings)
        {
            if (vsixFilePath == null)
            {
                throw new ArgumentNullException(nameof(vsixFilePath));
            }

            if (publishSettings == null)
            {
                throw new ArgumentNullException(nameof(publishSettings));
            }

            RunTfx(publishSettings, new TfxExtensionPublishArgumentBuilder(_environment, vsixFilePath, publishSettings));
        }

        /// <summary>
        /// Installs an extension using the specified publishSettings.
        /// </summary>
        /// <param name="settings">The publishSettings.</param>
        public void Publish(TfxExtensionPublishSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunTfx(settings, new TfxExtensionPublishArgumentBuilder(_environment, settings));
        }
    }
}