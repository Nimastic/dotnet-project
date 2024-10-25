using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        // Ensure the database is created
        db.Database.EnsureCreated();

        // Add a new product
        Console.Write("Enter product name: ");
        var name = Console.ReadLine();

        Console.Write("Enter product price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            var product = new Product { Name = name, Price = price };
            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid price entered.");
        }

        // Retrieve and display all products
        var products = db.Products.ToList();
        Console.WriteLine("\nList of Products:");
        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price:C}");
        }
    }
}
