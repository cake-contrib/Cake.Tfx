using Cake.Tfx.Extension.Create;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionCreateRunnerFixture : TfxFixture<TfxExtensionCreateSettings>
    {
        protected override void RunTool()
        {
            var tool = new TfxExtensionCreateRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Create(Settings);
        }
    }
}