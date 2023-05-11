// Create a class to represent an e-shop cart
// Cart:
// - has userId of the owner.
// - stores items and their quantities and prices (price should be readonly and positive).
// - can show cart amount.
// - can add item to cart.
// - can remove item from cart.
// - you can't remove the item that's not in the cart.

namespace Homework_09
{
    // --- class Item ------------------------------------------------------

    public class Item
    {
        public string title { get; set; }
        public double price { get; }
        public int quantity { get; set; }

        public Item(string title, double price = 0.0, int quantity = 1)
        {
            this.title = title;
            this.price = price > 0.0 ? price : 0.0;
            this.quantity = quantity;
        }

        public void Increase()
        {
            this.quantity++;
        }

        public void Decrease()
        {
            if (this.quantity > 0) this.quantity--;
        }
    }

    // --- class Cart ------------------------------------------------------

    public class Cart
    {
        private static int userId_seed = 1;
        internal int userId { get; }
        private List<Item> items { get; set; } = new List<Item>();

        public Cart()
        {
            this.userId = userId_seed;
            userId_seed++;
        }

        public int Amount()
        {
            return this.items.Count;
        }

        public int TotalAmount()
        {
            int result = 0;
            foreach (Item item in this.items) result += item.quantity;
            return result;
        }

        public double TotalPrice()
        {
            double result = 0.0;
            foreach (Item item in this.items) result += item.quantity * item.price;
            return result;
        }

        public void Print()
        {
            Console.WriteLine("Cart:");
            for (int i = 0; i < this.items.Count; i++)
            {
                Console.WriteLine(
                    $"#{i + 1}\t" +
                    $"{this.items[i].title}\t" +
                    $"{this.items[i].quantity} * " +
                    $"{this.items[i].price}"
                );
            }
            Console.WriteLine();
        }

        public void AddItem(Item item)
        {
            bool was_found = false;
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].title == item.title)
                {
                    this.items[i].Increase();
                    was_found = true;
                }
            }
            if (!was_found) this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            int found_index_to_remove = -1;
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].title == item.title)
                {
                    if (this.items[i].quantity > 0)
                    {
                        this.items[i].Decrease();
                    }
                    else
                    {
                        found_index_to_remove = i;
                        break;
                    }
                }
            }
            if (found_index_to_remove != -1)
            {
                this.items.RemoveAt(found_index_to_remove);
            }
        }

        // --- Main ------------------------------------------------------------

        /// <summary>
        /// Obsolete custom testing by console printing...
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Hometask 09:");
            Console.WriteLine("------------\n");

            Item bread  = new Item("Bread", 2.95);
            Item milk   = new Item("Milk", 1.50);
            Item cheese = new Item("Cheese", 5.75);
            Item pork   = new Item("Pork", 7.90);

            Cart GroceryCart = new Cart();

            GroceryCart.AddItem(bread);
            GroceryCart.AddItem(milk);
            GroceryCart.AddItem(bread);
            GroceryCart.AddItem(cheese);
            GroceryCart.AddItem(cheese);
            GroceryCart.AddItem(cheese);
            GroceryCart.RemoveItem(cheese);
            GroceryCart.RemoveItem(pork);

            GroceryCart.Print();
            Console.WriteLine($"Amount of unique type of items in the cart:  {GroceryCart.Amount()}");
            Console.WriteLine($"Total amount of all items in the cart:  {GroceryCart.TotalAmount()}");
            Console.WriteLine($"Total price of all items in the cart:  {GroceryCart.TotalPrice()}");
        }
    }
}
