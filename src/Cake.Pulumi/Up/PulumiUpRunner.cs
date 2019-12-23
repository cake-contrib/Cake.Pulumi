using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiUpRunner : PulumiRunner<PulumiUpSettings>
    {
        public PulumiUpRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiUpSettings settings)
        {
            Run("up", settings);
        }
    }
}