// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        
        //Console.WriteLine($"total of tree coverage is: {coverage.getCoverage(lines)}");
        Console.WriteLine($"best scenic score is: {scenic.getHighestSenic(lines)}");
    }
}

