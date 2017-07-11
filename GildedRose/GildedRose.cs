using System.Collections;
using System.Collections.Generic;
using System.Net;


namespace GildedRose
{
    class GildedRose
    {
        private IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {     
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                        Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        int degradeBy = CheckConjure(Items[i].Name);
                        Items[i].Quality = Items[i].Quality + degradeBy;
                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                                }
                            }
                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                                }
                            }
                        }
                    }
                }
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                                    Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                        }
                    }
                }
                if (Items[i].Quality < 0) Items[i].Quality = 0;
            }
        }

        public int CheckQuality(int quality)
        {
            return quality;
        }
        public int CheckConjure(string name)
        {
            int degradeBy;
            if (name.IndexOf("Conjured") != -1)
            {
                degradeBy = 2;
            }
            else
            {
                degradeBy = 1;
            }
            return degradeBy;
        }

        public int DegradeQuality(string name, int sellin, int quality)
        {
            string betterorworse = BetterOrWorseQuality(name);
            int degradeBy = CheckConjure(name);
            if (betterorworse == "increase")
            {
                quality = quality + degradeBy;
            }
            else if (betterorworse == "decrease")
            {
                quality = quality - degradeBy;
            }
            return quality;
        }

        public string BetterOrWorseQuality(string name)
        {
            string betterorworse;
            if (name.IndexOf("Aged Brie") != -1 || name.IndexOf("Backstage") != -1)
            {
                betterorworse = "increase";
            }
            else if (name.IndexOf("Sulfuras") != -1)
            {
                betterorworse = "do nothing";
            }
            else
            {
                betterorworse = "decrease";
            }
            return betterorworse;
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}