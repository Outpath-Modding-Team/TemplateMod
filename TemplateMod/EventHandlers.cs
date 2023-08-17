using Outpath_Modding.Events.EventArguments;
using Outpath_Modding.GameConsole;

namespace TemplateMod
{
    public class EventHandlers
    {
        public void OnSetItemToInfinite(SetItemToInfiniteCraftEventArgs ev)
        {
            Logger.Debug($"You set {ev.Item.itemName} to infinite craft");
        }

        public void OnSetItemToCraft(SetItemToCraftEventArgs ev)
        {
            Logger.Debug($"You set {ev.Item.itemName} to craft of quantity {ev.Quantity}");
        }

        public void OnPickupedItem(PickupedItemEventArgs ev)
        {
            Logger.Debug($"You pick up a {ev.ItemInfo.itemName} of quantity {ev.Quantity}");
        }

        public void OnTakeOutResource(TakeOutResourceEventArgs ev)
        {
            Logger.Debug($"You have caused {ev.Damage} damage to a {ev.Rresource.propName}");
        }

        public void OnGameLoaded()
        {
            Logger.Debug("Game loaded!");
        }

        public void OnMenuLoaded()
        {
            Logger.Debug("Menu loaded!");
        }
    }
}
