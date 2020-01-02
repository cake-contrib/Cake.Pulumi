using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json.Linq;

namespace Cake.Pulumi
{
    public class PulumiChangeSummaryRunner : PulumiRunner<PulumiChangeSummarySettings>
    {
        public PulumiChangeSummaryRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }



        public void Run(PulumiChangeSummarySettings settings)
        {
            string[] output = null;
            
            Run("preview", settings,
                stdOut => output = stdOut);

            try
            {
                var json = JObject.Parse(string.Join(Environment.NewLine, output));
                ChangeSummary = json["changeSummary"].ToObject<ChangeSummary>();
            }
            catch
            {
                ChangeSummary = new ChangeSummary();
            }
        }

        public ChangeSummary ChangeSummary { get; private set; }
    }
}