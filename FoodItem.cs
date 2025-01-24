using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3
{
    public class FoodItem
    {
        // when using {get; set;} like this C# will create a private field for you behind the scenes
        public string Name { get; set; }
        public int Quantity { get; set; }
        public HashSet<string> Categories { get; set; }
        public DateTime ExpirationDate { get; set; }
        // constructor is public to allow other classes to create FoodItem objects
        public FoodItem(string name, int quantity, HashSet<string> categories, DateTime expirationDate)
        {
            Name = name;
            Quantity = quantity;
            Categories = categories;
            ExpirationDate = expirationDate;
        }

        // this overrides the default ToString() method (inherited from the Object class) and defines how the object is printed
        public override string ToString()
        {
            return $"Name: {Name}, Quantity: {Quantity}, Categories: {string.Join(", ", Categories)}, Expiration Date: {ExpirationDate}";
        }
    }
}
