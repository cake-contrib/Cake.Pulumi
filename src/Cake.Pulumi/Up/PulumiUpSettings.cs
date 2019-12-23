using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiUpSettings : PulumiStackConfigSettings
    {
        public bool ExpectNoChanges { get; set; }
        public bool Refresh { get; set; }

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base
                .Apply(builder);

            if (Refresh)
                builder.Append("--refresh");

            if (ExpectNoChanges)
                builder = builder.Append("--expect-no-changes");
            
            return builder;
        }
    }
}