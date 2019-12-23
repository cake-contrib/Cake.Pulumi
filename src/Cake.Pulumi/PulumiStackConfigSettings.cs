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
        /// </summary>
        public IDictionary<string, string> Config { get; set; }

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base.Apply(builder);
            
            foreach (var kvp in Config ?? Enumerable.Empty<KeyValuePair<string, string>>())
            {
                builder.AppendSwitch("--config", $"{kvp.Key}={kvp.Value}");
            }

            return builder;
        }
    }
}