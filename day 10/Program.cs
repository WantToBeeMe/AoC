using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        
        string[] lines = System.IO.File.ReadAllLines("input.txt");

        KeyValuePair<string, int>[] instructions = getMoveSet(lines);
        Device device = new Device();
        //part 1

        var signals = device.GetImage(instructions);
        foreach(var sig in signals){
            Console.WriteLine(sig);
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

