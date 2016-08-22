using Cake.Core;
using Cake.Core.Annotations;
using Cake.Tfx.Extension.Create;

namespace Cake.Tfx
{
    /// <summary>
    /// <para>Contains functionality related to the <see href="https://github.com/Microsoft/tfs-cli#install">TFS Cross Platform Command Line Interface</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, the tfx-cli utility will need to be installed and available, or you will need to provide a ToolPath to where it can be located, and also you will need to include the following in your build.cake file to download and
    /// reference the addin from NuGet.org:
    /// <code>
    /// #addin Cake.Tfx
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("Tfx")]
    public static class TfxAliases
    {
        /// <summary>
        /// Creates an extension using the Tfx CLI using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// TfxExtensionCreate(new TfxExtensionCreateSettings()
        /// {
        ///     ManifestGlobs = new List&lt;string&gt;(){ ".\extension-manifest.json" }
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TfxExtensionCreate(this ICakeContext context, TfxExtensionCreateSettings settings)
        {
            var runner = new TfxExtensionCreateRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Create(settings);
        }
    }
}