using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public abstract class PulumiStackSettings : PulumiSettings
    {
        /// <summary>
        /// The stack name you want to perform the action
        /// Leave blank to use the prevailing stack (not recommended)
        /// </summary>
        public string Stack { get; set; }

        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            builder = base
                .Apply(builder)
                .Append("--non-interactive");

            if (!string.IsNullOrWhiteSpace(Stack))
                builder = builder.AppendSwitchQuoted("--stack", Stack);
            
            return builder;
        }
    }
}
