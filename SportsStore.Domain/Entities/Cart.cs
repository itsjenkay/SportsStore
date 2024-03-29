﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public  class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //for adding product item to cart
        public void AddItem(Product product,int quantity)
        {
            CartLine line = lineCollection
                                    .Where(p => p.Product.ProductID == product.ProductID)
                                    .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        // for removing item from cart

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        public decimal ComputTotalValue()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
