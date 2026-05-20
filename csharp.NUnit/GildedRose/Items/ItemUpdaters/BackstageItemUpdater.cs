namespace GildedRoseKata.Items.ItemUpdaters;

public class BackstageItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
                    
            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
                
        item.SellIn -= 1;
                
        if (item.SellIn < 0)
        {
            item.Quality -= item.Quality;
        }
    }
}