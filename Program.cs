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
                    Console.WriteLine("Enter item quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter item categories (comma separated): ");
                    //create a new hash set with the categories, split using delimiter ',' and trim spaces
                    HashSet<string> categories = new HashSet<string>(Console.ReadLine().Split(',').Select(c => c.Trim()));
                    Console.WriteLine("Enter item expiration date (yyyy-mm-dd): ");
                    // parse the date string into a DateTime object
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                    // create new FoodItem object and add it to the inventory
                    FoodItem newItem = new(name, quantity, categories, expirationDate);
                    Inventory.Add(newItem);
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
                        Console.WriteLine($"Removed all {nameToRemove} from inventory.");
                    }
                    else
                    {
                        Console.WriteLine($"Item {nameToRemove} not found in inventory.");
                    }
                }
                else if (choice == "3")
                {
                    foreach (var item in Inventory)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (choice == "4")
                {
                    break;
                }
            }
        }
    }
}


