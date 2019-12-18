using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi.Up
{
    public class PulumiUpRunner : PulumiRunner<PulumiUpSettings>
    {
        public PulumiUpRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiUpSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append("up");

            // Order of AutoApprove and Plan are important.
            if (settings.Refresh)
                builder.Append("--refresh");

            if (!string.IsNullOrWhiteSpace(settings.Stack))
                builder = builder.AppendSwitchQuoted("--stack", settings.Stack);

            if (settings.AutoApprove)
                builder = builder.Append("--yes");

            Run(settings, builder);
        }
    }
}