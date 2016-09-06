using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx
{
    /// <summary>
    /// Base class for all Tfx related tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class TfxTool<TSettings> : Tool<TSettings>
        where TSettings : TfxSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfxTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        protected TfxTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "Tfx";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "tfx.cmd", "tfx" };
        }

        /// <summary>
        /// Runs the TFX tool with the specified settings.
        /// </summary>
        /// <typeparam name="TBuilder">The TFX argument builder.</typeparam>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The builder.</param>
        protected void RunTfx<TBuilder>(TSettings settings, TBuilder builder)
            where TBuilder : ITfxArgumentBuilder
        {
            Run(settings, builder.GetArguments());
        }
    }
}