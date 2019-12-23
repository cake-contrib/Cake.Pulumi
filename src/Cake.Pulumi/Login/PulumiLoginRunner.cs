using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiLoginRunner : PulumiRunner<PulumiLoginSettings>
    {
        public PulumiLoginRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiLoginSettings settings)
        {
            Run("login", settings);
        }

    }
}