using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "+5 Dexterity Vest":
                    case "Elixir of the Mongoose":
                        ItemBehaviour.MongooseVest(item);
                        break;
                    case "Aged Brie":
                        ItemBehaviour.AgedBrieBehaviour(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        ItemBehaviour.ConcertTicketBehaviour(item);
                        break;
                    case "Conjured Mana Cake":
                        ItemBehaviour.ConjuredManaCake(item);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}