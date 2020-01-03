using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public class PulumiStackOutputRunner : PulumiRunner<PulumiStackOutputSettings>
    {
        public PulumiStackOutputRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public IReadOnlyDictionary<string, string> Outputs { get; private set; }

        public void Run(PulumiStackOutputSettings settings)
        {
            Run("stack output", settings, 
                stdOut => Outputs = new ReadOnlyDictionary<string, string>(ParseOutputs(stdOut)));
        }

        private IDictionary<string, string> ParseOutputs(string[] stdOutLines)
        {
            var dict = new Dictionary<string, string>();

            if (stdOutLines.Length < 3)
                return dict;
            
            int valueStart = stdOutLines[1].IndexOf("VALUE", StringComparison.Ordinal);
            
            // skip the two lines...
            for (int i = 2; i < stdOutLines.Length; i++)
            {
                var name = stdOutLines[i].Substring(0, valueStart).Trim();
                var value = stdOutLines[i].Substring(valueStart).Trim();
                dict[name] = value;
            }

            return dict;
        }
    }
}