using System;
using Cake.Common.Tools.WiX;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx
{
    internal abstract class TfxArgumentBuilder<T> where T : TfxCommonSettings
    {
        protected readonly ICakeEnvironment Environment;

        protected readonly ProcessArgumentBuilder Builder;

        protected readonly T Settings;

        protected TfxArgumentBuilder(ICakeEnvironment environment, T settings)
        {
            Settings = settings;
            Environment = environment;
            Builder = new ProcessArgumentBuilder();
        }

        protected void AppendArgumentIfNotNull(string argumentName, string value)
        {
            if (value != null)
            {
                Builder.Append("--" + argumentName);
                Builder.AppendQuoted(value);
            }
        }

        protected void AppendArgumentIfNotNull(string argumentName, FilePath value)
        {
            if (value != null)
            {
                Builder.Append("--" + argumentName);
                Builder.AppendQuoted(value.MakeAbsolute(Environment).FullPath);
            }
        }

        protected void AppendCommonArguments()
        {
            if (Settings.Save)
            {
                Builder.Append("--save");
            }

            if (Settings.NoPrompt)
            {
                Builder.Append("--no-prompt");
            }

            // Architecture
            if (Settings.Output.HasValue)
            {
                Builder.Append("--output");
                Builder.Append(GetOutputName(Settings.Output.Value));
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
    }
}