using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.Tfx.Tests
{
    internal abstract class TfxFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected TfxFixture()
            : base("tfx.cmd")
        {
        }
    }
}