using Cake.Core.IO;
using Cake.Tfx.Extension.Publish;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionPublishRunnerFixture : TfxFixture<TfxExtensionPublishSettings>
    {
        public FilePath VsixFilePath { get; set; }

        public TfxExtensionPublishRunnerFixture()
        {
            VsixFilePath = "c:/temp/test.vsix";
        }

        protected override void RunTool()
        {
            var tool = new TfxExtensionPublishRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Publish(VsixFilePath, Settings);
        }
    }
}