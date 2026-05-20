namespace GildedRoseKata.Items.ItemUpdaters;

public class AgedItemUpdater : ItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
                
        item.SellIn -= 1;

        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}