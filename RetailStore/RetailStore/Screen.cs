﻿using System;

namespace RetailStore
{
    public class Screen
    {
        public string Text { get; private set; }

        public void ShowProduct(string product)
        {
            Text = product;
        }

        public void ShowInvalidBarcode()
        {
            Text = "Invalid barcode: please try to scan the product again.";
        }

        internal void ShowProductNotFound(string barcode)
        {
            Text = $"Product not found for barcode {barcode}";
        }
    }
}