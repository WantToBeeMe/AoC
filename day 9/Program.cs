using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        
        string[] lines = System.IO.File.ReadAllLines("test_input2.txt");

        KeyValuePair<string, int>[] moveset = getMoveSet(lines);
        Rope rope = new Rope(9);
        rope.simulateSequence(moveset);
        //part 1
        Console.WriteLine($"total Tail spots: {rope.TailSpots.Count()}");

    }




    public static KeyValuePair<string, int>[] getMoveSet(string[] args, bool prints = false)
    {
        int total = args.Length;
        KeyValuePair<string, int>[] moves = new KeyValuePair<string, int>[total];
        for(int i = 0; i < total; i++){
            string[] moveSet = args[i].Split(' ');
            moves[i] = new KeyValuePair<string, int>(moveSet[0], int.Parse(moveSet[1]));
        }
        return moves;
    }
}

