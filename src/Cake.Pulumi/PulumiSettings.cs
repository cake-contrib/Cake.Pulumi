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
        public string PulumiConfigPassphase {get;set;}

        internal virtual ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            return builder.Append("--non-interactive");
        }
    }
}