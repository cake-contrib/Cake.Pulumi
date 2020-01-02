using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public abstract class PulumiRunner<TPulumiSettings> : Tool<TPulumiSettings> where TPulumiSettings : PulumiSettings
    {
        private readonly ICakePlatform _platform;

        protected PulumiRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _platform = environment.Platform;
        }

        protected void Run(string verb, TPulumiSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append(verb);

            builder = settings.Apply(builder);

            Run(settings, builder);
        }
        
        protected override IDictionary<string, string> GetEnvironmentVariables(TPulumiSettings settings)
        {
            var dict = base.GetEnvironmentVariables(settings);
            
            if (!string.IsNullOrWhiteSpace(settings.PulumiAccessToken))
            {
                dict.Add("PULUMI_ACCESS_TOKEN", settings.PulumiAccessToken);
            }
            if (!string.IsNullOrWhiteSpace(settings.PulumiConfigPassphase))
            {
                dict.Add("PULUMI_CONFIG_PASSPHRASE", settings.PulumiConfigPassphase);
            }
            

            return dict;
        }

        protected override string GetToolName()
        {
            return "Pulumi";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {_platform.IsUnix() ? "pulumi" : "pulumi.exe"};
        }
    }
}