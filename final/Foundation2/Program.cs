using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Price * Quantity;
    }
}

public class Order
{
    private List<Product> products;
    public string CustomerName { get; set; }

    public Order(string customerName)
    {
        CustomerName = customerName;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        if (products.Contains(product))
        {
            products.Remove(product);
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }
        return total;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"\nOrder for {CustomerName}:");
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}, Quantity: {product.Quantity}, Total: ${product.GetTotalPrice()}");
        }
        Console.WriteLine($"Total Order Price: ${CalculateTotal()}");
    }

    // This method will return the list of products in the order
    public List<Product> GetProducts()
    {
        return products;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string customerName = Console.ReadLine();

        Order order = new Order(customerName);

        while (true)
        {
            Console.WriteLine("\nEnter 1 to Add Product, 2 to Remove Product, 3 to View Order, 0 to Exit:");
            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    double productPrice = double.Parse(Console.ReadLine());
                    Console.Write("Enter Product Quantity: ");
                    int productQuantity = int.Parse(Console.ReadLine());

                    Product newProduct = new Product(productName, productPrice, productQuantity);
                    order.AddProduct(newProduct);
                    break;

                case "2":
                    order.DisplayOrder();
                    Console.Write("Enter the name of the product to remove: ");
                    string productToRemove = Console.ReadLine();

                    Product productToDelete = order.GetProducts().Find(p => p.Name == productToRemove);
                    if (productToDelete != null)
                    {
                        order.RemoveProduct(productToDelete);
                        Console.WriteLine("Product removed.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;

                case "3":
                    order.DisplayOrder();
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
