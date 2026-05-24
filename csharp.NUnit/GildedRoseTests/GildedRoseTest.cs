using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using GildedRoseKata.Items;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void ItemQualityDecreaseWhenUpdateQualityIsCalled()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 2, Quality = 1 });
        
        app.UpdateQuality();

        var result = app.GetInventory();
        Assert.That(result[0].Quality, Is.Zero);
    }
    
    [Test]
    public void MultipleItemsQualityDecreasesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 2, Quality = 4 },
            new Item { Name = "Another Item", SellIn = 3, Quality = 3 }
        };
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(items);
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].Quality, Is.EqualTo(3));
        Assert.That(result[0].Name, Is.EqualTo("An Item"));
        Assert.That(result[1].Quality, Is.EqualTo(2));
        Assert.That(result[1].Name, Is.EqualTo("Another Item"));
    }

    [Test]
    public void ItemQualityDecreaseWhenUpdateQualityMultipleTimes()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 2, Quality = 4 });
        
        app.UpdateQuality();
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].Quality, Is.EqualTo(2));
    }
    
    [Test]
    public void QualityCannotBeNegative()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 2, Quality = 0 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].Quality, Is.Zero);
    }

    [Test]
    public void ItemQualityDegradesTwiceAsFastWhenSellByDatePassed()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 0, Quality = 3 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.Negative);
        Assert.That(result[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void ItemQualityDegradesTwiceAsFastAndCannotBeNegativeWhenSellByDatePassed()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = -4, Quality = 1 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(-5));
        Assert.That(result[0].Quality, Is.Zero);
    }

    [Test]
    public void ItemSellInDecreaseWhenUpdateQualityIsCalled()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 2, Quality = 4 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(1));
    }
    
    [Test]
    public void ItemSellInDecreaseWhenUpdateQualityMultipleTimes()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "An Item", SellIn = 2, Quality = 3 });
        
        app.UpdateQuality();
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.Zero);
    }
    
    [Test]
    public void MultipleItemsSellInDecreasesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 2, Quality = 4 },
            new Item { Name = "Another Item", SellIn = 1, Quality = 3 }
        };
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(items);
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(1));
        Assert.That(result[1].SellIn, Is.Zero);
    }

    [Test]
    public void SulfurasPropertiesNeverChangesWhenUpdateQualityIsCalled()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var app = new GildedRose(new ItemUpdaterFactory());
        
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void AgedBrieQualityIncreasesWhenUpdateQualityIsCalled()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "Aged Brie", SellIn = 1, Quality = 7 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(0));
        Assert.That(result[0].Quality, Is.EqualTo(8));
    }

    [Test]
    public void BackstageQualityIncreaseWhenSellInOver10()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 7 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(10));
        Assert.That(result[0].Quality, Is.EqualTo(8));
    }
    
    [Test]
    public void BackstageQualityIncreaseDoubleWhenSellInIsUnder10()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 7 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(9));
        Assert.That(result[0].Quality, Is.EqualTo(9));
    }
    
    [Test]
    public void BackstageQualityIncreaseTripleWhenSellInIsUnder5()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 7 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.EqualTo(4));
        Assert.That(result[0].Quality, Is.EqualTo(10));
    }

    [Test]
    public void BackstageQualityDropsToZeroAfterConcert()
    {
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 21 });
        
        app.UpdateQuality();
        
        var result = app.GetInventory();
        Assert.That(result[0].SellIn, Is.Negative);
        Assert.That(result[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void AddOneItemWhenAddItemToInventoryIsCalled()
    {
        var item = new Item { Name = "An Item", SellIn = 0, Quality = 21 };
        var app = new GildedRose(new ItemUpdaterFactory());
        
        app.AddItemToInventory(item);

        var result = app.GetInventory();
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Name, Is.EqualTo("An Item"));
    }
    
    [Test]
    public void AddMultipleItemWhenAddItemToInventoryIsCalled()
    {
        var items = new List<Item>();
        var itemsList = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 0, Quality = 21 },
            new Item { Name = "Another Item", SellIn = 4, Quality = 12 }
        };
        var app = new GildedRose(new ItemUpdaterFactory());
        
        app.AddItemToInventory(items);
        
        Assert.That(itemsList.Count, Is.EqualTo(2));
        Assert.That(itemsList[0].Name, Is.EqualTo("An Item"));
        Assert.That(itemsList[1].Name, Is.EqualTo("Another Item"));
    }

    [Test]
    public void GetNullWhenThereAreNotItemsInInventory()
    {
        var itemsList = new List<Item>();
        var app = new GildedRose(new ItemUpdaterFactory());
        
        var inventory = app.GetInventory();
        
        Assert.That(inventory.Count, Is.Zero);
    }
    
    [Test]
    public void GetItemListWhenGetInventoryIsCalled()
    {
        var itemsList = new List<Item>
        {
            new Item { Name = "An Item", SellIn = 11, Quality = 10 },
            new Item { Name = "Another Item", SellIn = 5, Quality = 11 }
        };
        var app = new GildedRose(new ItemUpdaterFactory());
        app.AddItemToInventory(itemsList);
        
        var inventory = app.GetInventory();

        Assert.That(inventory.Count, Is.EqualTo(2));
        Assert.IsTrue(inventory.Any(i => i.Name.Equals("An Item")));
        Assert.IsTrue(inventory.Any(i => i.Name.Equals("Another Item")));
    }
}