class Group
{
    Monkey[] monkeys;

    public Group(string[] args){
        int amount = (args.Length+1)/7;
        monkeys = new Monkey[amount];
        string[] monString = new string[6];
        for(int c = 0; c<amount;c++){
            for(int i = 0; i<6; i++){
                monString[i] = args[i + c + (c*6)];  
            }
            monkeys[c] = Monkey.GetMonkey(monString);
        }   
    }

    public void DoRound(bool print,int x = 0, bool devide = true){
        for(int i = 0 ; i< monkeys.Length ; i++){
            List<KeyValuePair<int,int>> trows = monkeys[i].DoRound(devide);
            foreach(KeyValuePair<int,int> trow in trows){
                foreach(Monkey monkey in monkeys){
                    if(monkey.id == trow.Key){
                        monkey.items.Add(trow.Value);
                    }
                }
            }
        }

    if(print){
        Console.Write($"\n\nRound: {x}");
            foreach(Monkey monkey in monkeys){
                Console.Write($"\n   Monkey {monkey.id}: ");
                foreach(int item in monkey.items){
                    Console.Write($", {item}");
                }
            }
        }
    }

    public void DoRounds(int amount = 20,bool devide = true, bool print = false){
        for(int r = 0; r < amount ; r++){
            DoRound(print,r+1,devide);
        }
    }

    public void GetBusiness(){
        int high1 = 0;
        int high2 = 0;
        foreach(Monkey mon in monkeys){
            Console.WriteLine($"Monkey {mon.id}: {mon.inspect}");
            if(high1 > high2)
                high2 = mon.inspect > high2 ? mon.inspect : high2;
            else high1 = mon.inspect > high1 ? mon.inspect : high1;
        }
        Console.WriteLine($"monkey business : {high2 * high1}");
    }


}

