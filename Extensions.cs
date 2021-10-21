using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    internal static class Extensions
    {
        public static int CountAppearances(this LinkedList<Product> list, Product product)
        {// This function recieves a product and returns the amount of times it appears in the list.
            LinkedList<Product> temp = new LinkedList<Product>(list);
            int counter = 0;
            int Length = list.Count;
            for (int i = 0; i < Length; i++)
            {
                if (temp.Contains(product))
                {
                    counter++;
                    temp.Remove(product);
                }     
            }
            return counter;
        }
        public static int CountAppearances(this LinkedList<Product> list, string name)
        {// This function recieves a name of a product and returns the amount of times it appears in the list.
            LinkedList<Product> temp = new LinkedList<Product>(list);
            int counter = 0;
            int Length = list.Count;
            for (int i = 0; i < Length; i++)
            {
                if (temp.First.Value.Getname() == name)
                    counter++;
                temp.RemoveFirst();
            }
            return counter;
        }
        public static Product Find(this LinkedList<Product> list, string name)
        {// This function recieves a name of a product and returns the Product.
            LinkedList<Product> temp = new LinkedList<Product>(list);
            int Length = list.Count;
            for (int i = 0; i < Length; i++)
            {
                if (temp.First.Value.Getname() == name)
                    return temp.First.Value;
                temp.RemoveFirst();
            }
            return null;
        }
        public static LinkedList<Product> DeleteDuplicates(this LinkedList<Product> list)
        {// This function returns the list without duplicates.
            LinkedList<Product> NewList = new LinkedList<Product>();
            foreach(var item in list)
            {
                if (!NewList.Contains(item))
                    NewList.AddFirst(item);
            }
            return NewList;
        }
        public static void PrintList(this LinkedList<Product> list)
        { // The function prints the list.
            foreach (var item in list)
                Console.WriteLine(item);
        }

    }
}
