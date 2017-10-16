using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class ItemBehaviour
    {
        public static void DexerxityVestBehaviour(Item item)
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

        public static void MoongooseBehaviour(Item item)
        {
            if(item.SellIn >= 1 && item.Quality >= 1)
            {
                QualityAdjustment.DegradeBy(1, item);
            }
            if (item.SellIn <= 0 && item.Quality >= 1)
            {
                QualityAdjustment.DegradeBy(item.Quality == 1 ? 1 : 2, item);
            }
            item.SellIn -= 1;
        }

        public static void AgedBrieBehaviour(Item item)
        {
            {
                if(item.SellIn >= 1 && item.Quality >= 49)
                {
                    QualityAdjustment.DegradeBy(1, item);
                }
                if (item.SellIn <= 0 && item.Quality >= 49)
                {
                    QualityAdjustment.DegradeBy(item.Quality == 49 ? 1: 2, item);
                }
                item.SellIn -= 1;
            }

        }

        public static void ConcertTicketBehaviour(Item item)
        {
            if (item.SellIn <= 10 && item.SellIn >= 6 && item.Quality <= 48)
            {
                QualityAdjustment.UpgradeBy(2,item);
            }
        }
    }
}

