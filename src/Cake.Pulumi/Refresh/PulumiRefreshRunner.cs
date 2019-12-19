using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiRefreshRunner : PulumiRunner<PulumiRefreshSettings>
    {
        public PulumiRefreshRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiRefreshSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append("refresh");

            if (!string.IsNullOrWhiteSpace(settings.Stack))
                builder = builder.AppendSwitchQuoted("--stack", settings.Stack);

            if (settings.ExpectNoChanges)
                builder = builder.Append("--expect-no-changes");

            if (settings.AutoApprove)
                builder = builder.Append("--yes");

            Run(settings, builder);
        }
    }
}