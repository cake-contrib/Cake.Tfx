using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx.Extension.Create
{
    internal class TfxExtensionCreateArgumentBuilder : TfxArgumentBuilder<TfxExtensionCreateSettings>
    {
        public TfxExtensionCreateArgumentBuilder(ICakeEnvironment environment, TfxExtensionCreateSettings settings)
            : base(environment, settings)
        {
        }

        public ProcessArgumentBuilder Get()
        {
            AppendExtensionCreateArguments();
            AppendCommonArguments();

            return Builder;
        }

        private void AppendExtensionCreateArguments()
        {
            Builder.Append("extension create");

            if (Settings.Root != null)
            {
                Builder.Append("--root");
                Builder.AppendQuoted(Settings.Root.MakeAbsolute(Environment).FullPath);
            }

            // Sources
            if (Settings.ManifestGlobs != null && Settings.ManifestGlobs.Count > 0)
            {
                Builder.Append("--manifest-globs");

                foreach (var manifestGlob in Settings.ManifestGlobs)
                {
                    Builder.AppendQuoted(manifestGlob);
                }
            }

            if (string.IsNullOrWhiteSpace(Settings.Override))
            {
                Builder.Append("--override");
                Builder.Append(Settings.Override);
            }

            if (Settings.OverridesFile != null)
            {
                Builder.Append("--overrides-file");
                Builder.AppendQuoted(Settings.OverridesFile.MakeAbsolute(Environment).FullPath);
            }

            if (Settings.BypassValidation)
            {
                Builder.Append("--bypass-validation");
            }

            if (string.IsNullOrWhiteSpace(Settings.Publisher))
            {
                Builder.Append("--publisher");
                Builder.Append(Settings.Publisher);
            }

            if (string.IsNullOrWhiteSpace(Settings.ExtensionId))
            {
                Builder.Append("--extension-id");
                Builder.Append(Settings.ExtensionId);
            }

            if (Settings.OutputPath != null)
            {
                Builder.Append("--output-path");
                Builder.AppendQuoted(Settings.OutputPath.MakeAbsolute(Environment).FullPath);
            }

            if (string.IsNullOrWhiteSpace(Settings.LocRoot))
            {
                Builder.Append("--loc-root");
                Builder.Append(Settings.LocRoot);
            }
        }
    }
}