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
            if (item.SellIn >= 1 && item.Quality >=1)
            {
                Gradance.DegradeBy(1, item);
            }
            if (item.SellIn <= 0 && item.Quality <=2)
            {
                Gradance.DegradeBy(2, item);
            }
        }
    }
}
