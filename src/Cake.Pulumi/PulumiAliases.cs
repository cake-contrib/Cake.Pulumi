using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Pulumi
{
    [CakeAliasCategory("Pulumi")]
    public static class PulumiAliases
    {
        /// <summary>
        /// Use to get human readable output for things like "Approval" steps in your build process
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string PulumiPreview(this ICakeContext context)
        {
            return PulumiPreview(context, new PulumiPreviewSettings());
        }


        /// <summary>
        /// Use to get human readable output for things like "Approval" steps in your build process
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string PulumiPreview(this ICakeContext context, PulumiPreviewSettings settings)
        {
            var runner = new PulumiPreviewRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
            return runner.StdOut;
        }
        
        
        /// <summary>
        /// Get a change summary from pulumi preview.  <see cref="ChangeSummary.Changes"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static ChangeSummary PulumiChangeSummary(this ICakeContext context)
        {
            return PulumiChangeSummary(context, new PulumiChangeSummarySettings());
        }


        /// <summary>
        /// Get a change summary from pulumi preview.  <see cref="ChangeSummary.Changes"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static ChangeSummary PulumiChangeSummary(this ICakeContext context, PulumiChangeSummarySettings settings)
        {
            var runner = new PulumiChangeSummaryRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
            return runner.ChangeSummary;
        }

        /// <summary>
        /// Performs a "Pulumi up" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context)
        {
            PulumiUp(context, new PulumiUpSettings());
        }
        
        /// <summary>
        /// Performs a "Pulumi up" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context, PulumiUpSettings settings)
        {
            var runner = new PulumiUpRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }

        /// <summary>
        /// Performs a "Pulumi destroy" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        [CakeMethodAlias]
        public static void PulumiDestroy(this ICakeContext context)
        {
            PulumiDestroy(context, new PulumiDestroySettings());
        }

        /// <summary>
        /// Performs a "Pulumi destroy" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
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
        
        /// <summary>
        /// Setup or login to any backend
        /// </summary>
        /// <param name="context"></param>
        /// <param name="backend"></param>
        [CakeMethodAlias]
        public static void PulumiLogin(this ICakeContext context, string backend)
        {
            PulumiLogin(context, new PulumiLoginSettings { Backend = backend });
        }
        
        [CakeMethodAlias]
        public static void PulumiLogin(this ICakeContext context, PulumiLoginSettings settings)
        {
            var runner = new PulumiLoginRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
        
        /// <summary>
        /// Setup or logout to any backend
        /// </summary>
        /// <param name="context"></param>
        /// <param name="backend"></param>
        [CakeMethodAlias]
        public static void PulumiLogout(this ICakeContext context, string backend)
        {
            PulumiLogout(context, new PulumiLogoutSettings { Backend = backend });
        }
        
        [CakeMethodAlias]
        public static void PulumiLogout(this ICakeContext context, PulumiLogoutSettings settings)
        {
            var runner = new PulumiLogoutRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
    }
}