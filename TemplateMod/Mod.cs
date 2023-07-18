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
        public override Version Version { get; set; } = new Version(1, 0, 0);

        public static Mod Instance { get; private set; }

        private EventHandlers eventsHandler;

        public override void OnLoaded()
        {
            Logger.Debug($"TemplateMod Work!\nTest int: {Config.TestInt}");
            Instance = this;
            eventsHandler = new EventHandlers();

            EventsManager.PickupedItem += eventsHandler.OnPickupedItem;
            EventsManager.TakeOutResource += eventsHandler.OnTakeOutResource;
            EventsManager.GameLoaded += eventsHandler.OnGameLoaded;

            CommandManager.AddCommand(new Test());

            base.OnLoaded();
        }
    }
}
