// This program converts cups to fluid ounces
// Get the numbers of cups


double cups = GetCups();
double ounces = CupsToOunces(cups);
DisplayResults(cups, ounces);

double CupsToOunces(double cups)
{
    // Formula: 1 cup = 8 ounces
    return cups * 8.0;
}

void DisplayResults(double cups, double ounces)
{
    Console.WriteLine($"{cups} cups equals {ounces} fluid ounces");
}

double GetCups()
{
    // Prompt the user for the number of cups
    Console.WriteLine("This program converts measurements in cups to fluid ounces.");
    Console.WriteLine("For your reference the formula is:");
    Console.WriteLine("\t1 cup = 8 fluid ounces.");
    Console.WriteLine("\nEnter the number of cups.");
    return double.Parse(Console.ReadLine());
}