public class Atomic
{
    public static bool accept(string message){
        Console.WriteLine(message);
        return Console.ReadLine().ToLower() == "y";
    }
}