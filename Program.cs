List<Product> products = new List<Product>();
List<Product> sortedPrice = new List<Product>();
string input;
int price1;
Product product1 = new Product("", "", 0);
Product_price pprice = new Product_price(0);
start:
while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - follow the steps | To save - enter: S");
    Console.ResetColor();
    Console.Write("Enter a Category: ");
    input = Console.ReadLine();
    if (input.ToUpper() == "S")
    {
        break;
    }
    else
    {
        product1.Category = input;
        Console.Write("Enter a Product name: ");
        input = Console.ReadLine();
        product1.Product_Name = input;
        Console.Write("Enter Price: ");
        input = Console.ReadLine();
        if (int.TryParse(input, out price1))
        {
            pprice.Price = price1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Product was successfully added!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Please insert a valid Price");
            input = Console.ReadLine();
            product1.Price = pprice.Price = price1;
        }
    }
    products.Add(new Product(product1.Category, product1.Product_Name, pprice.Price));
    sortedPrice = products.OrderBy(product => product.Price).ToList();
}
int sumOfPrice = sortedPrice.Sum(amount => amount.Price);
Console.WriteLine("\n Your Final Products are as follows: \n");
Console.WriteLine("---------------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(String.Format("Category".PadRight(15) + "Product".PadRight(15) + "Price".PadRight(15)));
Console.ResetColor();

foreach (Product product in sortedPrice)
{
    Console.WriteLine(String.Format(product.Category.PadRight(15) + product.Product_Name.PadRight(15) + product.Price));
}
Console.WriteLine("Total amount:".PadRight(30) + sumOfPrice);
while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("To enter a new product - enter: P | To search for a product - enter: S | To quit - enter: Q");
    Console.ResetColor();
    input = Console.ReadLine();
    if (input.ToUpper() == "P")
    {
        goto start;
    }
    else if (input.ToUpper() == "S")
    {
        Console.WriteLine("Enter a Product name");
        input = Console.ReadLine();
        Console.WriteLine("---------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(String.Format("Category".PadRight(15) + "Product".PadRight(15) + "Price".PadRight(15)));
        Console.ResetColor();
        foreach (Product product in sortedPrice)
        {
            if (product.Product_Name.ToUpper() == input.ToUpper())
            {
                Console.WriteLine(String.Format(product.Category.PadRight(15) + product.Product_Name.PadRight(15) + product.Price));
            }
        }
    }
    else if (input.ToUpper() == "Q")
    {
        break;
    }
    else
    {
        Console.WriteLine("Please enter valid digit");
    }
}
	
	class Product
{
    public Product(string category, string product_name, int price)
    {
        Category = category;
        Product_Name = product_name;
        Price = price;
    }
    public string Category { get; set; }
    public string Product_Name { get; set; }
    public int Price { get; set; }
}
class Product_price
{
    public Product_price(int price)
    {
        Price = price;
    }
    public int Price { get; set; }
}

