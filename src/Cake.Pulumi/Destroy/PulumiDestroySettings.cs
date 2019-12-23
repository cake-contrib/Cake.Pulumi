namespace Cake.Pulumi
{
    /// <summary>
    ///     The Pulumi destroy command is used to destroy the Pulumi-managed infrastructure.
    /// </summary>
    public class PulumiDestroySettings : PulumiStackSettings
    {
        public bool AutoApprove { get; set; }
    }
}