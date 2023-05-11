namespace Homework_05
{
    internal class Lecture_05
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

        // --- Main ------------------------------------------------------------

        //public static void Main()
        //{
        //    var fridge = new Refrigerator();

        //    Console.WriteLine(
        //        $"Refrigerator was created. " +
        //        $"Owner: {fridge.Owner}\t" +
        //        $"Capacity: {fridge.Capacity} kg\t" +
        //        $"Containing Amount: {fridge.ContainingAmount} kg"
        //    );

        //    var myFridge = new Refrigerator("Polina", 60.0m);

        //    Console.WriteLine(
        //        $"Refrigerator was created. " +
        //        $"Owner: {myFridge.Owner}\t" +
        //        $"Capacity: {myFridge.Capacity} kg\t" +
        //        $"Containing Amount: {myFridge.ContainingAmount} kg"
        //    );

        //    Console.WriteLine($"Fullness of {myFridge.Owner}'s fridge is {myFridge.Fullness:F1}%");
        //    myFridge.StoreFood("steak", 0.5m);
        //    myFridge.StoreFood("tomato", 1.0m);
        //    myFridge.PrintRefrigeratorContents();
        //    Console.WriteLine($"Fullness of {myFridge.Owner}'s fridge is {myFridge.Fullness:F1}%");
        //}
    }
}
