// Create tests for your e-shop cart to cover situations of:
// - adding items to  the shoppingCart
// - removing items from the shoppingCart
// - verifying correct price calculation

using Homework_09;

namespace Homework_09_Tests
{
    public class Tests
    {
        Cart GroceryCart;
        Item bread, milk, cheese, pork;

        [SetUp]
        public void Setup()
        {
            GroceryCart = new Cart();
            this.bread  = new Item("Bread", 2.95);
            this.milk   = new Item("Milk", 1.50);
            this.cheese = new Item("Cheese", 5.75);
            this.pork   = new Item("Pork", 7.90);
        }

        [Test]
        [Ignore("Skipped...")]
        public void _TestIgnore()
        {
            Assert.Pass();
        }

        [Test]
        public void _TestPass()
        {
            Assert.Pass();
        }

        [Test]
        public void _TestFail()
        {
            Assert.AreEqual(true, false);
        }

        [Test]
        public void TestAddSimpleItem()
        {
            Item SimpleItem = new Item("Simple Item", 10);
            GroceryCart.AddItem(SimpleItem);

            Assert.That(GroceryCart.Amount(), Is.EqualTo(1));
            Assert.That(GroceryCart.TotalAmount(), Is.EqualTo(1));
            Assert.That(GroceryCart.TotalPrice(), Is.EqualTo(10));
        }

        [Test]
        public void TestEmptyCart()
        {
            var emptyCart = new Cart();

            Assert.That(emptyCart.Amount(), Is.EqualTo(0));
            Assert.That(emptyCart.TotalAmount(), Is.EqualTo(0));
            Assert.That(emptyCart.TotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void TestAddItemsToCart()
        {
            var myCart = new Cart();

            myCart.AddItem(bread);
            myCart.AddItem(milk);
            myCart.AddItem(cheese);
            myCart.AddItem(pork);

            Assert.That(myCart.Amount(), Is.EqualTo(4));
            Assert.That(myCart.TotalAmount(), Is.EqualTo(4));
            Assert.That(myCart.TotalPrice(), Is.EqualTo(18.10));
        }

        [Test]
        public void TestAddItemsToCartOnTopOfExistingItems()
        {
            var myCart = new Cart();

            myCart.AddItem(bread);
            myCart.AddItem(milk);
            myCart.AddItem(bread);
            myCart.AddItem(cheese);
            myCart.AddItem(cheese);
            myCart.AddItem(cheese);

            Assert.That(myCart.Amount(), Is.EqualTo(3));
            Assert.That(myCart.TotalAmount(), Is.EqualTo(6));
            Assert.That(myCart.TotalPrice(), Is.EqualTo(24.65));
        }

        [Test]
        public void TestRemoveItemsFromCart()
        {
            var myCart = new Cart();

            myCart.AddItem(bread);
            myCart.AddItem(milk);
            myCart.AddItem(bread);
            myCart.AddItem(cheese);
            myCart.AddItem(cheese);
            myCart.AddItem(cheese);
            myCart.RemoveItem(cheese);
            myCart.RemoveItem(pork);

            Assert.That(myCart.Amount(), Is.EqualTo(3));
            Assert.That(myCart.TotalAmount(), Is.EqualTo(5));
            Assert.That(myCart.TotalPrice(), Is.EqualTo(18.9));
        }

        [Test]
        public void TestRemoveItemsFromEmptyCart()
        {
            var myCart = new Cart();

            myCart.RemoveItem(milk);

            Assert.That(myCart.Amount(), Is.EqualTo(0));
            Assert.That(myCart.TotalAmount(), Is.EqualTo(0));
            Assert.That(myCart.TotalPrice(), Is.EqualTo(0));
        }
    }
}
