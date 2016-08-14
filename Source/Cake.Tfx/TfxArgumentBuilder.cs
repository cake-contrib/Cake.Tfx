using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Tfx
{
    /// <summary>
    /// The top level argument builder for the Tfx CLI Tool
    /// </summary>
    /// <typeparam name="T">The Settings type to build arguments from</typeparam>
    public abstract class TfxArgumentBuilder<T>
        where T : TfxSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly ProcessArgumentBuilder _builder;
        private readonly T _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxArgumentBuilder{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="setting">The settings</param>
        protected TfxArgumentBuilder(ICakeEnvironment environment, T setting)
        {
            _environment = environment;
            _settings = setting;
            _builder = new ProcessArgumentBuilder();
        }

        /// <summary>
        /// Gets the Cake Environment
        /// </summary>
        protected ICakeEnvironment Environment => _environment;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>A populated argument builder.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            AddArguments(_builder, _settings);
            AddCommonArguments();
            return _builder;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected abstract void AddArguments(ProcessArgumentBuilder builder, T settings);

        private void AddCommonArguments()
        {
            if (_settings.Save)
            {
                _builder.Append("--save");
            }

            if (_settings.NoPrompt)
            {
                _builder.Append("--no-prompt");
            }

            if (_settings.Output.HasValue)
            {
                _builder.Append("--output");
                _builder.Append(GetOutputName(_settings.Output.Value));
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