using System;
using Cake.Core;
using Cake.Testing;
using Cake.Tfx.Tests.Fixtures;
using Xunit;

namespace Cake.Tfx.Tests
{
    public sealed class TfxExtensionInstallRunnerTests
    {
        public sealed class TheInstallMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings = null;
                fixture.GivenSingleAccount();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("settings", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Throw_If_Tfx_Executable_Was_Not_Found()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();
                fixture.GivenSingleAccount();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Tfx: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/Tfx/tfx.cmd", "/bin/tools/Tfx/tfx.cmd")]
            [InlineData("./tools/Tfx/tfx.cmd", "/Working/tools/Tfx/tfx.cmd")]
            public void Should_Use_Tfx_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.ToolPath = toolPath;
                fixture.GivenSettingsToolPathExist();
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenProcessCannotStart();
                fixture.GivenSingleAccount();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Tfx: Process was not started.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);
                fixture.GivenSingleAccount();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Tfx: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_Find_Tfx_Executable_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/tfx.cmd", result.Path.FullPath);
            }

            [Fact]
            public void Should_Add_Publisher_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Publisher = "gep13";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --publisher \"gep13\"", result.Args);
            }

            [Fact]
            public void Should_Add_ExtensionId_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.ExtensionId = "cake-vso";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --extension-id \"cake-vso\"", result.Args);
            }

            [Fact]
            public void Should_Add_Vsix_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat", result.Args);
            }

            [Fact]
            public void Should_Add_Single_Account_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat", result.Args);
            }

            [Fact]
            public void Should_Add_Multiple_Accounts_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.GivenMultipleAccounts();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" \"account2\" --auth-type pat", result.Args);
            }

            [Theory]
            [InlineData(TfxAuthType.Pat, "extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat")]
            [InlineData(TfxAuthType.Basic, "extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type basic")]
            public void Should_Add_AuthType_To_Arguments_If_Set(TfxAuthType authType, string expected)
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.AuthType = authType;
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Fact]
            public void Should_Add_UserName_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.UserName = "gep13";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --username \"gep13\"", result.Args);
            }

            [Fact]
            public void Should_Add_Password_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Password = "password";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --password \"password\"", result.Args);
            }

            [Fact]
            public void Should_Add_Token_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Token = "abcdef";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --token \"abcdef\"", result.Args);
            }

            [Fact]
            public void Should_Add_ServiceUrl_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.ServiceUrl = "http://test.com";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --service-url \"http://test.com\"", result.Args);
            }

            [Fact]
            public void Should_Add_Proxy_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Proxy = "proxy";
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --proxy \"proxy\"", result.Args);
            }

            [Fact]
            public void Should_Add_Save_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Save = true;
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --save", result.Args);
            }

            [Fact]
            public void Should_Add_NoPrompt_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.NoPrompt = true;
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --no-prompt", result.Args);
            }

            [Theory]
            [InlineData(TfxOutputType.Friendly, "extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --output friendly")]
            [InlineData(TfxOutputType.Json, "extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --output json")]
            [InlineData(TfxOutputType.Clipboard, "extension install --vsix \"c:/temp/test.vsix\" --accounts \"account1\" --auth-type pat --output clipboard")]
            public void Should_Add_OutputType_To_Arguments_If_Set(TfxOutputType outputType, string expected)
            {
                // Given
                var fixture = new TfxExtensionInstallRunnerFixture();
                fixture.Settings.Output = outputType;
                fixture.GivenSingleAccount();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}