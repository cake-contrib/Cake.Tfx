using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// The Argument Builder for the Create Extension method of the Tfx CLI.
    /// </summary>
    internal sealed class TfxExtensionCreateArgumentBuilder : TfxArgumentBuilder<TfxExtensionCreateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionCreateArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        public TfxExtensionCreateArgumentBuilder(ICakeEnvironment environment, TfxExtensionCreateSettings settings)
            : base(environment, settings)
        {
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected override void AddArguments(ProcessArgumentBuilder builder, TfxExtensionCreateSettings settings)
        {
            builder.Append("extension create");

            if (settings.Root != null)
            {
                builder.Append("--root");
                builder.AppendQuoted(settings.Root.MakeAbsolute(Environment).FullPath);
            }

            if (settings.ManifestGlobs != null && settings.ManifestGlobs.Count > 0)
            {
                builder.Append("--manifest-globs");

                foreach (var manifestGlob in settings.ManifestGlobs)
                {
                    builder.AppendQuoted(manifestGlob);
                }
            }

            if (!string.IsNullOrWhiteSpace(settings.Override))
            {
                builder.Append("--override");
                builder.AppendQuoted(settings.Override);
            }

            if (settings.OverridesFile != null)
            {
                builder.Append("--overrides-file");
                builder.AppendQuoted(settings.OverridesFile.MakeAbsolute(Environment).FullPath);
            }

            if (settings.BypassValidation)
            {
                builder.Append("--bypass-validation");
            }

            if (!string.IsNullOrWhiteSpace(settings.Publisher))
            {
                builder.Append("--publisher");
                builder.AppendQuoted(settings.Publisher);
            }

            if (!string.IsNullOrWhiteSpace(settings.ExtensionId))
            {
                builder.Append("--extension-id");
                builder.AppendQuoted(settings.ExtensionId);
            }

            if (settings.OutputPath != null)
            {
                builder.Append("--output-path");
                builder.AppendQuoted(settings.OutputPath.MakeAbsolute(Environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(settings.LocRoot))
            {
                builder.Append("--loc-root");
                builder.AppendQuoted(settings.LocRoot);
            }
        }
    }
}