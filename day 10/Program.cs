using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        
        string[] lines = System.IO.File.ReadAllLines("small_input.txt");

        KeyValuePair<string, int>[] instructions = getMoveSet(lines);
        Device device = new Device();
        //part 1

        foreach(var struck in instructions){
            Console.WriteLine($"{struck.Key} - {struck.Value}");
        }

    }




    public static KeyValuePair<string, int>[] getMoveSet(string[] args, bool prints = false)
    {
        int total = args.Length;
        KeyValuePair<string, int>[] instructions = new KeyValuePair<string, int>[total];
        for(int i = 0; i < total; i++){
            string[] struckSet = args[i].Split(' ');
            int addx = struckSet.Length > 1 ? int.Parse(struckSet[1]): 0;
            instructions[i] = new KeyValuePair<string, int>(struckSet[0], addx);
        }
        return instructions;
    }
}

