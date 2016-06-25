using System;
using Cake.Common.Tools.GitReleaseManager.Close;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx.Create
{
    /// <summary>
    /// The Tfx Create Runner used to create extensions.
    /// </summary>
    public sealed class TfxCreateRunner : TfxTool<TfxCreateSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxCreateRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public TfxCreateRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Creates an extension using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Create(TfxCreateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(TfxCreateSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            return builder;
        }
    }
}