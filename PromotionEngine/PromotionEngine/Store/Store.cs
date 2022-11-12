﻿using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Store
{
    public class Store
    {
        public Cart Cart { get; private set; }
        public List<PromotionRule> Promotions { get; }
        public List<SKUitem> Items { get; }
        public Store()
        {
            Cart = new Cart();
            Promotions = new List<PromotionRule>();
            Items = new List<SKUitem>();
        }

        public Store AddSKUitem(SKUitem item)
        {
            f( item != null ) Items.Add(item);
            return this;
        }

        public Store AddPromotions(List<PromotionRule> promotions)
        {
            if ( promotions != null && promotions.Count > 0 )Promotions.AddRange(promotions);
            return this;
        }

        public Store AddPromotion(PromotionRule promotion)
        {
            if ( promotion != null ) Promotions.Add(promotion);sss
            return this;
        }

        public Store AddItemToCart(string itemSKU)
        {
            if ( !string.IsNullOrWhiteSpace(itemSKU) ) Cart.AddItem(Items.First(i => itemSKU.Equals(i.ID)));
            return this;
        }

        public Store EmptyCart()
        {
            Cart = new Cart();
            return this;
        }

        public Store Checkout()
        {
             Promotions.ForEach(p => { if (p.IsApplicable(Cart)) p.Execute(Cart); });
            return this;
        }
    }
}