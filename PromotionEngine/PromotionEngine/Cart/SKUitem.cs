﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Items
{
    public class SKUitem
    {
        public string ID { get; }
        public float UnitPrice { get; }

        public SKUitem(string id, float unitPrice)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Invalid or missing SKU id!");
            if (unitPrice <= 0) throw new ArgumentException("Invalid unit price! It must be grater than zero!");

            ID = id;
            UnitPrice = unitPrice;
        }
}
}