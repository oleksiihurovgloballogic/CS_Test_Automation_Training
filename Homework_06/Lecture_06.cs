namespace Homework_06
{
    internal class Lecture_06
    {
        // ----- class Refrigerator --------------------------------------------

        internal class Refrigerator
        {
            //public List<string> FoodList { get; set; }
            public List<(string Name, decimal Quantity)> FoodList { get; set; }

            public string Owner { get; set; }

            // kg
            public decimal Capacity { get; set; }

            public decimal ContainingAmount
            {
                get
                {
                    //decimal resultingAmount = 0.0m;
                    //foreach (var food in FoodList)
                    //{
                    //    resultingAmount += food.Quantity;
                    //}
                    //return resultingAmount;
                    return FoodList.Sum(foodItem => foodItem.Quantity);
                }
            }

            public decimal Fullness
            {
                get
                {
                    return ContainingAmount / Capacity * 100;
                }
            }

            public Refrigerator()
            {
                //FoodList = new List<string>();
                FoodList = new List<(string Name, decimal Quantity)>();
            }

            public Refrigerator(string owner, decimal capacityKg)
            {
                Owner = owner;
                Capacity = capacityKg;
                //FoodList = new List<string>();
                FoodList = new List<(string Name, decimal Quantity)>();
            }

            public void StoreFood(string product, decimal quantityKg)
            {
                var foodItem = (product, quantityKg);
                FoodList.Add(foodItem);
            }

            public void TakeFoodOut(string product, decimal quantityKg)
            {
                var productToRemove = FoodList.FirstOrDefault(food => food.Name == product);
                if (string.IsNullOrEmpty(productToRemove.Name))
                {
                    throw new ArgumentOutOfRangeException(nameof(product), $"Cannot take more {productToRemove.Name} in teh fridge");
                }
                if (productToRemove.Quantity < quantityKg)
                {
                    throw new ArgumentOutOfRangeException(nameof(quantityKg), $"Cannot take more {productToRemove.Name} than {productToRemove.Quantity}");
                }
                productToRemove.Quantity -= quantityKg;
            }

            public void TakeFoodOut(string product)
            {
                var productToRemove = FoodList.FirstOrDefault(food => food.Name == product);
                if (string.IsNullOrEmpty(productToRemove.Name))
                {
                    throw new ArgumentOutOfRangeException(nameof(product), $"Cannot take more {productToRemove.Name} in teh fridge");
                }
                FoodList.Remove(productToRemove);
            }

            public void PrintRefrigeratorContents()
            {
                Console.WriteLine($"{Owner}'s refrigerator has:");
                foreach (var item in FoodList)
                {
                    Console.WriteLine(
                        $"- {item.Quantity} kg of {item.Name}"
                    );
                }
            }
        }

        // ---------------------------------------------------------------------

        public static void _Main()
        {
            var fridge = new Refrigerator();

            Console.WriteLine(
                $"Refrigerator was created. " +
                $"Owner: {fridge.Owner}\t" +
                $"Capacity: {fridge.Capacity} kg\t" +
                $"Containing Amount: {fridge.ContainingAmount} kg"
            );

            var myFridge = new Refrigerator("Polina", 60.0m);

            Console.WriteLine(
                $"Refrigerator was created. " +
                $"Owner: {myFridge.Owner}\t" +
                $"Capacity: {myFridge.Capacity} kg\t" +
                $"Containing Amount: {myFridge.ContainingAmount} kg"
            );

            Console.WriteLine($"Fullness of {myFridge.Owner}'s fridge is {myFridge.Fullness:F1}%");
            myFridge.StoreFood("steak", 0.5m);
            myFridge.StoreFood("tomato", 1.0m);
            myFridge.PrintRefrigeratorContents();
            Console.WriteLine($"Fullness of {myFridge.Owner}'s fridge is {myFridge.Fullness:F1}%");

            var foodToTake = "yoghurt";

            try
            {
                myFridge.TakeFoodOut("steak");
                myFridge.TakeFoodOut(foodToTake, 1.0m);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Something went wrong. Please contact support");
                Console.WriteLine($"Error message {ex.Message}");
                throw new InvalidOperationException($"Error while taking {foodToTake} from the fridge", ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Something went wrong. Please contact support");
                Console.WriteLine($"Other error: {ex.Message}");
            }
            Console.WriteLine($"Fullness of {myFridge.Owner}'s fridge is {myFridge.Fullness:F1}%");

        }
    }
}
