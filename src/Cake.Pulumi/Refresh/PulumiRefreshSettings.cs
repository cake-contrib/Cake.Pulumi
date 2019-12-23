using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiRefreshSettings : PulumiStackSettings
    {
        /// <summary>
        /// Expect no changes.
        /// Will fail if any changes in your Pulumi state vs actual state are detected.
        /// </summary>
        public bool ExpectNoChanges { get; set; }

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