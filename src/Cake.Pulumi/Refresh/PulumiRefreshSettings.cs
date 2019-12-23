namespace Cake.Pulumi
{
    public class PulumiRefreshSettings : PulumiStackSettings
    {
        public bool ExpectNoChanges { get; set; }
        public bool AutoApprove { get; set; }
    }
}