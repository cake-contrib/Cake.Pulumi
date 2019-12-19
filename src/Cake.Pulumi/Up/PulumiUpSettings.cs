namespace Cake.Pulumi
{
    public class PulumiUpSettings : PulumiSettings
    {
        public string Stack { get; set; }
        public bool Refresh { get; set; }
        public bool AutoApprove { get; set; }
    }
}