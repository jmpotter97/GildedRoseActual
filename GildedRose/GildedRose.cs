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
                
                if (Items[i].SellIn > 0)
                {
                    if (Items[i].Name.IndexOf("Aged Brie") == -1 &&
                        Items[i].Name.IndexOf("Backstage passes to a TAFKAL80ETC concert") == -1)
                    {
                        Items[i].Quality = DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            int degradeBy = CheckConjure(Items[i].Name, Items[i].SellIn);
                            Items[i].Quality = Items[i].Quality + degradeBy;
                            if (Items[i].Name.IndexOf("Backstage passes to a TAFKAL80ETC concert") != -1)
                            {
                                if (Items[i].SellIn < 11)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality =
                                            DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                                    }
                                }
                                if (Items[i].SellIn < 6)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality =
                                            DegradeQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                                    }
                                }
                            }
                        }
                    }
                }


                if (Items[i].SellIn <= 0)
                {
                    if (Items[i].Name.IndexOf("Aged Brie") == -1)
                    {
                        if (Items[i].Name.IndexOf("Backstage passes to a TAFKAL80ETC concert") == -1)
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
                            Items[i].Quality = SortQuality(Items[i].Name, Items[i].SellIn, Items[i].Quality);
                    }
                }
                Items[i].SellIn = DecreaseSellIn(Items[i].Name, Items[i].SellIn);
                if (Items[i].Quality < 0) Items[i].Quality = 0;
            }
        }

        public int DecreaseSellIn(string name, int sellin)
        {
            if (name != "Sulfuras, Hand of Ragnaros")
            {
                sellin = sellin - 1;
            }
            return sellin;
        }
        public int SortQuality(string name, int sellin, int quality)
        {
            if (quality < 50)
            {
                quality = DegradeQuality(name, sellin, quality);
            }
            return quality;
        }
        public int CheckConjure(string name, int sellin)
        {
            int degradeBy = 1;

            if (sellin <= 0)
            {
                degradeBy = degradeBy * 2;
            }
            if (name.IndexOf("Conjured") != -1)
            {
                degradeBy = degradeBy * 2;
            }
            return degradeBy;
        }

        public int DegradeQuality(string name, int sellin, int quality)
        {
            string betterorworse = BetterOrWorseQuality(name);
            int degradeBy = CheckConjure(name, sellin);
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