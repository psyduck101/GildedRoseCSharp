
using FluentAssertions;
using GildedRoseProgram;
using GildedRoseProgram.Interfaces;
using GildedRoseProgram.Model;
using GildedRoseProgram.Model.Processors;
using NUnit.Framework;
using System;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private IItemProcessorFactory ItemProcessorFactory { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            ItemProcessorFactory = new ItemProcessorFactory(); 
        }

        //categories: normal, aged brie, legendary item, backstage pass, conjured

        [Test]
        public void Given_Null_Items_When_GildedRose_Constructed_Then_ArgumentNullException()
        {
            Action act = () => new GildedRose(null, ItemProcessorFactory);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Given_Null_Factory_When_GildedRose_Constructed_Then_ArgumentNullException()
        {
            Action act = () => new GildedRose(new Item[] { }, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Given_Valid_Factory_And_Items_When_GildedRose_Constructed_Then_Valid_Construct()
        {
            var gr = new GildedRose(new Item[] { }, ItemProcessorFactory);

            gr.Should().NotBeNull();
        }

        //did not use testname, because it would not execute the test, and time restraints
        [Test]
        [TestCase(null, 0, 0, 0, 0, 0)]
        [TestCase("", 0, 0, 0, 0, 0)]
        [TestCase("Aged Brie",1, 2, 0, 1, 1)]
        [TestCase("Vest",1, 10, 20, 9, 19)]
        [TestCase("Elixir", 1, 5, 7, 4, 6)]
        [TestCase("Sulfuras, Hand of Ragnaros",1, 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert",1, 15, 20, 14, 21)]
        [TestCase("Conjured Mana Cake",1,10,10,9,8)]
        [TestCase("Conjured Mana Cake", 4, 2, 4, -2, 0)]
        [TestCase("Conjured Mana Cake", 4, 2, 20, -2, 8)]
        [TestCase("Aged Brie", 15, 2, 0, -13, 28)]
        [TestCase("Vest", 15, 10, 20, -5, 0)]
        [TestCase("Elixir", 15, 5, 7, -10, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 15, 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 15, 20, 0, 50)]
        [TestCase("Conjured Mana Cake", 4, 2, 20, -2, 8)]
        [TestCase("Aged Brie", 30, 2, 0, -28, 50)]
        [TestCase("Vest", 30, 10, 20, -20, 0)]
        [TestCase("Elixir", 30, 5, 7, -25, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 30, 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 30, 15, 20, -15, 0)]
        [TestCase("Conjured Mana Cake", 30, 30, 100, 0, 40)]
        public void Given_item_When_Day_Expires_Then_Item_Properly_Updated(string name, int days, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };

            var gildedRoseApp = new GildedRose(new[] { item }, ItemProcessorFactory);

            for(int i=0;i<days;i++)
                gildedRoseApp.UpdateQuality();

            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }

    }
}
