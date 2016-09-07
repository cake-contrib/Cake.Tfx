using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// The Argument Builder for the Create Extension method of the Tfx CLI.
    /// </summary>
    internal sealed class TfxExtensionCreateArgumentBuilder : ITfxArgumentBuilder
    {
        private readonly ICakeEnvironment _environment;
        private readonly TfxExtensionCreateSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionCreateArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionCreateArgumentBuilder(ICakeEnvironment environment, TfxExtensionCreateSettings settings)
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

            builder.Append("extension create");

            TfxArgumentBuilder.GetCreatePublishArgument(builder, _environment, _settings);
            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}