using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Tfx.Extension.Share;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionShareRunnerFixture : TfxFixture<TfxExtensionShareSettings>
    {
        public FilePath VsixFilePath { get; set; }

        public ICollection<string> ShareWith { get; set; }

        public TfxExtensionShareRunnerFixture()
        {
            VsixFilePath = "c:/temp/test.vsix";
        }

        public void GivenSingleAccount()
        {
            ShareWith = new List<string> { "account1" };
        }

        public void GivenMultipleAccounts()
        {
            ShareWith = new List<string> { "account1", "account2" };
        }

        protected override void RunTool()
        {
            var tool = new TfxExtensionShareRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Share(VsixFilePath, ShareWith, Settings);
        }
    }
}