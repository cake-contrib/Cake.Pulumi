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
            Run("refresh", settings);
        }
    }
}