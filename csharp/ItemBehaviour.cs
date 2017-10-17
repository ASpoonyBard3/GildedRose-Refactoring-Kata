using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemBehaviour
    {
        public static void MongooseVest(Item item)
        {
            if(item.SellIn >= 1 && item.Quality >= 1)
            {
                QualityAdjustment.DegradeBy(1, item);
            }
            if (item.SellIn <= 0 && item.Quality >= 2)
            {
                QualityAdjustment.DegradeBy(item.Quality == 1 ? 1 : 2, item);
            }
            item.SellIn -= 1;
        }
        
        public static void AgedBrieBehaviour(Item item)
        {
            {
                if(item.SellIn >= 1 && item.Quality <= 49)
                {
                    QualityAdjustment.UpgradeBy(1, item);
                }
                if (item.SellIn <= 0 && item.Quality <= 49)
                {
                    QualityAdjustment.UpgradeBy(item.Quality == 49 ? 1: 2, item);
                }
                item.SellIn -= 1;
            }
        }

        public static void ConcertTicketBehaviour(Item item)
        {
            if (item.SellIn >= 11 && item.Quality <= 50)
                QualityAdjustment.UpgradeBy(item.Quality == 50 ? 0 : 1, item);
            if (item.SellIn <= 10 && item.SellIn >= 6 && item.Quality <= 49)
                QualityAdjustment.UpgradeBy(item.Quality == 49 ? 1 : 2, item);
            if (item.SellIn <= 5 && item.SellIn >= 1 && item.Quality <= 47)
                QualityAdjustment.UpgradeBy(3, item);
            if (item.SellIn <= 5 && item.SellIn >= 1 && item.Quality >= 48)
                item.Quality = 50;
            if (item.SellIn <= 0)
                item.Quality = 0;
            item.SellIn -= 1;
        }

        public static void ConjuredManaCake(Item item)
        {
            if (item.SellIn >= 1 && item.Quality >= 1)
            {
                QualityAdjustment.DegradeBy(item.Quality == 1 ? 1 : 2, item);
            }
            if (item.SellIn <= 0 && item.Quality >= 4)
            {
                QualityAdjustment.DegradeBy(4, item);
            }
            if (item.SellIn <= 0 && item.Quality <= 3 && item.Quality >= 1)
                item.Quality = 0;

            item.SellIn -= 1;
        }
    }
}

