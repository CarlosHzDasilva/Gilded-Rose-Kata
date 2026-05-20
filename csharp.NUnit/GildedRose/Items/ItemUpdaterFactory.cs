using GildedRoseKata.Items.ItemUpdaters;

namespace GildedRoseKata.Items;

public class ItemUpdaterFactory
{
    public ItemUpdater CreateFor(Item item)
    {
        return item.Name switch
        {
            string s when s.StartsWith("Aged") => new AgedItemUpdater(),
            string s when s.StartsWith("Backstage") => new BackstageItemUpdater(),
            string s when s.StartsWith("Sulfuras") => new SulfurasItemUpdater(),
            string s when s.StartsWith("Conjured") => new ConjuredItemUpdater(),
            _ => new DefaultItemUpdater()
        };
    }
}