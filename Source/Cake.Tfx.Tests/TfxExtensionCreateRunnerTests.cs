using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Testing;
using Cake.Tfx.Tests.Fixtures;
using Xunit;

namespace Cake.Tfx.Tests
{
    public sealed class TfxExtensionCreateRunnerTests
    {
        public sealed class TheCreateMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings = null;

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
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();

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
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.ToolPath = toolPath;
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.GivenProcessCannotStart();

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
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);

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
                var fixture = new TfxExtensionCreateRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/tfx.cmd", result.Path.FullPath);
            }

            [Fact]
            public void Should_Add_Root_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.Root = "./test";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --root \"/Working/test\"", result.Args);
            }

            [Fact]
            public void Should_Add_Single_Manifest_Glob_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.ManifestGlobs = new List<string> { "test" };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --manifest-globs \"test\"", result.Args);
            }

            [Fact]
            public void Should_Add_Multiple_Manifest_Globs_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.ManifestGlobs = new List<string> { "test", "test1" };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --manifest-globs \"test\" \"test1\"", result.Args);
            }

            [Fact]
            public void Should_Add_Override_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.Override = "override";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --override \"override\"", result.Args);
            }

            [Fact]
            public void Should_Add_OverridesFile_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.OverridesFile = "./override.txt";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --overrides-file \"/Working/override.txt\"", result.Args);
            }

            [Fact]
            public void Should_Add_BypassValidation_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.BypassValidation = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --bypass-validation", result.Args);
            }

            [Fact]
            public void Should_Add_Publisher_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.Publisher = "gep13";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --publisher \"gep13\"", result.Args);
            }

            [Fact]
            public void Should_Add_ExtensionId_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.ExtensionId = "cake-build";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --extension-id \"cake-build\"", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.OutputPath = "./buildartifacts";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --output-path \"/Working/buildartifacts\"", result.Args);
            }

            [Fact]
            public void Should_Add_LocRoot_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.LocRoot = "locroot";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --loc-root \"locroot\"", result.Args);
            }

            [Fact]
            public void Should_Add_Save_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.Save = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --save", result.Args);
            }

            [Fact]
            public void Should_Add_NoPrompt_To_Arguments_If_Set()
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.NoPrompt = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("extension create --no-prompt", result.Args);
            }

            [Theory]
            [InlineData(TfxOutputType.Friendly, "extension create --output friendly")]
            [InlineData(TfxOutputType.Json, "extension create --output json")]
            [InlineData(TfxOutputType.Clipboard, "extension create --output clipboard")]
            public void Should_Add_OutputType_To_Arguments_If_Set(TfxOutputType outputType, string expected)
            {
                // Given
                var fixture = new TfxExtensionCreateRunnerFixture();
                fixture.Settings.Output = outputType;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}