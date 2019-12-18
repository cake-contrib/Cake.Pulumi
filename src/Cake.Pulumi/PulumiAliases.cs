using Cake.Core;
using Cake.Core.Annotations;
using Cake.Pulumi.Destroy;
using Cake.Pulumi.Preview;
using Cake.Pulumi.Refresh;
using Cake.Pulumi.Up;

namespace Cake.Pulumi
{
    [CakeAliasCategory("Pulumi")]
    public static class PulumiAliases
    {
        [CakeMethodAlias]
        public static bool PulumiPreview(this ICakeContext context)
        {
            return PulumiPreview(context, new PulumiPreviewSettings());
        }

        [CakeMethodAlias]
        public static bool PulumiPreview(this ICakeContext context, PulumiPreviewSettings settings)
        {
            var runner = new PulumiPreviewRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
            return runner.HasChanges;
        }

        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context)
        {
            PulumiUp(context, new PulumiUpSettings());
        }

        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context, PulumiUpSettings settings)
        {
            var runner = new PulumiUpRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void PulumiDestroy(this ICakeContext context)
        {
            PulumiDestroy(context, new PulumiDestroySettings());
        }

        [CakeMethodAlias]
        public static void PulumiDestroy(this ICakeContext context, PulumiDestroySettings settings)
        {
            var runner = new PulumiDestroyRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        [CakeMethodAlias]
        public static void PulumiRefresh(this ICakeContext context)
        {
            PulumiRefresh(context, new PulumiRefreshSettings());
        }

        [CakeMethodAlias]
        public static void PulumiRefresh(this ICakeContext context, PulumiRefreshSettings settings)
        {
            var runner = new PulumiRefreshRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
    }
}