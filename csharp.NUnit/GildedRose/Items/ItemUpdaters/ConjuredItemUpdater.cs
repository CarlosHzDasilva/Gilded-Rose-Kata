using System;

namespace GildedRoseKata.Items.ItemUpdaters;

public class ConjuredItemUpdater : ItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality = Math.Max(0, item.Quality - 2);
        }
        
        item.SellIn -= 1;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality = Math.Max(0, item.Quality - 2);
        }
    }
}