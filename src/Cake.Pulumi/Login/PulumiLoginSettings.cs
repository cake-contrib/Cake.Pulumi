using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pulumi
{
    public class PulumiLoginSettings : PulumiSettings
    {
        /// <summary>
        /// Pulumi backend
        /// Default: "https://app.pulumi.com"
        /// 
        /// Local: file://~ or file://path
        /// AWS S3: s3://my-pulumi-state-bucket
        /// GCP GCS: gs://my-pulumi-state-bucket
        /// Azure Blob: azblob://my-pulumi-state-bucket
        /// Pulumi Enterprise: https://pulumi.acmecorp.com
        /// </summary>
        public string Backend { get; set; } = "https://app.pulumi.com";


        internal override ProcessArgumentBuilder Apply(ProcessArgumentBuilder builder)
        {
            return base
                .Apply(builder)
                .Append(Backend);
        }
    }
}