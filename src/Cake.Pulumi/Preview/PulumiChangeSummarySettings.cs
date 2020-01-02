using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiChangeSummarySettings : PulumiStackConfigSettings
    {
        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            return base
                .Apply(builder)
                .Append("--json");
        }
    }
}