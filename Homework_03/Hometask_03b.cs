// II. Tasks for different loops (you need a collection of doubles for these)
// 1. For each element, add its index to its value, and output the resulting collection to console.
// 2. Output elements of the collection one by one (use console.readline as a separator), until user enters "x" to the program.
// 3. Read numbers one by one from console and save them to new collection. Do that until user enters "not a number" string.
// 4. If there are 0 elements in the new collection after step 3, repeat it (until user enters some numbers),
//	  then repeat step 2 (output numbers until user enters "x").

namespace Homework_03
{
    internal class Hometask_03b
    {
        public static void Loops()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Hometask 03b:");
            Console.WriteLine("------------\n");

            // generating an array of random doubles
            int i;
            const int amount = 10;
            double[] doubles = new double[amount];
            for (i = 0; i < amount; i++)
            {
                doubles[i] = new Random().NextDouble();
            }

            // #1: output of all array elements, adding appropriate index
            Console.WriteLine("#1");
            i = 0;
            foreach (double d in doubles)
            {
                Console.WriteLine($"{i,3}: {d + i++}");
            }

            // #2: output generated array elements one by one, until user enters "x" to break
            Console.WriteLine("\n#2");
            i = 0;
            do
            {
                Console.Write($"{i,3}: {doubles[i++]}");
                string input = Console.ReadLine();
                if (input == "x") break;
            } while (i < amount);

            // #3: creating new list of custom double numbers from console
            List<double> custom_doubles = new List<double>();
            double custom_number;
            do
            {
                Console.WriteLine("\n#3");
                do
                {
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out custom_number))
                    {
                        custom_doubles.Add(custom_number);
                        Console.WriteLine("recorded.");
                    }
                    else break;
                } while (true);
            } while (custom_doubles.Count == 0);

            // #4: output created list of elements one by one, until user enters "x" to break
            Console.WriteLine("\n#4");
            i = 0;
            foreach (double d in custom_doubles)
            {
                Console.Write($"{i++,3}: {d}");
                string input = Console.ReadLine();
                if (input == "x") break;
            }
        }

        //public static void Main()
        //{
        //    Loops();
        //}
    }
}
