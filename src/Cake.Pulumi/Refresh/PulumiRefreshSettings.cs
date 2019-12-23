using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiRefreshSettings : PulumiStackSettings
    {
        public bool ExpectNoChanges { get; set; }
        public bool AutoApprove { get; set; }

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base
                .Apply(builder);

            if (ExpectNoChanges)
                builder = builder.Append("--expect-no-changes");

            return builder;
        }
    }
}