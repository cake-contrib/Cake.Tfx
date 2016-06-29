using Cake.Core.Tooling;

namespace Cake.Tfx
{
    /// <summary>
    /// Contains the common settings used by all commands in Tfx.
    /// </summary>
    public abstract class TfxSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to save arguments for the next time a command in this command group is run.
        /// </summary>
        public bool Save { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to not prompt the user for input (instead, raise an error).
        /// </summary>
        public bool NoPrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the output type to be used for commands
        /// </summary>
        public TfxOutputType? Output { get; set; }
    }
}