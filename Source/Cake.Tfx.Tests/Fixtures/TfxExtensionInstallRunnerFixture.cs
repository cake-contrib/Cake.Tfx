using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Tfx.Extension.Install;

namespace Cake.Tfx.Tests.Fixtures
{
    internal sealed class TfxExtensionInstallRunnerFixture : TfxFixture<TfxExtensionInstallSettings>
    {
        public FilePath VsixFilePath { get; set; }

        public ICollection<string> Accounts { get; set; }

        public TfxExtensionInstallRunnerFixture()
        {
            VsixFilePath = "c:/temp/test.vsix";
        }

        public void GivenSingleAccount()
        {
            Accounts = new List<string> { "account1" };
        }

        public void GivenMultipleAccounts()
        {
            Accounts = new List<string> { "account1", "account2" };
        }

        protected override void RunTool()
        {
            var tool = new TfxExtensionInstallRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(VsixFilePath, Accounts, Settings);
        }
    }
}