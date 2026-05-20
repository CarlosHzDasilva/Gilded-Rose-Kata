using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void AnItemQualityDecreaseWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.Zero);
    }
    }
}