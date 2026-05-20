using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;

namespace GildedRoseTests.GildedRoseRefactor;

public class ItemUpdaterFactory
{
    public ItemUpdater CreateFactory(Item item)
    {
        return item.Name switch
        {
            string s when s.StartsWith("Aged") => new AgedItemUpdater(),
            string s when s.StartsWith("Backstage") => new BackstageItemUpdater(),
            string s when s.StartsWith("Sulfuras") => new SulfurasItemUpdater(),
            _ => new DefaultItemUpdater()
        };
    }
}