using System.Collections.Generic;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.Pulumi.Tests
{
    public class PulumiStackOutputTests
    {
        private class Fixture : PulumiFixture<PulumiStackOutputSettings>
        {
            public Fixture(PlatformFamily platformFamily = PlatformFamily.Windows) : base(platformFamily)
            {
            }

            public IReadOnlyDictionary<string, string> StackOutput { get; set; }

            protected override void RunTool()
            {
                var tool = new PulumiStackOutputRunner(FileSystem, Environment, ProcessRunner, Tools);
                tool.Run(Settings);
                StackOutput = tool.Outputs;
            }
        }

        public class TheExecutable
        {
            [Theory]
            [InlineData("/bin/tools/pulumi/pulumi.exe", "/bin/tools/pulumi/pulumi.exe")]
            [InlineData("/bin/tools/pulumi/pulumi", "/bin/tools/pulumi/pulumi")]
            public void Should_use_pulumi_from_tool_path_if_provided(string toolPath, string expected)
            {
                var fixture = new Fixture {Settings = {ToolPath = toolPath}};
                fixture.GivenSettingsToolPathExist();

                var result = fixture.Run();

                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_find_linux_executable()
            {
                var fixture = new Fixture(PlatformFamily.Linux);
                fixture.Environment.Platform.Family = PlatformFamily.Linux;


                var result = fixture.Run();

                Assert.Equal("/Working/tools/pulumi", result.Path.FullPath);
            }

            [Fact]
            public void Should_find_pulumi_if_tool_path_not_provided()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Equal("/Working/tools/pulumi.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_set_input_variables_file()
            {
                var fixture = new Fixture
                {
                    Settings = new PulumiStackOutputSettings
                    {
                        Stack = "dev"
                    }
                };
                var result = fixture.Run();

                Assert.Contains("--stack \"dev\"", result.Args);
            }

            [Fact]
            public void Should_set_plan_parameter()
            {
                var fixture = new Fixture();

                var result = fixture.Run();

                Assert.Contains("stack output", result.Args);
            }

            [Fact]
            public void Should_throw_if_process_has_exit_code_one()
            {
                var fixture = new Fixture();
                fixture.GivenProcessExitsWithCode(1);

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Pulumi: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_throw_if_pulumi_runner_was_not_found()
            {
                var fixture = new Fixture();
                fixture.GivenDefaultToolDoNotExist();

                var result = Record.Exception(() => fixture.Run());

                Assert.IsType<CakeException>(result);
                Assert.Equal("Pulumi: Could not locate executable.", result.Message);
            }
            
            [Fact]
            public void Should_set_pulumi_access_token_if_set()
            {
                var fixture = new Fixture
                {
                    Settings = new PulumiStackOutputSettings
                    {
                        PulumiAccessToken = "Bleb"
                    }
                };
                var result = fixture.Run();

                Assert.Equal("Bleb", result.Process.EnvironmentVariables["PULUMI_ACCESS_TOKEN"]);
            }

        }
    }
}