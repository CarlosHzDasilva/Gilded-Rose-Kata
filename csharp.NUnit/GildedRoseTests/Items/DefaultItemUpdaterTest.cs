using GildedRoseKata.Items;
using GildedRoseKata.Items.ItemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class DefaultItemUpdaterTest
{
    [Test]
    public void DefaultItemsDegradesNormally()
    {
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        var updater = new DefaultItemUpdater();

        updater.Update(item);

        Assert.AreEqual(9, item.SellIn);
        Assert.AreEqual(19, item.Quality);
    }
}