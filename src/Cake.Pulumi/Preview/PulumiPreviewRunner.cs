using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiPreviewRunner : PulumiRunner<PulumiPreviewSettings>
    {
        public PulumiPreviewRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiPreviewSettings settings)
        {
            Run("preview", settings);
        }

        public bool HasChanges { get; private set; }

        protected override void ProcessExitCode(int exitCode)
        {
            if (exitCode == -1)
                HasChanges = true;
            else
                base.ProcessExitCode(exitCode);
        }
    }
}