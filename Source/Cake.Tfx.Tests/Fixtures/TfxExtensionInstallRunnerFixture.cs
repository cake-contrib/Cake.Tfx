using Cake.Tfx.Extension.Install;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionInstallRunnerFixture : TfxFixture<TfxExtensionInstallSettings>
    {
        protected override void RunTool()
        {
            var tool = new TfxExtensionInstallRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(Settings);
        }
    }
}