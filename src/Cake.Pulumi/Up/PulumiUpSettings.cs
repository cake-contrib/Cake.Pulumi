namespace Cake.Pulumi
{
    public class PulumiUpSettings : PulumiStackSettings
    {
        public bool Refresh { get; set; }
        public bool AutoApprove { get; set; }
    }
}