using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiPreviewSettings : PulumiStackConfigSettings
    {
        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            return base
                .Apply(builder)
                .Append("--expect-no-changes");
        }
    }
}