using Cake.Core.IO;

namespace Cake.Tfx
{
    /// <summary>
    /// Interface for TfxArgumentBuilder
    /// </summary>
    public interface ITfxArgumentBuilder
    {
        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <returns>A populated <see cref="ProcessArgumentBuilder"/>.</returns>
        ProcessArgumentBuilder GetArguments();
    }
}