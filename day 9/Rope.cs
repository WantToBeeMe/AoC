using System.Numerics;

class Rope
{

    public Vector2 HeadLoc = new Vector2(0, 0);
    public Vector2[] TailLoc;
    int tailLength;
    int maxLength = 2;
    static Vector2[] tailDefault = {new Vector2(0,0)};
    public List<Vector2> TailSpots = new List<Vector2>(tailDefault);

    public Rope(int taillength = 1){
        tailLength = taillength;
        TailLoc = new Vector2[tailLength];
        for(int i = 0; i<tailLength ; i++){
            TailLoc[i] = new Vector2(0, 0);
        }
    }

    public void simulateSequence(KeyValuePair<string, int>[] moves){
        foreach(var move in moves){
            simulateStep(move);
            
            Console.WriteLine($"--{move.Key} {move.Value}--");
            int index = 1;
            foreach(var a in TailLoc){
                Console.WriteLine($"\t {index} {a}"); index++;
            }

        }
    }

    public void simulateStep(KeyValuePair<string, int> move){
        int steps = move.Value;
        for(int i = 0; i < steps ; i++){
            moveHead(move.Key);

            for(int tailpart = 0 ; tailpart < tailLength ; tailpart++){
                Vector2 head = tailpart == 0 ?HeadLoc : TailLoc[tailpart-1];
                if(isToLong(TailLoc[tailpart], head)){
                    bool isLast = (tailpart == tailLength-1);
                    TailLoc[tailpart] = moveTail(move.Key, TailLoc[tailpart], head, isLast);
                }
            }

            Console.WriteLine($"--{move.Key} {i}/{move.Value}--");
            int index = 1;
            foreach(var a in TailLoc){
                Console.WriteLine($"\t {index} {a}"); index++;
            }

        }

    }
    
    bool isToLong(Vector2 tail, Vector2 head){
        int dx = (int)head.X - (int)tail.X;
        int dy = (int)head.Y - (int)tail.Y;
        return (dx * dx) + (dy * dy) >= maxLength*maxLength;
    }

    bool moveHead(string move){
        if(move == "R") HeadLoc.X += 1;
        else if(move == "L") HeadLoc.X -= 1;
        else if(move == "U") HeadLoc.Y += 1;
        else if(move == "D") HeadLoc.Y -= 1;
        else return false;
        return true;
    }

    Vector2 moveTail(string move, Vector2 tail, Vector2 head, bool last = false){
        if(move == "R") {
            tail.X = head.X -1;
            tail.Y = head.Y;
        } else if(move == "L"){
            tail.X = head.X +1;
            tail.Y = head.Y;
        } else if(move == "U") {
            tail.Y = head.Y -1;
            tail.X = head.X;
        }else if(move == "D") {
            tail.Y = head.Y +1;
            tail.X = head.X;
        } else return new Vector2(0,0);
        if(!TailSpots.Contains(tail) && last) TailSpots.Add(tail);
        return tail;
    }


}

