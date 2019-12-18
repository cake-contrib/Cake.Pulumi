namespace Cake.Pulumi.Destroy
{
    /// <summary>
    ///     The Pulumi destroy command is used to destroy the Pulumi-managed infrastructure.
    /// </summary>
    public class PulumiDestroySettings : PulumiSettings
    {
        public string Stack { get; set; }
        public bool AutoApprove { get; set; }
    }
}