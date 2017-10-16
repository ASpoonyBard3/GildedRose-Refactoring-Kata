using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }

        [Test]
        public void QualityNotNegative()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "foo", SellIn = 0, Quality = 5} };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }

        [Test]
        public void QualityNotOverFifty()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "foo", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.LessOrEqual(Items[0].Quality, 50);
        }

        [Test]
        public void SulfurasDoesNotChange()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            if (Items[0].Name == "Sulfuras, Hand of Ragnaros")
            {
                for (int i = 0; i < 31; i++)
                {
                    Assert.AreEqual(Items[0].Quality, 80);
                    app.UpdateQuality();
                }
            }

        }
        [Test]
        public void QualityDegradesTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "random", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            if (Items[0].Name != "Aged Brie" && Items[0].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[0].SellIn <0 && Items[0].Name != "Sulfuras, Hand of Ragnaros")
                Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void BrieQualityIncrease()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            if(Items[0].Name != "Aged Brie"  && Items[0].SellIn <= 0)
                Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void ConcertQualityBehaviour()
        {
            IList<Item> Items = new List<Item>
            {
                new Item() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10},
                new Item() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10},
                new Item() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0}
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            if (Items[0].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[0].SellIn <= 10 && Items[0].SellIn >= 6)
                Assert.AreEqual(12, Items[0].Quality);
            if (Items[1].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[0].SellIn <= 5 && Items[0].SellIn >= 1)
                Assert.AreEqual(Items[1].Quality, 13);
            if (Items[2].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[0].SellIn <= 0)
                Assert.AreEqual(0, Items[2].Quality);
        }
        [Test]
        public void ConjuredBehaviour()
        {
            IList<Item> Items = new List<Item>
            {
                new Item() {Name = "Conjured Mana Cake", SellIn = 0, Quality = 10},
                new Item() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 10},
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            if (Items[0].Name == "Conjured Mana Cake" && Items[0].SellIn <= 0)
                Assert.AreEqual(6, Items[0].Quality);
            if (Items[1].Name == "Conjured Mana Cake" && Items[0].SellIn >= 1)
                Assert.AreEqual(Items[1].Quality, 8);
        }

        [Test]
        public void OrdinaryDegrade()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "", SellIn = 3, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            if (Items[0].Name != "Aged Brie" && Items[0].Name != "Backstage passes to a TAFKAL80ETC concert" && 
                Items[0].Name != "Sulfuras, Hand of Ragnaros" &&
                Items[0].SellIn < 0)
                Assert.AreEqual(9, Items[0].Quality);
        }
    }
}
