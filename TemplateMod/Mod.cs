using Outpath_Modding.API.Mod;
using Outpath_Modding.Events;
using Outpath_Modding.GameConsole;
using Outpath_Modding.GameConsole.Components;
using System;
using TemplateMod.Commands;

namespace TemplateMod
{
    public class Mod : Mod<Config>
    {
        public override string Author { get; set; } = "MrAfitol";
        public override string Name { get; set; } = "Template Mod";
        public override string Description { get; set; } = "A mod template for the Outpath-Modding framework";
        public override Version Version { get; set; } = new Version(1, 0, 1);

        public static Mod Instance { get; private set; }

        private EventHandlers eventsHandler;

        public override void OnLoaded()
        {
            Logger.Debug($"TemplateMod Work!\nTest int: {Config.TestInt}");
            Instance = this;
            eventsHandler = new EventHandlers();

            EventsManager.SetItemToInfiniteCraft += eventsHandler.OnSetItemToInfinite;
            EventsManager.SetItemToCraft += eventsHandler.OnSetItemToCraft;
            EventsManager.PickupedItem += eventsHandler.OnPickupedItem;
            EventsManager.TakeOutResource += eventsHandler.OnTakeOutResource;
            EventsManager.GameLoaded += eventsHandler.OnGameLoaded;
            EventsManager.MenuLoaded += eventsHandler.OnMenuLoaded;

            CommandManager.AddCommand(new Test());

            base.OnLoaded();
        }
    }
}
