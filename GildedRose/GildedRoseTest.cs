using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture()]
    public class GildedRoseTest
    {
        [Test()]
        public void VestTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }};
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(19, Items[0].Quality);
        }

        [Test()]
        public void BrieTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(1, Items[0].Quality);
        }

        [Test()]
        public void MongooseTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test()]
        public void SulfurasTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test()]
        public void BackstageTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(14, Items[0].SellIn);
            Assert.AreEqual(21, Items[0].Quality);
        }

        [Test()]
        public void ConjuredTester()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
        }
    }
}