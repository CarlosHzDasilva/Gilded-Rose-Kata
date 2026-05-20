using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class AgedItemUpdaterTest
{
    [Test]
    public void AgedItemIncreasesQuality()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 10 };
        var updater = new AgedItemUpdater();

        updater.Update(item);

        Assert.AreEqual(0, item.SellIn);
        Assert.AreEqual(11, item.Quality);
    }
    
    [Test]
    public void AgedItemIncreasesQualityTwiceAfterSellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };
        var updater = new AgedItemUpdater();

        updater.Update(item);

        Assert.AreEqual(-1, item.SellIn);
        Assert.AreEqual(12, item.Quality);
    }
}