using Outpath_Modding.API.Enums;
using Outpath_Modding.API.Features;
using Outpath_Modding.API.Features.Item;
using Outpath_Modding.API.Mod;
using Outpath_Modding.Events;
using Outpath_Modding.GameConsole;
using Outpath_Modding.GameConsole.Components;
using Outpath_Modding.Unity;
using System;
using System.IO;
using TemplateMod.Commands;
using static Outpath_Modding.API.Features.Item.CustomItemInfo;

namespace TemplateMod
{
    public class Mod : Mod<Config>
    {
        public override string Author { get; set; } = "MrAfitol";
        public override string Name { get; set; } = "Template Mod";
        public override string Description { get; set; } = "A mod template for the Outpath-Modding framework";
        public override Version Version { get; set; } = new Version(1, 0, 2);

        public static Mod Instance { get; private set; }

        private EventHandlers eventsHandler;

        public ResourcePrefab TestiumOre_Prefab;

        public override void OnLoaded()
        {
            Logger.Debug($"TemplateMod Work!\nTest int: {Config.TestInt}");
            Instance = this;
            eventsHandler = new EventHandlers();

            // Events registration
            EventsManager.SetItemToInfiniteCraft += eventsHandler.OnSetItemToInfinite;
            EventsManager.SetItemToCraft += eventsHandler.OnSetItemToCraft;
            EventsManager.PickupedItem += eventsHandler.OnPickupedItem;
            EventsManager.TakeOutResource += eventsHandler.OnTakeOutResource;
            EventsManager.GameLoaded += eventsHandler.OnGameLoaded;
            EventsManager.MenuLoaded += eventsHandler.OnMenuLoaded;

            CommandManager.AddCommand(new Test()); // Registering a command

            CustomItemInfo.AddNewMaterial(new ItemMaterialSettings("Testium Raw", ImageLoader.LoadSprite(Path.Combine(Mod.Instance.ResourcesPath, "TestiumRaw.png"), 16))); // Creating an item
            CustomItemInfo.AddNewMaterial(new ItemMaterialSettings("Testium", ImageLoader.LoadSprite(Path.Combine(Mod.Instance.ResourcesPath, "Testium.png"), 16), "It`s a testium :P", new ItemCraftMaterial[] { new ItemCraftMaterial() { itemInfoName = "Testium Raw", quantityNeeded = 1 }, new ItemCraftMaterial() { itemInfoName = "Coal", quantityNeeded = 1 } }, 5, 1, 15, ItemCraftingType.Furnace)); // Creating an item
            TestiumOre_Prefab = ResourcePrefab.CreatePrefab(new ResourcePrefab.ResourcePrefabSettings("Testium Ore", 25f, ResourceType.Rock, ImageLoader.LoadSprite(Path.Combine(Mod.Instance.ResourcesPath, "TestiumOre.png")))); // Creating a resource
            TestiumOre_Prefab.ClearLoot(); // Clearing loot when destroyed
            IslandBlock.AddPropToSpawn(BiomeType.Grasslands, BlockType.Stone, TestiumOre_Prefab, 0.4f, 1f); // Adding a resource to spawn on islands

            base.OnLoaded();
        }
    }
}
