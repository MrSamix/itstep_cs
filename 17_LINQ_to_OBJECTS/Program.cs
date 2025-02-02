using _17_LINQ_to_OBJECTS;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Product> products = new List<Product>()
            {
                new Product(){Name ="Orange",Price = 48.2f, Country = "Spain", Category = Product.CategoryProduct.Category1, Year = 2025 },
                new Product(){Name ="Bread",Price = 15.5f, Country = "Ukraine", Category = Product.CategoryProduct.Category2 ,Year = 2025},
                new Product(){Name ="Plum",Price = 22.2f, Country = "Spain", Category = Product.CategoryProduct.Category1,Year = 2024 },
                new Product(){Name ="Oil",Price = 60.5f, Country = "Ukraine", Category = Product.CategoryProduct.Category2,Year = 2025 },
                new Product(){Name ="Banana",Price = 35.2f, Country = "Spain", Category = Product.CategoryProduct.Category1 ,Year = 2024},
            };
        Print(products, "Print all products");
        // Task 1
        var query = from product in products
                    where product.Year == DateTime.Now.Year
                    orderby product.Price descending
                    select product;
        Print(query, "Print all products current year");
        // Task 2
        string select_country = "Spain";
        var select_2 = products.Where(x => x.Country.CompareTo(select_country) == 0);
        Print(select_2, "Print all products in Spain");
        Console.WriteLine($"Count :: {select_2.Count()}");
        // Task 3
        var select_3 = products.Where(x => x.Category == Product.CategoryProduct.Category1);
        Print(select_3, "Print products with category 1");
        Console.WriteLine($"Max price :: {select_3.Max(x => x.Price)}");
        Console.WriteLine($"Min price :: {select_3.Min(x => x.Price)}");

        // Task 4
        var select_4 = products.Where(x => x.Country == "Ukraine");
        Print(select_4, "All products in Ukraine");
        foreach (Product.CategoryProduct item in Enum.GetValues(typeof(Product.CategoryProduct)))
        {
            var select = products.Where(x => x.Category == item && x.Country == "Ukraine").Count();
            if (select == 0)
            {
                Console.WriteLine($"No {item} in Ukraine.");
            }
        }

        // Task 5
        foreach (Product.CategoryProduct item in Enum.GetValues(typeof(Product.CategoryProduct)))
        {
            var select = products.Where(x => x.Category == item);
            Print(select, $"All product of {item}");
        }

        // Task 6
        foreach (Product.CategoryProduct item in Enum.GetValues(typeof(Product.CategoryProduct)))
        {
            var select = products.Where(x => x.Category == item).OrderBy(x=>x.Year);
            Print(select, $"All product of {item} sorted by date(from old to new)");
        }
    }

    static void Print(IEnumerable<Product> source, string text = "")
    {
        Console.WriteLine("\n" + text);
        foreach (var item in source)
        {
            Console.WriteLine(item);
        }
    }
}