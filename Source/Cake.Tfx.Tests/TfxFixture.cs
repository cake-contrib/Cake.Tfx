using Cake.Core.Diagnostics;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;

namespace Cake.Tfx.Tests
{
    internal abstract class TfxFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        public ICakeLog Log { get; set; }

        protected TfxFixture()
            : base("tfx.cmd")
        {
            Log = Substitute.For<ICakeLog>();
        }
    }
}