using Cake.Tfx.Extension.Share;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionShareRunnerFixture : TfxFixture<TfxExtensionShareSettings>
    {
        protected override void RunTool()
        {
            var tool = new TfxExtensionShareRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Share(Settings);
        }
    }
}