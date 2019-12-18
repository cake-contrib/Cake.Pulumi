using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi.Preview
{
    public class PulumiPreviewRunner : PulumiRunner<PulumiPreviewSettings>
    {
        public PulumiPreviewRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public bool HasChanges { get; private set; }

        public void Run(PulumiPreviewSettings settings)
        {
            var builder = new ProcessArgumentBuilder()
                .Append("preview");

            if (!string.IsNullOrWhiteSpace(settings.Stack))
                builder = builder.AppendSwitchQuoted("--stack", settings.Stack);

            builder = builder.Append("--expect-no-changes");

            Run(settings, builder);
        }

        protected override void ProcessExitCode(int exitCode)
        {
            if (exitCode == -1)
                HasChanges = true;
            else
                base.ProcessExitCode(exitCode);
        }
    }
}