// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        int height = lines.Length;
        int length = lines[0].Length;
        
        string[] seen = new string[lines.Length];
        for(int i = 0 ;i < height; i++){ //creating the seen/notseen table
            string x = "";
            for(int j = 0; j<length; j++)
                x += (i==0 || i==height-1) || (j==0 || j==length-1) ? 'S' : 'N';
            seen[i]=x;
        }

        Console.WriteLine($"input day 8: {height} x {length} \n");

        for(int i = 1; i < height-1; i++)  { //loops per line
            for(int j = 1; j<length-1; j++ ){ //loops per char in line
                int curTree = int.Parse( ""+lines[i].ToCharArray()[j] );
                //Console.WriteLine($"checking spot {i}-{j} with an hight of { curTree }");
                
                //seen on the left
                int topTree = 0;
                bool leftSeen = true;
                for(int p = j-1; p>=0; p--){
                    topTree = topTree < int.Parse( ""+lines[i].ToCharArray()[p] ) ? int.Parse( ""+lines[i].ToCharArray()[p] ): topTree;
                    //Console.WriteLine($"\t current {curTree} with contesten {topTree}");
                    if(topTree >= curTree){
                        leftSeen = false;
                        //Console.WriteLine($"\t cant be seen, to small");
                        break; 
                    }
                }
                if (leftSeen){
                    char[] temp = seen[i].ToCharArray();
                    temp[j] = 'S';
                    seen[i] =  new string(temp);
                    continue;
                }
                
                // seen on the right
                topTree = 0;
                bool rightSeen = true;
                for(int p = j+1; p<length; p++){
                    topTree = topTree < int.Parse( ""+lines[i].ToCharArray()[p] ) ? int.Parse( ""+lines[i].ToCharArray()[p] ): topTree;
                    //Console.WriteLine($"\t current {curTree} with contesten {topTree}");
                    if(topTree >= curTree){
                        rightSeen = false;
                        //Console.WriteLine($"\t cant be seen, to small");
                        break; 
                    }
                }
                if (rightSeen){
                    char[] temp = seen[i].ToCharArray();
                    temp[j] = 'S';
                    seen[i] =  new string(temp);
                    continue;
                }

                //seen on the top
                topTree = 0;
                bool topSeen = true;
                for(int p = i-1; p>=0; p--){
                    topTree = topTree < int.Parse( ""+lines[p].ToCharArray()[j] ) ? int.Parse( ""+lines[p].ToCharArray()[j] ): topTree;
                    //Console.WriteLine($"\t current {curTree} with contesten {topTree}");
                    if(topTree >= curTree){
                        topSeen = false;
                        //Console.WriteLine($"\t cant be seen, to small");
                        break; 
                    }
                }
                if (topSeen){
                    char[] temp = seen[i].ToCharArray();
                    temp[j] = 'S';
                    seen[i] =  new string(temp);
                    continue;
                }

                //seen on the top
                topTree = 0;
                bool botSeen = true;
                for(int p = i+1; p<height; p++){
                    topTree = topTree < int.Parse( ""+lines[p].ToCharArray()[j] ) ? int.Parse( ""+lines[p].ToCharArray()[j] ): topTree;
                    //Console.WriteLine($"\t current {curTree} with contesten {topTree}");
                    if(topTree >= curTree){
                        botSeen = false;
                        //Console.WriteLine($"\t cant be seen, to small");
                        break; 
                    }
                }
                if (botSeen){
                    char[] temp = seen[i].ToCharArray();
                    temp[j] = 'S';
                    seen[i] =  new string(temp);
                    continue;
                }
            }
        }// checking each spot loop done

        int SeenCount = 0;
        foreach (string line in seen)
        {
            char[] temp = line.ToCharArray();
            SeenCount += temp.Count( x => x == 'S');
            Console.WriteLine($"\t {line}");
        }
        Console.WriteLine($"total of tree coverage is  {SeenCount}");
    }
}

