using Module02.Lesson16.EfCoreIntro; // for Product, AppDbContext class
// Create the Database file
var context = new AppDbContext();
context.Database.EnsureCreated(); // create tables once

// Add three products
context.Products.Add(
    new Product
    {
        Name = "Product 1",
        Price = 1.23m
    }
 );

context.Products.Add(
    new Product
    {
        Name = "Product 2",
        Price = 2.34m
    }
 );

context.Products.Add(
    new Product
    {
        Name = "Product 3",
        Price = 4.99m
    }
 );

// Save changes to database
context.SaveChanges();

// Query for all Product
var products = context.Products.ToList();
// Query for Product where Name contains a "3"
//var products = context.Products.Where(p => p.Name.Contains("3")).ToList();

// Iterate through each product and display it in the Console
foreach ( var product in products )
{
    Console.WriteLine($"{product.Id} - {product.Name} - {product.Price:C}");
}

// Add 2 customers 
context.Customers.Add(
    new Customer
    {
        Name = "Customer 1"
    });
context.Customers.Add(
    new Customer
    {
        Name = "Customer 2"
    });
// Save the changes
context.SaveChanges();

var customers = context.Customers.ToList();
foreach(var customer in customers)
{
    Console.WriteLine($"{customer.Id} - {customer.Name}");
}

// Write a LINQ query to return all products where the price is $2.00 or less
var cheapProducts = context.Products
    .Where(p => p.Price <= 2.0m)
    .ToList();

