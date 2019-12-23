using Cake.Core.Tooling;

namespace Cake.Pulumi
{
    public abstract class PulumiSettings : ToolSettings
    {
        /// <summary>
        /// Set if using a pulumi server backend (pulumi.com or Pulumi Enterprise)
        /// </summary>
        public string PulumiAccessToken { get; set; }
    }
}