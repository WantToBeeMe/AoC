class Monkey
{
    public int id; //so Monkey 2 has an id of 2
    public List<int> items = new List<int>();
    public int inspect = 0;
    Func<int, int> operation; 
    Func<int, int> test; 

    public Monkey(int id, Func<int, int> operation, Func<int, int> test ){
        this.id = id;
        this.operation = operation;
        this.test = test;
    }

    public void setItems(string itemString){
        string[] splitted = itemString.Split(' ',',');
        int length = splitted.Length;
        for(int i = 4; i < length; i= i+2){
            items.Add( int.Parse(splitted[i]) );
        }
    }

    public static Monkey GetMonkey(string[] input){
        Monkey mon = new Monkey(
            int.Parse(""+input[0][7]),
            getOperation(input[2]),
            getTest(input[3],""+input[4][29],""+input[5][30] ) // input[4].Length -1     and    input[5].Length -1      but just entering the number for now is better cus the lenght never changes
        );
        
        mon.setItems(input[1]);
        return mon;
 
    }

    static Func<int, int> getOperation(string input){
        char opp = input[23];

        bool doOld = input[(input.Length -1)] == 'd'; // checking if the string ends with a D, cus then it multiplys or adds "old" instead of a number
        if(!doOld){
            string numTemp = ""+input[(input.Length -1)];
            numTemp = input[(input.Length -2)] == ' ' ? numTemp : input[(input.Length -2)] + numTemp;
            int num = int.Parse(numTemp);

            if(opp == '+') return (int x) => x + num;
            else return (int x) => x * num;
        }
        if(opp == '+') return (int x) => x + x;
        else return (int x) => x * x;
    }

    static Func<int, int> getTest(string input, string T, string F){
        string div = ""+input[(input.Length -1)];
        div = input[(input.Length -2)] == ' ' ? div : input[(input.Length -2)] + div;
        int divider = int.Parse(div);
        return (int x) => x % divider == 0 ? int.Parse(T) : int.Parse(F) ;
    }



    public List<KeyValuePair<int,int>> DoRound(bool devide = true){ //<int, int> = <new monkey, item>
        List<KeyValuePair<int,int>> output = new List<KeyValuePair<int,int>>(); 
        for(int i = 0; i < items.Count();i++){
            inspect++;
            int proces = operation(items[i]);
            if(devide) proces = proces/3;
            output.Add( new KeyValuePair<int,int>(test(proces), proces));
        }
        items = new List<int>();
        return output;
    }

}

