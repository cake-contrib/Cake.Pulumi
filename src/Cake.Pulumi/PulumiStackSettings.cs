namespace Cake.Pulumi
{
    public class PulumiStackSettings : PulumiSettings
    {
        public enum EnvCommandType
        {
            Workspace,
            Env
        }

        public EnvCommandType EnvCommand { get; set; } = EnvCommandType.Workspace;
    }
}