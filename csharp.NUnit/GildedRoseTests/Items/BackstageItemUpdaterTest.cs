using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class BackstageItemUpdaterTest
{
    [Test]
    public void BackstageItemIncreasesQuality()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
        var updater = new BackstageItemUpdater();

        updater.Update(item);

        Assert.AreEqual(4, item.SellIn);
        Assert.AreEqual(23, item.Quality);
    }
    
    [Test]
    public void BackstageItemDropsToZeroAfterConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
        var updater = new BackstageItemUpdater();
        
        updater.Update(item);
        
        Assert.AreEqual(-1, item.SellIn);
        Assert.AreEqual(0, item.Quality);
    }
}