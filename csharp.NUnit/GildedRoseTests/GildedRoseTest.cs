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
    
    [Test]
    public void MultipleItemsQualityDecreasesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 2, Quality = 4 },
            new Item { Name = "Another Item", SellIn = 3, Quality = 3 }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(3));
        Assert.That(items[0].Name, Is.EqualTo("An Item"));
        Assert.That(items[1].Quality, Is.EqualTo(2));
        Assert.That(items[1].Name, Is.EqualTo("Another Item"));
    }
    
    [Test]
    public void QualityCannotBeNegative()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.Zero);
    }
    }
}