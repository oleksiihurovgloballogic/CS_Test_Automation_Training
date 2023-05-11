// Create a program that uses string type, number type, boolean, and collection of any of those types.
// Transform your collection in any way and output the result to the screen

internal class Hometask_02
{
    static void Main()
    {
        Console.WriteLine("------------");
        Console.WriteLine("Hometask 02:");
        Console.WriteLine("------------\n");

        // creation
        List<string> list_of_strings = new List<string>() { "a", "b", "c", "d", "e" };
        List<int> list_of_integers = new List<int>() { 1, 2, 3, 4, 5 };
        List<bool> list_of_booleans = new List<bool>() { true, false };

        // modification
        list_of_strings.Add("f");
        list_of_integers.Insert(1, 777);
        list_of_booleans.RemoveAt(1);

        // printing
        Console.WriteLine(list_of_strings);
        Console.WriteLine(string.Join(", ", list_of_strings));
        Console.WriteLine(string.Join(", ", list_of_integers));
        Console.WriteLine(string.Join(", ", list_of_booleans));
    }
}
