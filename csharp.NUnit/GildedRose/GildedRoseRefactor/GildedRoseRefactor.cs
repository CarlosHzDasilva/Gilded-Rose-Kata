using System.Collections.Generic;
using GildedRoseKata.Items;
using GildedRoseTests.GildedRoseRefactor;

namespace GildedRoseKata.GildedRoseRefactor;

public class GildedRoseRefactor
{
    private readonly IList<Item> _items;

    public GildedRoseRefactor(IList<Item> items, ItemUpdaterFactory factory)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                continue;
            }

            if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                    
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
                
                item.SellIn -= 1;
                
                if (item.SellIn < 0)
                {
                    item.Quality -= item.Quality;
                }
            }

            if (item.Name.Equals("Aged Brie"))
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
                
                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
            
            if (!item.Name.Equals("Aged Brie") && !item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
                
                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }
                }
            }
        }
    }
}