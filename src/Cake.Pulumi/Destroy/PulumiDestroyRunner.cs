using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiDestroyRunner : PulumiRunner<PulumiDestroySettings>
    {
        public PulumiDestroyRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiDestroySettings settings)
        {
            var builder = new ProcessArgumentBuilder().Append("destroy");

            if (!string.IsNullOrWhiteSpace(settings.Stack))
                builder = builder.AppendSwitchQuoted("--stack", settings.Stack);

            if (settings.AutoApprove)
                builder = builder.Append("--yes");

            Run(settings, builder);
        }
    }
}