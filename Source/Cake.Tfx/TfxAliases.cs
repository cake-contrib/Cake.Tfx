using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Tfx.Extension.Create;
using Cake.Tfx.Extension.Install;
using Cake.Tfx.Extension.Publish;
using Cake.Tfx.Extension.Share;

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

        /// <summary>
        /// Creates an extension using the Tfx CLI using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="vsixFilePath">The path to the vsix.</param>
        /// <param name="accounts">The accounts to install the extension to.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// TfxExtensionInstall("c:/temp/test.vsix", new List&lt;string&gt;{ "account1 }, new TfxExtensionInstallSettings()
        /// {
        ///     AuthType = TfxAuthType.Pat,
        ///     Token = "abcdef"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TfxExtensionInstall(this ICakeContext context, FilePath vsixFilePath, ICollection<string> accounts, TfxExtensionInstallSettings settings)
        {
            var runner = new TfxExtensionInstallRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Install(vsixFilePath, accounts, settings);
        }

        /// <summary>
        /// Creates an extension using the Tfx CLI using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// TfxExtensionPublish(new TfxExtensionPublishSettings()
        /// {
        ///     ManifestGlobs = new List&lt;string&gt;(){ ".\extension-manifest.json" }
        ///     AuthType = TfxAuthType.Pat,
        ///     Token = "abcdef"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TfxExtensionPublish(this ICakeContext context, TfxExtensionPublishSettings settings)
        {
            var runner = new TfxExtensionPublishRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Publish(settings);
        }

        /// <summary>
        /// Creates an extension using the Tfx CLI using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="vsixFilePath">The path to the vsix.</param>
        /// <param name="shareWith">The accounts to publish the extension to.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// TfxExtensionPublish("c:/temp/test.vsix", new List&lt;string&gt;{ "account1 }, new TfxExtensionPublishSettings()
        /// {
        ///     AuthType = TfxAuthType.Pat,
        ///     Token = "abcdef"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TfxExtensionPublish(this ICakeContext context, FilePath vsixFilePath, ICollection<string> shareWith, TfxExtensionPublishSettings settings)
        {
            var runner = new TfxExtensionPublishRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Publish(vsixFilePath, shareWith, settings);
        }

        /// <summary>
        /// Creates an extension using the Tfx CLI using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="vsixFilePath">The path to the vsix.</param>
        /// <param name="shareWith">The accounts to publish the extension to.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// TfxExtensionShare("c:/temp/test.vsix", new List&lt;string&gt;{ "account1 }, new TfxExtensionShareSettings()
        /// {
        ///     AuthType = TfxAuthType.Pat,
        ///     Token = "abcdef"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TfxExtensionShare(this ICakeContext context, FilePath vsixFilePath, ICollection<string> shareWith, TfxExtensionShareSettings settings)
        {
            var runner = new TfxExtensionShareRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Share(vsixFilePath, shareWith, settings);
        }
    }
}