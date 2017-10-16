using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class Gradance
    {
        public static void DegradeBy(int number, Item item)
        {
            item.Quality = item.Quality - number;
        }

        public static void UpgradeBy(int number, Item item)
        {
            item.Quality = item.Quality + number;
        }
    }
}
