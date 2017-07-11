using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture()]
    public class GildedRoseTest
    {
        [Test()]
        public void TestIfNormalValuesQualityDecreasesBy1()
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
        public void TestIfAgedBrieQualityIncreasesWithTime()
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
        public void TestIfSulfurasHandOfRagnarosDoesNotChangeSellInOrQuality()
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
        public void TestIfBackstagePassesQualityIncreasesBy1IfSellInIsGreaterThanTenDays()
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
        public void TestIfBackstagePassesQualityIncreasesBy2IfSellInIsLessThanTenDays()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(8, Items[0].SellIn);
            Assert.AreEqual(22, Items[0].Quality);
        }

        [Test()]
        public void TestIfBackstagePassesQualityIncreasesBy3IfSellInIsLessThanFiveDays()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(3, Items[0].SellIn);
            Assert.AreEqual(23, Items[0].Quality);
        }

        [Test()]
        public void TestIfBackstagePassesQualityIs0IfSellInIsLessThan0Days()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test()]
        public void TestIfAddingConjuredToNormalDecreasesQualityTwiceAsFast()
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

        [Test()]
        public void TestIfAddingConjuredToAgedBrieIncreasesQualityTwiceAsFast()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Aged Brie", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test()]
        public void TestIfAddingPastSellInForNormalDecreasesQualityTwiceAsFast()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Mongoose", SellIn = -1, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
        }

        [Test()]
        public void TestIfAddingPastSellInForConjuredDecreasesQualityTwiceAsFast()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Aged Brie", SellIn = -1, Quality = 8 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.UpdateQuality();
            //Assert
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(12, Items[0].Quality);
        }
    }
}