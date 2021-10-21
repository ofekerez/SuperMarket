using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace SuperMarket
{
    class ShoppingCart : IPurchase 
    {
        private int NumofProducts; // The number of the products in the cart.
        private double TotalPrice; // The total price of all the products in the cart.
        private LinkedList<Product> products; // The list of the products added to the cart.

        public ShoppingCart()
        {
            this.NumofProducts = 0;
            this.TotalPrice = 0;
            this.products = new LinkedList<Product>();
        }
        public int GetNumofProducts() => this.NumofProducts;
        public double GetTotalPrice()
        {
            this.CalculateTotalPrice();
            return this.TotalPrice;
        }
        public LinkedList<Product> GetList() => this.products;
        public virtual void AddProduct(Product product, int NumofUnits)
        { // The function Adds a product to the cart the number of times the user requested.
            if (product.Getsupply() < NumofUnits)
            {
                NumofUnits = product.Getsupply();
                // Checking if the amount of units the user requested is greater than the supply.
                Console.WriteLine($"There is not enough supply for this product so we give you only {product.Getsupply()} units of {product.Getname()}");
            } 
            for (int i = 0; i < NumofUnits; i++)
                this.products.AddLast(new LinkedListNode<Product>(product));
            this.NumofProducts += NumofUnits;
        }
        public virtual void DeleteProduct(Product product, int NumofUnits)
        {// The function Deletes a product from the cart the number of times the user requested.
            if (NumofUnits > this.products.CountAppearances(product))
                for (int i = 0; i < this.products.CountAppearances(product); i++)
                    this.products.Remove(product);
            else
                for (int i = 0; i < NumofUnits; i++)
                    this.products.Remove(product);
            this.NumofProducts -= NumofUnits;
        }
        public void HandleSupply()
        {// The function updates the supply.
            LinkedList<Product> setlist = this.products.DeleteDuplicates();
            foreach (var item in setlist)
                item.Setsupply(item.Getsupply() - this.products.CountAppearances(item));
        }
        public void CalculateTotalPrice()
        { // The function calculates the total price of the cart.
            this.TotalPrice = 0;
            foreach (var item in this.products)
                this.TotalPrice += item.GetPrice();
            
        }

        public void Purchase()
            // The function commits a purchase of all the products in the cart.
        {   LinkedList<Product> setlist = this.products.DeleteDuplicates();
            CalculateTotalPrice();
            foreach (var item in setlist)
                Console.WriteLine($"You have purchased the item: {item.Getname()} x{this.products.CountAppearances(item)} units\n");
            Console.WriteLine($"In total price of {this.TotalPrice} NIS");
            HandleSupply();
        }

        public override string ToString()
        {
            CalculateTotalPrice();
            string s = "";
            foreach (Product item in this.products)
                s += item.ToString() +" x"+ this.products.CountAppearances(item); 
            s += $"\n The total Number of products is: {this.NumofProducts}\n" + $"The total price of the cart is: {this.TotalPrice}";
            return s;
        }
    }
}
