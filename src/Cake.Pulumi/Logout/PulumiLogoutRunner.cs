using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiLogoutRunner : PulumiRunner<PulumiLogoutSettings>
    {
        public PulumiLogoutRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PulumiLogoutSettings settings)
        {
            Run("logout", settings);
        }

    }
}