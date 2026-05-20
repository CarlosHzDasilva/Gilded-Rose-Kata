using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void AnItemQualityDecreaseWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = 2, Quality = 1 } };
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

    [Test]
    public void ItemQualityDegradesTwiceAsFastWhenSellByDatePassed()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = 0, Quality = 3 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.Negative);
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void ItemQualityDegradesTwiceAsFastAndCannotBeNegativeWhenSellByDatePassed()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = -4, Quality = 1 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-5));
        Assert.That(items[0].Quality, Is.Zero);
    }

    [Test]
    public void ItemSellInDecreaseWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "An Item", SellIn = 2, Quality = 4 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(1));
    }
    
    [Test]
    public void MultipleItemsSellInDecreasesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 2, Quality = 4 },
            new Item { Name = "Another Item", SellIn = 1, Quality = 3 }
        };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(1));
        Assert.That(items[1].SellIn, Is.Zero);
    }

    [Test]
    public void SulfurasPropertiesNeverChangesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void AgedBrieQualityIncreasesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 7 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }

    [Test]
    public void BackstageQualityIncreaseWhenSellInOver10()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 7 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(10));
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
    
    [Test]
    public void BackstageQualityIncreaseDoubleWhenSellInIsUnder10()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 7 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }
    
    [Test]
    public void BackstageQualityIncreaseTripleWhenSellInIsUnder5()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 7 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(4));
        Assert.That(items[0].Quality, Is.EqualTo(10));
    }

    [Test]
    public void BackstageQualityDropsToZeroAfterConcert()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 21 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.Negative);
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
}