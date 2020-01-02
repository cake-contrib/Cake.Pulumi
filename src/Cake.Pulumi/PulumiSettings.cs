using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public abstract class PulumiSettings : ToolSettings
    {
        /// <summary>
        /// Set if using a pulumi server backend (pulumi.com or Pulumi Enterprise)
        /// </summary>
        public string PulumiAccessToken { get; set; }

        /// <summary>
        /// Set if using pulumi local state persistence.
        /// </summary>
        public string PulumiConfigPassphrase { get; set; }

        
        /// <summary>
        /// Enable verbose logging
        /// </summary>
        public bool Verbose { get; set; }

        internal virtual ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            var b = builder
                .Append("--non-interactive");

            if (Verbose)
            {
                b = b.AppendSwitch("--verbose", "3");
            }

            return b;
        }
    }
}