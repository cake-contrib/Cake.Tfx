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
        private readonly TfxExtensionCreateSettings _createSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionCreateArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="createSettings">The createSettings.</param>
        public TfxExtensionCreateArgumentBuilder(ICakeEnvironment environment, TfxExtensionCreateSettings createSettings)
        {
            _environment = environment;
            _createSettings = createSettings;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <returns>A populated <see cref="ProcessArgumentBuilder"/>.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("extension create");

            if (_createSettings.Root != null)
            {
                builder.Append("--root");
                builder.AppendQuoted(_createSettings.Root.MakeAbsolute(_environment).FullPath);
            }

            if (_createSettings.ManifestGlobs != null && _createSettings.ManifestGlobs.Count > 0)
            {
                builder.Append("--manifest-globs");

                foreach (var manifestGlob in _createSettings.ManifestGlobs)
                {
                    builder.AppendQuoted(manifestGlob);
                }
            }

            if (!string.IsNullOrWhiteSpace(_createSettings.Override))
            {
                builder.Append("--override");
                builder.AppendQuoted(_createSettings.Override);
            }

            if (_createSettings.OverridesFile != null)
            {
                builder.Append("--overrides-file");
                builder.AppendQuoted(_createSettings.OverridesFile.MakeAbsolute(_environment).FullPath);
            }

            if (_createSettings.BypassValidation)
            {
                builder.Append("--bypass-validation");
            }

            if (!string.IsNullOrWhiteSpace(_createSettings.Publisher))
            {
                builder.Append("--publisher");
                builder.AppendQuoted(_createSettings.Publisher);
            }

            if (!string.IsNullOrWhiteSpace(_createSettings.ExtensionId))
            {
                builder.Append("--extension-id");
                builder.AppendQuoted(_createSettings.ExtensionId);
            }

            if (_createSettings.OutputPath != null)
            {
                builder.Append("--output-path");
                builder.AppendQuoted(_createSettings.OutputPath.MakeAbsolute(_environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(_createSettings.LocRoot))
            {
                builder.Append("--loc-root");
                builder.AppendQuoted(_createSettings.LocRoot);
            }

            TfxArgumentBuilder.GetCommonArguments(builder, _createSettings);

            return builder;
        }
    }
}