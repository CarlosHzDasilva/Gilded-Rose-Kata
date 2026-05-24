using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly ItemUpdaterFactory _itemUpdaterFactory;

    public GildedRose(IList<Item> items, ItemUpdaterFactory itemUpdaterFactory)
    {
        _items = items;
        _itemUpdaterFactory = itemUpdaterFactory;
    }
    
    public void AddItemToInventory(Item item)
    {
        _items.Add(item);
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