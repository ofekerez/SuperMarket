using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    class Product : Category
    {
        private static int NumofProducts = 0; // Property of the number of products the supermarket has to offer.
        private int supply; // The current number of units from the product available in the supermarket or the importer.
        private string ProductName; // The product name.
        private double Price; // The price for one unit of the product.
        private string Company; // The name of the company that created the product.
        private bool OnSale; // Determines whether or not the product is on sale.
        private double DiscountPrecentage; // The precentage of the discount on this product.
        
        public Product(int supply, string productName, double price, string company, bool onSale, double discountPrecentage, int Division, string category) : base(Division, category)
        {

            this.supply = supply;
            this.ProductName = productName;
            this.Price = price;
            this.Company = company;
            this.OnSale = onSale;
            this.DiscountPrecentage = discountPrecentage;
            NumofProducts++;
        }
        public Product(string productName, double price, string company, int Division, string category) : base(Division, category)
        { // Implementation of Polymorphism by method overloading.
            this.supply = 0;
            this.ProductName = productName;
            this.Price = price;
            this.Company = company;
            this.OnSale = false;
            this.DiscountPrecentage = 0;
            NumofProducts++;
        }
        public int Getsupply() => this.supply;
        public double GetPrice() => this.Price;
        public string GetCompany() => this.Company;
        public bool IsonSale() => this.OnSale;
        public double GetDiscountPercentage() => this.DiscountPrecentage;
        public string Getname() => this.ProductName;
        public int GetNumofProducts() => NumofProducts;
        public void Setsupply(int supply) { this.supply = supply; }
        public void SetPrice(double price) { this.Price = price; }
        public void SetCompany(string company) { this.Company = company; }
        public void SetonSale() { this.OnSale = !this.OnSale; }
        public void SetDiscountPercentage(int discount) { this.DiscountPrecentage = discount; }
        public void Setname(string name) { this.ProductName = name; }
        public void ActivateSale()
        { // The function changes the price of the product according to the sale's condition.
            Random random = new Random();
            this.DiscountPrecentage = Math.Round(random.NextDouble() * 100);
            this.OnSale = true;
            this.Price -= this.Price / 100 * this.DiscountPrecentage;
        }
        public void DeactivateSale()
        {
            // The function changes the price of the product according to the sale's condition.
            this.OnSale = false;
            this.Price = this.Price / (100 - this.DiscountPrecentage) * 100;
            this.DiscountPrecentage = 0;
        }
        public override string ToString() 
        {
        
            return base.ToString() + $"\nThe product name is: {this.ProductName}" 
                + $"\nThe supply is: {this.supply}\n"
                + $"The price is: {this.Price}\n"
                + $"The Company name: {this.Company}\n"
                + (!this.OnSale ? "The item is not on sale": "The item is on sale")
                + "\n" + (this.OnSale ? $"The discount for this product is: {this.DiscountPrecentage}%": "");
        }

    }
}
