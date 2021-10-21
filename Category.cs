using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    internal class Category // The class is inheriting from class object.
    {
        public static int NumofCategories = 0; // The number of types of products the supermarket sells.
        private string category; // Which type of products are on the shelf in this division.
        private int Division; // Where are the shelves related to this category.
        private LinkedList<Product> products = new LinkedList<Product>();
        public Category(int Division, string category)
        {
            NumofCategories++;
            this.Division = Division;
            this.category = category;

        }
        // Implementation of the encapsulation principal here by determining the properties access modifier as private.
        public int GetnumofCategories() => NumofCategories;
        public string Getcategory() => this.category;
        public int Getdivision() => this.Division;

        public LinkedList<Product> GetList() => this.products;
        public void Setlist(LinkedList<Product> products) { this.products = products; }
        public override string ToString() // this function overrides the ToString function of the default base class - object
        {
            this.products.DeleteDuplicates().PrintList();
            return $"The category of {this.category} " + $"is placed in division {this.Division}";
        }

    
    }
}
