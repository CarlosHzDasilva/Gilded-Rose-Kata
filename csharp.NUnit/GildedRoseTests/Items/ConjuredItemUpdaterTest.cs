using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class ConjuredItemUpdaterTest
{
    [Test]
    public void ConjuredTestQualityDecreaseTwiceAsFastThanNormalItems()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 };
        var updater = new ConjuredItemUpdater();

        updater.Update(item);

        Assert.AreEqual(0, item.SellIn);
        Assert.AreEqual(8, item.Quality);
    }
    
    [Test]
    public void ConjuredTestQualityDecreaseWhenSellByDatePassed()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = -2, Quality = 2 };
        var updater = new ConjuredItemUpdater();

        updater.Update(item);

        Assert.AreEqual(-3, item.SellIn);
        Assert.AreEqual(0, item.Quality);
    }
    
    [Test]
    public void ConjuredTestQualityCannotBeNegative()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 2 };
        var updater = new ConjuredItemUpdater();

        updater.Update(item);

        Assert.AreEqual(0, item.SellIn);
        Assert.AreEqual(0, item.Quality);
    }
}