using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiLogoutSettings : PulumiSettings
    {
        /// <summary>
        /// Pulumi backend - by default it will logout of your current stack's backend,
        /// Otherwise you can specify a backend to logout from.
        /// </summary>
        public string Backend { get; set; }


        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            var b = base
                .Apply(builder);
            
            if (!string.IsNullOrWhiteSpace(Backend))
                b = b.Append(Backend);
            
            return b;
        }
    }
}