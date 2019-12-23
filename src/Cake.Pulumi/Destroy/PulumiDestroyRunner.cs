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
            Run("destroy", settings);
        }
    }
}