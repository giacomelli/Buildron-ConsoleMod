using Buildron.Domain.Mods;
using UnityEngine;

namespace ConsoleMod
{
    /// <summary>
    /// Responsible to create the ModController GameObject and attach to listen a lot of the Buildron events.
    /// </summary>
    public class Mod : IMod
    {
        /// <summary>
        /// Initialize the mod with the context.
        /// </summary>
        /// <param name="context">The mod context.</param>
        public void Initialize(IModContext context)
        {
            var controller = CreateModController();
            ListenEvents(context, controller);            
        }

        private static ModController CreateModController()
        {
            var go = new GameObject("ConsoleController");
            return go.AddComponent<ModController>();
        }

        private static void ListenEvents(IModContext context, ModController controller)
        {
            context.BuildFound += (sender, e) =>
            {
                controller.AddMessage("Build found: {0}", e.Build);
            };

            context.BuildRemoved += (sender, e) =>
            {
                controller.AddMessage("Build removed: {0}", e.Build);
            };

            context.BuildsRefreshed += (sender, e) =>
            {
                controller.AddMessage("Build refreshed: {0} builds found, {1} builds removed, {2} builds status changed", e.BuildsFound.Count, e.BuildsRemoved.Count, e.BuildsStatusChanged.Count);
            };

            context.BuildStatusChanged += (sender, e) =>
            {
                controller.AddMessage("Build status changed: {0}", e.Build);
            };

            context.BuildTriggeredByChanged += (sender, e) =>
            {
                controller.AddMessage("Build triggered by changed: {0}/{1}", e.Build, e.Build.TriggeredBy);
            };

            context.BuildUpdated += (sender, e) =>
            {
                controller.AddMessage("Build updated: {0}", e.Build);
            };

            context.CIServerStatusChanged += (sender, e) =>
            {
                controller.AddMessage("CI server status changed: {0}", e.Server.Status);
            };

            context.RemoteControlChanged += (sender, e) =>
            {
                controller.AddMessage("RC changed: {0}", e.RemoteControl);
            };

            context.UserAuthenticationCompleted += (sender, e) =>
            {
                controller.AddMessage("User authentication completed: {0}:{1}", e.User, e.Success ? "success" : "failed");
            };

            context.UserFound += (sender, e) =>
            {
                controller.AddMessage("User found: {0}", e.User);
            };

            context.UserRemoved += (sender, e) =>
            {
                controller.AddMessage("User remoed: {0}", e.User);
            };

            context.UserTriggeredBuild += (sender, e) =>
            {
                controller.AddMessage("User triggered build: {0}/{1}", e.User, e.Build);
            };

            context.UserUpdated += (sender, e) =>
            {
                controller.AddMessage("User updated: {0}", e.User);
            };
        }
    }
}