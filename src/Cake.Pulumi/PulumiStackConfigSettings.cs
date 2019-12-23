using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public abstract class PulumiStackConfigSettings : PulumiStackSettings
    {
        /// <summary>
        /// Config key value pairs to override the auto-detected stack settings
        /// NOTE: This will update the selected stack's config to these values permanently if an 'up' command succeeds.
        /// </summary>
        public IDictionary<string, string> Config { get; set; } = new Dictionary<string, string>();

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base.Apply(builder);
            
            foreach (var kvp in Config ?? Enumerable.Empty<KeyValuePair<string, string>>())
            {
                builder.AppendSwitchQuoted("--config", $"{kvp.Key}={kvp.Value}");
            }

            return builder;
        }
    }
}