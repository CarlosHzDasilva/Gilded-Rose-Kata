using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata.GildedRoseRefactor;

public class GildedRoseRefactor
{
    private readonly IList<Item> _items;
    private readonly ItemUpdaterFactory _itemUpdaterFactory;

    public GildedRoseRefactor(IList<Item> items, ItemUpdaterFactory itemUpdaterFactory)
    {
        _items = items;
        _itemUpdaterFactory = itemUpdaterFactory;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = _itemUpdaterFactory.CreateFor(item);
            updater.Update(item);
        }
    }
}