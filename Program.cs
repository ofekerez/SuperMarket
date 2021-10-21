using System;
using System.Collections;
using System.Collections.Generic;
namespace SuperMarket
{
    public class Program
    {


       internal static void UserInterface(Category [] categories, Importer importer)
        {
            Console.WriteLine("There are 8 categories in our supermarket: Meat, Dairy, Fish, Drinks, Cosmetics, Breads, Fruit and Vegetables.");
            string result;
            bool Done = false;
            string productname;
            int units;
            int result_units;
            Random random = new Random();
            int NumOnSale;
            ShoppingCart shoppingCart = new ShoppingCart();
            LinkedList<Product> copy;
            for (int i = 0; i < categories.Length; i++)
            {
                copy = new LinkedList<Product>(categories[i].GetList());
                NumOnSale = random.Next(0, copy.Count/2);
                for (int k = 0; k < NumOnSale; k++)
                {
                    categories[i].GetList().Find(copy.First.Value).Value.ActivateSale();
                    if (categories[i].GetList().Find(copy.First.Value).Value.GetPrice() < importer.Getproducts().Find(copy.First.Value).Value.GetPrice())
                        categories[i].GetList().Find(copy.First.Value).Value.DeactivateSale();
                    copy.RemoveFirst();
                }
                if (categories[i].GetList().Find(copy.First.Value).Value.GetPrice() < importer.Getproducts().Find(copy.First.Value).Value.GetPrice())
                {
                    categories[i].GetList().Find(copy.First.Value).Value.DeactivateSale();
                    NumOnSale--;
                }
                Console.WriteLine(categories[i]);
                Console.WriteLine("For each and every product you pay 10 % more of its price due to taxes");
                Console.WriteLine($"The number of products on sale in this category is: {NumOnSale}");
                while (!Done)
                {

                    try
                    {
                        Console.WriteLine("Enter the product name please: ");
                        productname = Console.ReadLine();
                        if (productname.ToLower() == "s" || productname.ToLower() == "skip")
                            break;
                        Console.WriteLine("Enter the number of units you want from the product please: ");
                        units = int.Parse(Console.ReadLine());
                        
                    }
                    catch(Exception)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Re-enter the product name please: ");
                                productname = Console.ReadLine();
                                Console.WriteLine("Re-enter the number of units please ");
                                units = int.Parse(Console.ReadLine());  
                                break;
                            }
                            catch
                            {
                                continue;
                            }
                        } 
                    }

                    if (categories[i].GetList().CountAppearances(productname) > 0)
                    {
                        shoppingCart.AddProduct(categories[i].GetList().Find(productname), units);
                        Console.WriteLine("Item added successfully to your shopping cart");
                    }
                    else
                    {
                        Console.WriteLine("You have to choose a product which appears in the list");
                        Console.WriteLine(categories[i]);
                        continue;
                    }
                    Console.WriteLine("Do you want to add another product?");
                    result = Console.ReadLine();
                    if (result.ToLower() == "yes" || result.ToLower() == "y")
                        continue;
                    else
                        if (result.ToLower() == "exit" || result.ToLower() == "no" || result.ToLower() == "n")
                                break;
                }
            }
            Console.WriteLine(shoppingCart);
            Console.WriteLine("Do you want to delete an item from your cart or purchase?" );
            result = Console.ReadLine();
            if (result.ToLower() == "delete" || result.ToLower() == "del" || result.ToLower() == "d")
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Which item would you like to delete?");
                        result = Console.ReadLine();
                        Console.WriteLine("How many units of this item ?");
                        result_units = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        continue;
                    }
                    for (int i = 0; i < categories.Length; i++)
                    {
                        if (categories[i].GetList().CountAppearances(result) > 0)
                            shoppingCart.DeleteProduct(categories[i].GetList().Find(result), result_units);
                    }
                    break;
                }
            }
            else
                shoppingCart.Purchase();


        }
        static void Main(string[] args)
        {
            // Defining Categories:
            Category Meat = new Category(Category.NumofCategories + 1, "Meat");
            Category Dairy = new Category(Category.NumofCategories + 1, "Dairy");
            Category Fish = new Category(Category.NumofCategories + 1, "Fish");
            Category Drinks = new Category(Category.NumofCategories + 1, "Drinks");
            Category Breads = new Category(Category.NumofCategories + 1, "Breads");
            Category Cosmetics = new Category(Category.NumofCategories + 1, "Cosmetics");
            Category Fruit = new Category(Category.NumofCategories + 1, "Fruit");
            Category Vegetables = new Category(Category.NumofCategories + 1, "Vegetables");
            Category[] categories = { Meat, Dairy, Fish, Drinks, Breads, Cosmetics, Fruit, Vegetables };
            // Defining Products:
            Product Chickenleg = new Product(100, "Chickenleg", 40, "Good Chicken",false, 0, 1, "Meat");
            Product Chickenbreast = new Product(50, "Chickenbreast", 60, "Good Chicken",false,0, 1, "Meat");
            Product Chickenwings = new Product(80, "Chickenwings", 30, "Good Chicken",false,0, 1, "Meat");
            Product Steak = new Product(20,"Steak", 120, "Butcher",false,0, 1, "Meat");
            Product Kebab = new Product(30,"Kebab", 20, "Zoglobek",false,0, 1, "Meat");
            Product Milk = new Product(70,"Milk", 8, "Tnuva",false,0, 2, "Dairy");
            Product Cheese = new Product(45,"Yellow Cheese", 20, "Emek",false,0, 2, "Dairy");
            Product BlueCheese = new Product(45, "Blue Cheese", 30, "Emek", false, 0, 2, "Dairy");
            Product BulgarianCheese = new Product(45, "Bulgarian Cheese", 20, "Emek", false, 0, 2, "Dairy");
            Product Parmejan = new Product(45, "Parmejan", 20, "Emek", false, 0, 2, "Dairy");
            Product Maskarpone = new Product(45, "Maskarpone Cheese", 50, "Emek", false, 0, 2, "Dairy");
            Product Bread = new Product(50,"Bread", 10, "Conditory",false,0, 5, "Breads");
            Product Baguette = new Product(50, "Baguette", 20, "Conditory", false, 0, 5, "Breads");
            Product Breadroll = new Product(50, "Bread Roll", 13.4, "Conditory", false, 0, 5, "Breads");
            Product pineapple = new Product(90,"Pineapple", 30, "Local",false,0, 7, "Fruit");
            Product Deodorant = new Product(200,"Deodorant", 10, "Axe",false,0, 6, "Cosmetics");
            Product AppleJuice = new Product(89,"Apple Juice", 15, "Prigat",false,0, 4, "Drinks");
            Product OrangeJuice = new Product(49, "Orange Juice", 15, "Prigat", false, 0, 4, "Drinks");
            Product GrapesJuice = new Product(77, "Grapes Juice", 15, "Prigat", false, 0, 4, "Drinks");
            Product Tomatoes = new Product(43, "Tamatoes", 15, "Local", false, 0, 4, "Vegetables");
            Product Lemon = new Product(33, "Lemon", 8, "Local", false, 0, 4, "Vegetables");
            Product Cucumbers = new Product(49, "Cucumbers", 15, "Local", false, 0, 4, "Vegetables");
            Product Peppper = new Product(49, "Red pepper", 16, "Local", false, 0, 4, "Vegetables");
            Product Tuna = new Product(700,"Tuna", 17, "Starkist",false,0, 3, "Fish");
            Importer importer = new Importer("Shokotrade");
            LinkedList<Product> listMeat = new LinkedList<Product>();
            listMeat.AddLast(Chickenbreast);
            listMeat.AddLast(Steak);
            listMeat.AddLast(Kebab);
            listMeat.AddLast(Chickenwings);
            listMeat.AddLast(Chickenleg);
            listMeat.AddLast(Chickenbreast);
            listMeat.AddLast(Chickenbreast);
            listMeat.AddLast(Chickenbreast);
            listMeat.AddLast(Chickenbreast);
            LinkedList<Product> listDairy = new LinkedList<Product>();
            listDairy.AddLast(Cheese);
            listDairy.AddLast(BlueCheese);
            listDairy.AddLast(Parmejan);
            listDairy.AddLast(Maskarpone);
            listDairy.AddLast(Milk);
            listDairy.AddLast(BulgarianCheese);
            LinkedList<Product> listBread = new LinkedList<Product>();
            listBread.AddLast(Bread);
            listBread.AddLast(Breadroll);
            listBread.AddLast(Baguette);
            LinkedList<Product> listDrinks = new LinkedList<Product>();
            listDrinks.AddLast(AppleJuice);
            listDrinks.AddLast(GrapesJuice);
            listDrinks.AddLast(OrangeJuice);
            LinkedList<Product> listVegetables = new LinkedList<Product>();
            listVegetables.AddLast(Lemon);
            listVegetables.AddLast(Peppper);
            listVegetables.AddLast(Cucumbers);
            listVegetables.AddLast(Tomatoes);
            LinkedList<Product> listFruit = new LinkedList<Product>();
            listFruit.AddLast(pineapple);
            LinkedList<Product> ListFish = new LinkedList<Product>();
            ListFish.AddLast(Tuna);
            LinkedList<Product> ListCosmetics = new LinkedList<Product>();
            ListCosmetics.AddLast(Deodorant);
            Meat.Setlist(listMeat);
            Dairy.Setlist(listDairy);
            Fish.Setlist(ListFish);
            Breads.Setlist(listBread);
            Drinks.Setlist(listDrinks);
            Vegetables.Setlist(listVegetables);
            Fruit.Setlist(listFruit);
            Cosmetics.Setlist(ListCosmetics);
            LinkedList<Product> temp;
            for (int i = 0; i < categories.Length; i++)
            {
                temp = new LinkedList<Product>(categories[i].GetList());
                for (int j = 0; j < temp.Count; j++)
                {
                    importer.AddProduct(temp.First.Value, temp.First.Value.Getsupply());
                   temp.RemoveFirst();
                }
            }
            importer.Purchase();
            UserInterface(categories, importer);
           
        }
    }
}
