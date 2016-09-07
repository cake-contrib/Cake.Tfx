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

            if (_settings.Root != null)
            {
                builder.Append("--root");
                builder.AppendQuoted(_settings.Root.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.ManifestGlobs != null && _settings.ManifestGlobs.Count > 0)
            {
                builder.Append("--manifest-globs");

                foreach (var manifestGlob in _settings.ManifestGlobs)
                {
                    builder.AppendQuoted(manifestGlob);
                }
            }

            if (!string.IsNullOrWhiteSpace(_settings.Override))
            {
                builder.Append("--override");
                builder.AppendQuoted(_settings.Override);
            }

            if (_settings.OverridesFile != null)
            {
                builder.Append("--overrides-file");
                builder.AppendQuoted(_settings.OverridesFile.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.BypassValidation)
            {
                builder.Append("--bypass-validation");
            }

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

            if (_settings.OutputPath != null)
            {
                builder.Append("--output-path");
                builder.AppendQuoted(_settings.OutputPath.MakeAbsolute(_environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(_settings.LocRoot))
            {
                builder.Append("--loc-root");
                builder.AppendQuoted(_settings.LocRoot);
            }

            TfxArgumentBuilder.GetCommonArguments(builder, _settings);

            return builder;
        }
    }
}