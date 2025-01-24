using Mission3;
internal class Program
{
    private static void Main(string[] args)
    {
        List<FoodItem> Inventory = new List<FoodItem>();

        // main program logic
        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Print Inventory");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            else
            {
                if (choice == "1")// add a FoodItem
                {
                    Console.WriteLine("Enter item name: ");
                    string name = Console.ReadLine();
                    int quantity = 0;
                    while (true)
                    {
                        Console.WriteLine("Enter item quantity: ");
                        // error handling. Assign the output to quantity with out keyword
                        if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a positive number.");
                        }
                    }
                    Console.WriteLine("Enter item categories (comma separated): ");
                    //create a new hash set with the categories, split using delimiter ',' and trim spaces
                    HashSet<string> categories = new HashSet<string>(Console.ReadLine().Split(',').Select(c => c.Trim()));
                    // parse the date string into a DateTime object
                    DateTime expirationDate;
                    while (true)
                    {
                        Console.WriteLine("Enter item expiration date (yyyy-mm-dd): ");
                        // error handling for date time entering. out keyword is used to assign the output to expirationDate
                        if (DateTime.TryParse(Console.ReadLine(), out expirationDate))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format.");
                        }
                    }
                    // create new FoodItem object and add it to the inventory
                    FoodItem newItem = new(name, quantity, categories, expirationDate);
                    Inventory.Add(newItem);
                    Console.WriteLine(" "); // whitespace for formatting
                }
                else if (choice == "2")// remove food item from inventory
                {
                    // find food item by name and remove
                    Console.WriteLine("Enter item name to remove: ");
                    string nameToRemove = Console.ReadLine();
                    // .RemoveAll() will return the number of items removed, if any were removed it will be > 0
                    int itemsRemoved = Inventory.RemoveAll(i => i.Name == nameToRemove);
                    if (itemsRemoved != 0)
                    {
                        Console.WriteLine($"\nRemoved {itemsRemoved}{nameToRemove} from inventory.");
                    }
                    else
                    {
                        Console.WriteLine($"Item {nameToRemove} not found in inventory.\n");
                    }
                }
                else if (choice == "3")
                {   
                    int count = Inventory.Count;
                    // string interpolation with ternary operators for grammar
                    Console.WriteLine($"\nThere {(count == 1 ? "is":"are")} {count} {(count == 1 ? "item" : "items")} in the inventory.\n");
                    foreach (var item in Inventory)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("\n"); // whitespace for formatting
                }
                else if (choice == "4")
                {
                    break;
                }
            }
        }
    }
}


