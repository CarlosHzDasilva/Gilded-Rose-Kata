using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class SulfurasItemUpdaterTest
{
    [Test]
    public void SulfurasItemDoesNotChange()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var updater = new SulfurasItemUpdater();

        updater.Update(item);

        Assert.AreEqual(0, item.SellIn);
        Assert.AreEqual(80, item.Quality);
    }
}