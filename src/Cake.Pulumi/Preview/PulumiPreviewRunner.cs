using System;
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

        public string StdOut { get; private set; }

        public void Run(PulumiPreviewSettings settings)
        {
            Run("preview", settings, 
                stdOut => StdOut = string.Join(Environment.NewLine, stdOut));
        }

    }
}