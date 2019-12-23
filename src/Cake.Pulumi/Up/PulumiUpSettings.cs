using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiUpSettings : PulumiStackConfigSettings
    {
        /// <summary>
        /// Expect no changes.
        /// Will fail the command if any changes in your script vs Pulumi state are detected.
        /// <see cref="PulumiAliases.PulumiPreview(Cake.Core.ICakeContext)"/>
        /// </summary>
        public bool ExpectNoChanges { get; set; }
        
        /// <summary>
        /// Refresh Pulumi stack state before performing the up command.
        /// </summary>
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