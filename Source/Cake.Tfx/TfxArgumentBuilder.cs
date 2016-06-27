using System;
using Cake.Common.Tools.WiX;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx
{
    /// <summary>
    /// The top level argument builder for the Tfx CLI Tool
    /// </summary>
    /// <typeparam name="T">The Settings type to build arguments from</typeparam>
    internal abstract class TfxArgumentBuilder<T>
        where T : TfxCommonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfxArgumentBuilder{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="settings">The settings.</param>
        protected TfxArgumentBuilder(ICakeEnvironment environment, T settings)
        {
            this.Settings = settings;
            this.Environment = environment;
            this.Builder = new ProcessArgumentBuilder();
        }

        /// <summary>
        /// Gets the Cake Environment
        /// </summary>
        protected ICakeEnvironment Environment { get; }

        /// <summary>
        /// Gets the Cake ProcessArgumentBuilder instance
        /// </summary>
        protected ProcessArgumentBuilder Builder { get; }

        /// <summary>
        /// Gets the Cake Settings.
        /// </summary>
        protected T Settings { get; }

        /// <summary>
        /// Append all the Common Arguments to the Argument Builder.
        /// </summary>
        protected void AppendCommonArguments()
        {
            if (this.Settings.Save)
            {
                this.Builder.Append("--save");
            }

            if (this.Settings.NoPrompt)
            {
                this.Builder.Append("--no-prompt");
            }

            if (this.Settings.Output.HasValue)
            {
                this.Builder.Append("--output");
                this.Builder.Append(GetOutputName(this.Settings.Output.Value));
            }
        }

        /// <summary>
        /// Convert the <see cref="TfxOutputType"/> to a friendly version.
        /// </summary>
        /// <param name="output">The type of Output which the command should use</param>
        /// <returns>The friendly name for the Enumeration value.</returns>
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