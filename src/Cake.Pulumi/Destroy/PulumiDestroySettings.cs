using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    /// <summary>
    ///     The Pulumi destroy command is used to destroy the Pulumi-managed infrastructure.
    /// </summary>
    public class PulumiDestroySettings : PulumiStackSettings
    {
        /// <summary>
        /// Refresh Pulumi stack state before performing the destroy command.
        /// </summary>
        public bool Refresh { get; set; }

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base
                .Apply(builder)
                .Append("--yes")
                .Append("--skip-preview");

            if (Refresh)
                builder.Append("--refresh");

            return builder;
        }
    }
}