// Create a class to represent an e-shop cart
// Cart:
// - has userId of the owner.
// - stores items and their quantities and prices (price should be readonly and positive).
// - can show cart amount.
// - can add item to cart.
// - can remove item from cart.
// - you can't remove the item that's not in the cart.

namespace Homework_04
{
    internal class Hometask_04
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

            public void increase()
            {
                this.quantity++;
            }

            public void decrease()
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

            public int amount()
            {
                return this.items.Count;
            }

            public int total_amount()
            {
                int result = 0;
                foreach (Item item in this.items) result += item.quantity;
                return result;
            }

            public double total_price()
            {
                double result = 0.0;
                foreach (Item item in this.items) result += item.quantity * item.price;
                return result;
            }

            public void print()
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

            public void add_item(Item item)
            {
                bool was_found = false;
                for (int i = 0; i < this.items.Count; i++)
                {
                    if (this.items[i].title == item.title)
                    {
                        this.items[i].increase();
                        was_found = true;
                    }
                }
                if (!was_found) this.items.Add(item);
            }

            public void remove_item(Item item)
            {
                int found_index_to_remove = -1;
                for (int i = 0; i < this.items.Count; i++)
                {
                    if (this.items[i].title == item.title)
                    {
                        if (this.items[i].quantity > 0)
                        {
                            this.items[i].decrease();
                        }
                        else
                        {
                            found_index_to_remove = i;
                            break;
                        }
                    }
                }
                if (found_index_to_remove != -1) this.items.RemoveAt(found_index_to_remove);
            }
        }

        // --- Main ------------------------------------------------------------

        public static void Main()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Hometask 04:");
            Console.WriteLine("------------\n");

            Item bread = new Item("Bread", 2.95);
            Item milk = new Item("Milk", 1.50);
            Item cheese = new Item("Cheese", 5.75);
            Item pork = new Item("Pork", 7.90);

            Cart grocery_cart = new Cart();

            grocery_cart.add_item(bread);
            grocery_cart.add_item(milk);
            grocery_cart.add_item(bread);
            grocery_cart.add_item(cheese);
            grocery_cart.add_item(cheese);
            grocery_cart.add_item(cheese);
            grocery_cart.remove_item(cheese);
            grocery_cart.remove_item(pork);

            grocery_cart.print();
            Console.WriteLine($"Simple amount of unique type of items in the cart:  {grocery_cart.amount()}");
            Console.WriteLine($"Total amount of all items in the cart:  {grocery_cart.total_amount()}");
            Console.WriteLine($"Total price of all items in the cart:  {grocery_cart.total_price()}");
        }
    }
}
