using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    class Importer : IPurchase
    {
        private string name;
        private LinkedList<Product> ShoppingList = new LinkedList<Product>(); // The property includes the list of products the supermarket buys from the importer.
        private double TotalPrice = 0;
        public Importer(string name) { this.name = name; }
        public string Getname() => this.name;
        public LinkedList<Product> Getproducts() => this.ShoppingList;
        public double GetTotalPrice() => this.TotalPrice;
        public void Setname(string name) { this.name = name; }
        public void Setproducts(LinkedList<Product> ShoppingList) { this.ShoppingList = ShoppingList; }
        public void SetTotalPrice(double TotalPrice) { this.TotalPrice = TotalPrice; }
        public void CalculateTotalPrice()
        { // The function calculates the price of the products the supermarket has bought from the importer.
                HandleSupply();
                this.TotalPrice = 0;
                foreach (var item in this.ShoppingList)
                    this.TotalPrice += item.GetPrice();
        }
        public void AddProduct(Product product, int NumofUnits)
        { // The function Adds a product to the cart the number of times the supermarket requested.
            for (int i = 0; i < NumofUnits; i++)
                this.ShoppingList.AddLast(new LinkedListNode<Product>(product));
        }
        public void DeleteProduct(Product product, int NumofUnits)
        {// The function Deletes a product to the cart the number of times the supermarket requested.
            if (NumofUnits > this.ShoppingList.CountAppearances(product))
                for (int i = 0; i < this.ShoppingList.CountAppearances(product); i++)
                    this.ShoppingList.Remove(product);
            else
                for (int i = 0; i < NumofUnits; i++)
                    this.ShoppingList.Remove(product);
        }

        public void HandleSupply()
        {
            // The function checks if the supermarket asks for more units than the importer has to offer.
            LinkedList<Product> temp = new LinkedList<Product>(this.ShoppingList);
            foreach(var item in temp)
            {
                if(item.Getsupply() < this.ShoppingList.CountAppearances(item))
                {
                    for (int i = 0; i < this.ShoppingList.CountAppearances(item)-item.Getsupply(); i++)
                    {
                        this.ShoppingList.Remove(item);
                        Console.WriteLine($"There is not enough supply for this product so we give you only {item.Getsupply()} units of {item.Getname()}" );
                    }
                }
            }
        }

        public void Purchase()
        {
            // The function commits a purchase of all the products the supermarket requested.
            LinkedList<Product> setlist = this.ShoppingList.DeleteDuplicates();
            CalculateTotalPrice();
            foreach (var item in setlist)
                Console.WriteLine($"You have purchased the item: {item.Getname()} x{this.ShoppingList.CountAppearances(item)}");
            Console.WriteLine($"In total price of {this.TotalPrice} NIS\nfrom the importer: {this.name} \n \n \n \n \n \n \n");
        }
    }
}
