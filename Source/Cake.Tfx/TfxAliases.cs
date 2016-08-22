using Cake.Core;
using Cake.Core.Annotations;
using Cake.Tfx.Extension.Create;

namespace Cake.Tfx
{
    /// <summary>
    /// Contains aliases related to Tfx CLI
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