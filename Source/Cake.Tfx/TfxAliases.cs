using Cake.Core;
using Cake.Core.Annotations;
using Cake.Tfx.Extension.Create;

namespace Cake.Tfx
{
    /// <summary>
    /// Contains aliases related to Tfx CLI
    /// </summary>
    [CakeAliasCategory("ReSharper")]
    public static class TfxAliases
    {
        /// <summary>
        /// Runs ReSharperReports against the specified input FilePath, and outputs to specified output FilePath
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