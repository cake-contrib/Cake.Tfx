using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Tfx.Extension;

namespace Cake.Tfx
{
    /// <summary>
    /// The top level argument builder for the Tfx CLI Tool
    /// </summary>
    public static class TfxArgumentBuilder
    {
        /// <summary>
        /// Adds the common arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The serverSettings.</param>
        public static void GetCommonArguments(ProcessArgumentBuilder builder, TfxSettings settings)
        {
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

            if (settings.Save)
            {
                builder.Append("--save");
            }

            if (settings.NoPrompt)
            {
                builder.Append("--no-prompt");
            }

            if (settings.Output.HasValue)
            {
                builder.Append("--output");
                builder.Append(GetOutputName(settings.Output.Value));
            }
        }

        /// <summary>
        /// Adds the common arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="createSettings">The Create settings.</param>
        public static void GetCreatePublishArgument(ProcessArgumentBuilder builder, ICakeEnvironment environment, ICreatePublishSettings createSettings)
        {
            if (createSettings.Root != null)
            {
                builder.Append("--root");
                builder.AppendQuoted(createSettings.Root.MakeAbsolute(environment).FullPath);
            }

            if (createSettings.ManifestGlobs != null && createSettings.ManifestGlobs.Count > 0)
            {
                builder.Append("--manifest-globs");

                foreach (var manifestGlob in createSettings.ManifestGlobs)
                {
                    builder.AppendQuoted(manifestGlob);
                }
            }

            if (!string.IsNullOrWhiteSpace(createSettings.Override))
            {
                builder.Append("--override");
                builder.AppendQuoted(createSettings.Override);
            }

            if (createSettings.OverridesFile != null)
            {
                builder.Append("--overrides-file");
                builder.AppendQuoted(createSettings.OverridesFile.MakeAbsolute(environment).FullPath);
            }

            if (createSettings.BypassValidation)
            {
                builder.Append("--bypass-validation");
            }

            if (createSettings.OutputPath != null)
            {
                builder.Append("--output-path");
                builder.AppendQuoted(createSettings.OutputPath.MakeAbsolute(environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(createSettings.LocRoot))
            {
                builder.Append("--loc-root");
                builder.AppendQuoted(createSettings.LocRoot);
            }
        }

        /// <summary>
        /// Adds the server arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="serverSettings">The serverSettings.</param>
        public static void GetServerArguments(ProcessArgumentBuilder builder, TfxServerSettings serverSettings)
        {
            builder.Append("--auth-type");
            builder.Append(GetAuthName(serverSettings.AuthType));

            if (!string.IsNullOrWhiteSpace(serverSettings.UserName))
            {
                builder.Append("--username");
                builder.AppendQuoted(serverSettings.UserName);
            }

            if (!string.IsNullOrWhiteSpace(serverSettings.Password))
            {
                builder.Append("--password");
                builder.AppendQuotedSecret(serverSettings.Password);
            }

            if (!string.IsNullOrWhiteSpace(serverSettings.Token))
            {
                builder.Append("--token");
                builder.AppendQuotedSecret(serverSettings.Token);
            }

            if (!string.IsNullOrWhiteSpace(serverSettings.ServiceUrl))
            {
                builder.Append("--service-url");
                builder.AppendQuoted(serverSettings.ServiceUrl);
            }

            if (!string.IsNullOrWhiteSpace(serverSettings.Proxy))
            {
                builder.Append("--proxy");
                builder.AppendQuoted(serverSettings.Proxy);
            }
        }

        private static string GetOutputName(TfxOutputType output)
        {
            switch (output)
            {
                case TfxOutputType.Friendly:
                    return "friendly";
                case TfxOutputType.Json:
                    return "json";
                case TfxOutputType.Clipboard:
                    return "clipboard";
                default:
                    throw new NotSupportedException("The provided output is not valid.");
            }
        }

        private static string GetAuthName(TfxAuthType authType)
        {
            switch (authType)
            {
                case TfxAuthType.Pat:
                    return "pat";
                case TfxAuthType.Basic:
                    return "basic";
                default:
                    throw new NotSupportedException("The provided authentication is not valid");
            }
        }
    }
}