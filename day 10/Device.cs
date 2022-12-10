using System.Numerics;

class Device
{   
    public List<string> GetImage(KeyValuePair<string, int>[] instructions){
        int x = 1;
        int cycle = 1;
        string line = "";
        List<string> image = new List<string>();

        foreach(KeyValuePair<string, int> ins in instructions){
            line += (line.Length == (x%40)-1) || (line.Length == (x%40)) || (line.Length == (x%40)+1) ? '#' : '.';
            cycle++; //end of cycle, add 1 
             
            if(line.Length >= 40){
                image.Add(line);
                line = "";
            }

            if(ins.Key == "addx"){
                line += (line.Length == (x%40)-1) || (line.Length == (x%40)) || (line.Length == (x%40)+1) ? '#' : '.';
                x += ins.Value;
                cycle++;
                
            }  

            if(line.Length >= 40){
                image.Add(line);
                line = "";
            }

            
        }
        return image;
    }

    public List<KeyValuePair<int, int>> GetSignalStrength(KeyValuePair<string, int>[] instructions){
        int x = 1;
        int cycle = 1;
        List<KeyValuePair<int, int>> signals = new List<KeyValuePair<int, int>>();

        foreach(KeyValuePair<string, int> ins in instructions){
            if(cycle % 40 == 20){
                signals.Add(new KeyValuePair<int, int>(cycle,x));
                Console.WriteLine($"{cycle} * {x} = {cycle*x}");
            }
            if(cycle % 40 == 19 && ins.Key == "addx"){
                signals.Add(new KeyValuePair<int, int>(cycle+1,x));
                Console.WriteLine($"{cycle+1} * {x} = {(cycle+1)*x}");
            }
             if(ins.Key == "addx"){
                cycle++;
                x += ins.Value;
            }   
            cycle++; //end of cycle, add 1 
        }
        return signals;
    }
}

