using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// The Argument Builder for the Create Extension method of the Tfx CLI.
    /// </summary>
    internal class TfxExtensionCreateArgumentBuilder : TfxArgumentBuilder<TfxExtensionCreateSettings>
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
        /// Fetch the populated Argument Builder
        /// </summary>
        /// <returns>An instance of <see cref="ProcessArgumentBuilder"/> for this command.</returns>
        public ProcessArgumentBuilder Get()
        {
            this.AppendExtensionCreateArguments();
            this.AppendCommonArguments();

            return this.Builder;
        }

        private void AppendExtensionCreateArguments()
        {
            this.Builder.Append("extension create");

            if (this.Settings.Root != null)
            {
                this.Builder.Append("--root");
                this.Builder.AppendQuoted(this.Settings.Root.MakeAbsolute(this.Environment).FullPath);
            }

            if (this.Settings.ManifestGlobs != null && this.Settings.ManifestGlobs.Count > 0)
            {
                this.Builder.Append("--manifest-globs");

                foreach (var manifestGlob in this.Settings.ManifestGlobs)
                {
                    this.Builder.AppendQuoted(manifestGlob);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.Settings.Override))
            {
                this.Builder.Append("--override");
                this.Builder.AppendQuoted(this.Settings.Override);
            }

            if (this.Settings.OverridesFile != null)
            {
                this.Builder.Append("--overrides-file");
                this.Builder.AppendQuoted(this.Settings.OverridesFile.MakeAbsolute(this.Environment).FullPath);
            }

            if (this.Settings.BypassValidation)
            {
                this.Builder.Append("--bypass-validation");
            }

            if (!string.IsNullOrWhiteSpace(this.Settings.Publisher))
            {
                this.Builder.Append("--publisher");
                this.Builder.AppendQuoted(this.Settings.Publisher);
            }

            if (!string.IsNullOrWhiteSpace(this.Settings.ExtensionId))
            {
                this.Builder.Append("--extension-id");
                this.Builder.AppendQuoted(this.Settings.ExtensionId);
            }

            if (this.Settings.OutputPath != null)
            {
                this.Builder.Append("--output-path");
                this.Builder.AppendQuoted(this.Settings.OutputPath.MakeAbsolute(this.Environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(this.Settings.LocRoot))
            {
                this.Builder.Append("--loc-root");
                this.Builder.AppendQuoted(this.Settings.LocRoot);
            }
        }
    }
}