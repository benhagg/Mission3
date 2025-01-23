// food bank inventory
public class FoodItem
{
    // constructor
    FoodItem(string name, int quantity, HashSet<string> categories, DateTime expirationDate)
    {
        Name = name;
        Quantity = quantity;
        Categories = categories;
        ExpirationDate = expirationDate;
    }

    // when using {get; set;} like this C# will create a private field for you behind the scenes
    public string Name { get; set; }
    public int Quantity { get; set; }
    public HashSet<string> Categories { get; set; }
    public DateTime ExpirationDate { get; set; }

    // this overrides the default ToString() method (inherited from the Object class) and defines how the object is printed
    public override string ToString()
    {
        return $"Name: {Name}, Quantity: {Quantity}, Categories: {string.Join(", ", Categories)}, Expiration Date: {ExpirationDate}";
    }
}

// use static class to store global state (inventory)
static class Inventory 
{
    // static classes do not have constructors
    private static List<FoodItem> _inventory = new List<FoodItem>();

    // method to add item to inventory
    public static void AddItem(FoodItem item)
    {
        _inventory.Add(item);
    }

    // method to remove item from inventory
    public static void RemoveItem(FoodItem item)
    {
        _inventory.Remove(item);
    }
    
    // method to print inventory
    public static void PrintInventory()
    {
        foreach (var item in _inventory)
        {
            Console.WriteLine(item);
        }
    }
}