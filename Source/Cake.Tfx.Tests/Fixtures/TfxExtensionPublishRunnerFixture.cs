using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Tfx.Extension.Publish;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionPublishRunnerFixture : TfxFixture<TfxExtensionPublishSettings>
    {
        public FilePath VsixFilePath { get; set; }

        public ICollection<string> ShareWith { get; set; }

        public TfxExtensionPublishRunnerFixture()
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
            var tool = new TfxExtensionPublishRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Publish(VsixFilePath, ShareWith, Settings);
        }
    }
}