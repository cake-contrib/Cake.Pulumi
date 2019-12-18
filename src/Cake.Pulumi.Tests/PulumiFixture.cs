using Cake.Core;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.Pulumi.Tests
{
    public abstract class PulumiFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected PulumiFixture(PlatformFamily platformFamily = PlatformFamily.Windows)
            : base(platformFamily == PlatformFamily.Windows ? "pulumi.exe" : "pulumi")
        {
            Environment.Platform.Family = platformFamily;
        }
    }
}