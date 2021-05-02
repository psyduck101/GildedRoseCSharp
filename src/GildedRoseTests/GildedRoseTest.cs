using csharp;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {

        //categories: normal, aged brie, legendary item, backstage pass, conjured

        //TODO BJB : Add conjured
        //check why testname not working
        [Test]
        [TestCase("Aged Brie",1, 2, 0, 1, 1)] //TestName = "When_Aged_Brie_1_Day_Older_Then_SellIn_Is_1_Lower_And_Quality_Is_1_Higher"
        [TestCase("Vest",1, 10, 20, 9, 19)]// TestName = "When_Vest_1_Day_Older_Then_SellIn_Is_1_Lower_And_Quality_Is_1_Lower")]
        [TestCase("Sulfuras, Hand of Ragnaros",1, 0, 80, 0, 80)]// TestName = "When_Legendary_1_Day_Older_Then_SellIn_Is_Same_And_Quality_Is_Same")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert",1, 15, 20, 14, 21)]// TestName = "When_Backstage_1_Day_Older_Then_SellIn_Is_1_Lower_And_Quality_Is_1_Higher")]
        [TestCase("Aged Brie", 15, 2, 0, -13, 28)]
        [TestCase("Vest", 15, 10, 20, -5, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 15, 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 15, 20, 0, 50)]
        [TestCase("Aged Brie", 30, 2, 0, -28, 50)]
        [TestCase("Vest", 30, 10, 20, -20, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 30, 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 30, 15, 20, -15, 0)]
        public void Given_item_When_Day_Expires_Then_Item_Properly_Updated(string name, int days, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };

            var gildedRoseApp = new GildedRose(new[] { item });

            for(int i=0;i<days;i++)
                gildedRoseApp.UpdateQuality();

            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
    }
}
