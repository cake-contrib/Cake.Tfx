using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx
{
    /// <summary>
    /// The top level argument builder for the Tfx CLI Tool
    /// </summary>
    public static class TfxArgumentBuilder
    {
        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        public static void GetCommonArguments(ProcessArgumentBuilder builder, TfxSettings settings)
        {
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

        public static void GetServerArguments(ProcessArgumentBuilder builder, TfxServerSettings settings)
        {
            builder.Append("--auth-type");
            builder.Append(GetAuthName(settings.AuthType));

            if (!string.IsNullOrWhiteSpace(settings.UserName))
            {
                builder.Append("--username");
                builder.AppendQuoted(settings.UserName);
            }

            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                builder.Append("--password");
                builder.AppendQuotedSecret(settings.Password);
            }

            if (!string.IsNullOrWhiteSpace(settings.Token))
            {
                builder.Append("--token");
                builder.AppendQuotedSecret(settings.Token);
            }

            if (!string.IsNullOrWhiteSpace(settings.ServiceUrl))
            {
                builder.Append("--service-url");
                builder.AppendQuoted(settings.ServiceUrl);
            }

            if (!string.IsNullOrWhiteSpace(settings.Proxy))
            {
                builder.Append("--proxy");
                builder.AppendQuoted(settings.Proxy);
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