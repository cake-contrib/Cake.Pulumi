using System;
using System.Collections.Generic;
using System.Threading;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Core.Tooling;

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
        /// <returns></returns>
        [CakeMethodAlias]
        public static string PulumiPreview(this ICakeContext context, string stack)
        {
            return PulumiPreview(context, new PulumiPreviewSettings {Stack = stack});
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
            var runner = new PulumiPreviewRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
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
        /// <returns></returns>
        [CakeMethodAlias]
        public static ChangeSummary PulumiChangeSummary(this ICakeContext context, string stack)
        {
            return PulumiChangeSummary(context, new PulumiChangeSummarySettings {Stack = stack});
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
            var runner = new PulumiChangeSummaryRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
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
        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context, string stack)
        {
            PulumiUp(context, new PulumiUpSettings {Stack = stack});
        }

        /// <summary>
        /// Performs a "Pulumi up" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void PulumiUp(this ICakeContext context, PulumiUpSettings settings)
        {
            var runner = new PulumiUpRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
        }

        /// <summary>
        /// "pulumi stack output" Output name => Output value
        /// </summary>
        /// <param name="context"></param>
        [CakeMethodAlias]
        public static IReadOnlyDictionary<string, string> PulumiStackOutput(this ICakeContext context)
        {
            return PulumiStackOutput(context, new PulumiStackOutputSettings());
        }

        /// <summary>
        /// "pulumi stack output" Output name => Output value
        /// </summary>
        /// <param name="context"></param>
        /// <param name="stackName"></param>
        [CakeMethodAlias]
        public static IReadOnlyDictionary<string, string> PulumiStackOutput(this ICakeContext context, string stackName)
        {
            return PulumiStackOutput(context, new PulumiStackOutputSettings {Stack = stackName});
        }

        /// <summary>
        /// "pulumi stack output" Output name => Output value
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IReadOnlyDictionary<string, string> PulumiStackOutput(this ICakeContext context,
            PulumiStackOutputSettings settings)
        {
            var runner = new PulumiStackOutputRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
            return runner.Outputs;
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
        /// <param name="stack"></param>
        [CakeMethodAlias]
        public static void PulumiDestroy(this ICakeContext context, string stack)
        {
            PulumiDestroy(context, new PulumiDestroySettings {Stack = stack});
        }

        /// <summary>
        /// Performs a "Pulumi destroy" - WARNING: Does not prompt for confirmation of any kind.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        public static void PulumiDestroy(this ICakeContext context, PulumiDestroySettings settings)
        {
            var runner = new PulumiDestroyRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
        }

        [CakeMethodAlias]
        public static void PulumiRefresh(this ICakeContext context)
        {
            PulumiRefresh(context, new PulumiRefreshSettings());
        }

        [CakeMethodAlias]
        public static void PulumiRefresh(this ICakeContext context, string stack)
        {
            PulumiRefresh(context, new PulumiRefreshSettings {Stack = stack});
        }

        [CakeMethodAlias]
        public static void PulumiRefresh(this ICakeContext context, PulumiRefreshSettings settings)
        {
            var runner = new PulumiRefreshRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
        }

        /// <summary>
        /// Setup or login to any backend
        /// </summary>
        /// <param name="context"></param>
        /// <param name="backend"></param>
        [CakeMethodAlias]
        public static void PulumiLogin(this ICakeContext context, string backend)
        {
            PulumiLogin(context, new PulumiLoginSettings {Backend = backend});
        }

        [CakeMethodAlias]
        public static void PulumiLogin(this ICakeContext context, PulumiLoginSettings settings)
        {
            var runner = new PulumiLoginRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
        }


        /// <summary>
        /// logout of the current backend
        /// </summary>
        /// <param name="context"></param>
        [CakeMethodAlias]
        public static void PulumiLogout(this ICakeContext context)
        {
            PulumiLogout(context, new PulumiLogoutSettings());
        }

        /// <summary>
        /// logout of a specific backend
        /// </summary>
        /// <param name="context"></param>
        /// <param name="backend"></param>
        [CakeMethodAlias]
        public static void PulumiLogout(this ICakeContext context, string backend)
        {
            PulumiLogout(context, new PulumiLogoutSettings {Backend = backend});
        }

        [CakeMethodAlias]
        public static void PulumiLogout(this ICakeContext context, PulumiLogoutSettings settings)
        {
            var runner = new PulumiLogoutRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools);
            runner.Run(Set(settings));
        }


        private static readonly AsyncLocal<string> _pulumiStack = new AsyncLocal<string>();

        /// <summary>
        /// Explicitly sets the pulumi stack you want to operate on over multiple pulumi commands
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pulumiStack">Specify the pulumi stack you want to operate on. e.g. 'dev'</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IDisposable PulumiStack(this ICakeContext context, string pulumiStack)
        {
            _pulumiStack.Value = pulumiStack;
            return new DisposableAction(() => _pulumiStack.Value = null);
        }

        private static readonly AsyncLocal<DirectoryPath> _pulumiDir = new AsyncLocal<DirectoryPath>();

        /// <summary>
        /// Set the pulumi directory (e.g. containing index.ts)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pulumiDirectory">Specify the path containing the pulumi scripts e.g. './infrastructure'</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IDisposable PulumiDir(this ICakeContext context, DirectoryPath pulumiDirectory)
        {
            _pulumiDir.Value = pulumiDirectory.MakeAbsolute(context.Environment);
            return new DisposableAction(() => _pulumiDir.Value = null);
        }

        private static T Set<T>(T toolSettings) where T : ToolSettings
        {
            if (_pulumiDir.Value != null)
            {
                toolSettings.NoWorkingDirectory = false;
                toolSettings.WorkingDirectory = _pulumiDir.Value;
            }

            if (toolSettings is PulumiStackSettings pss && pss.Stack == null && _pulumiStack.Value != null)
            {
                pss.Stack = _pulumiStack.Value;
            }

            return toolSettings;
        }

        class DisposableAction : IDisposable
        {
            private readonly Action _action;
            public DisposableAction(Action action) => _action = action;
            public void Dispose() => _action?.Invoke();
        }
    }
}