using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx.Extension.Share
{
    /// <summary>
    /// The Tfx Share Runner used to share extensions.
    /// </summary>
    public sealed class TfxExtensionShareRunner : TfxTool<TfxExtensionShareSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionShareRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public TfxExtensionShareRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Installs an extension using the specified shareSettings.
        /// </summary>
        /// <param name="vsixFilePath">The path to the VSIX.</param>
        /// <param name="shareWith">The accounts to share the extension to.</param>
        /// <param name="shareSettings">The shareSettings.</param>
        public void Share(FilePath vsixFilePath, ICollection<string> shareWith, TfxExtensionShareSettings shareSettings)
        {
            if (vsixFilePath == null)
            {
                throw new ArgumentNullException(nameof(vsixFilePath));
            }

            if (shareWith == null || shareWith.Count == 0)
            {
                throw new ArgumentNullException(nameof(shareWith));
            }

            if (shareSettings == null)
            {
                throw new ArgumentNullException(nameof(shareSettings));
            }

            RunTfx(shareSettings, new TfxExtensionShareArgumentBuilder(_environment, vsixFilePath, shareWith, shareSettings));
        }
    }
}