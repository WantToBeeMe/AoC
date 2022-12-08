// See https://aka.ms/new-console-template for more information
class scenic
{
    public static int getHighestSenic(string[] args, bool prints = false)
    {
        
        string[] lines = args;
        int height = lines.Length;
        int length = lines[0].Length;
        
        string[] seen = new string[lines.Length];
        for(int i = 0 ;i < height; i++){ //creating the seen/notseen table
            string x = "";
            for(int j = 0; j<length; j++)
                x += (char)0;
            seen[i]=x;
        }

        for(int i = 1; i < height-1; i++)  { //loops per line
            for(int j = 1; j<length-1; j++ ){ //loops per char in line
                int curTree = int.Parse( ""+lines[i].ToCharArray()[j] );
                //Console.WriteLine($"checking spot {i}-{j} with an hight of { curTree }");
                
                //seen on the left
                int topTree = 0;
                int leftScenic =0;
                for(int p = j-1; p>=0; p--){
                    topTree = topTree < int.Parse( ""+lines[i].ToCharArray()[p] ) ? int.Parse( ""+lines[i].ToCharArray()[p] ): topTree;
                    leftScenic++;
                    if(topTree >= curTree)
                        break; 
                }
                
                // seen on the right
                topTree = 0;
                int rightScenic =0;
                for(int p = j+1; p<length; p++){
                    topTree = topTree < int.Parse( ""+lines[i].ToCharArray()[p] ) ? int.Parse( ""+lines[i].ToCharArray()[p] ): topTree;
                    rightScenic++;
                    if(topTree >= curTree)
                        break;
                }

                //seen on the top
                topTree = 0;
                int topScenic =0;
                for(int p = i-1; p>=0; p--){
                    topTree = topTree < int.Parse( ""+lines[p].ToCharArray()[j] ) ? int.Parse( ""+lines[p].ToCharArray()[j] ): topTree;
                    topScenic++;
                    if(topTree >= curTree)
                        break; 
                }

                //seen on the top
                topTree = 0;
                int botScenic =0;
                for(int p = i+1; p<height; p++){
                    topTree = topTree < int.Parse( ""+lines[p].ToCharArray()[j] ) ? int.Parse( ""+lines[p].ToCharArray()[j] ): topTree;
                    botScenic++;
                    if(topTree >= curTree)
                        break; 
                }

                char[] temp = seen[i].ToCharArray();
                temp[j] = (char)(topScenic*botScenic*leftScenic*rightScenic);
                seen[i] =  new string(temp);

                if(prints)Console.WriteLine($"sum{topScenic}*{botScenic}*{leftScenic}*{rightScenic} = {(int)temp[j]} > {(seen[i].ToCharArray()[j])}");


            }
        }// checking each spot loop done

        int biggestScenic = 0;
        foreach (string line in seen)
        {
            foreach(char c in line.ToCharArray()){
                biggestScenic = biggestScenic < (int)c ? (int)c : biggestScenic;
            }
            if(prints)Console.WriteLine($"\t {line}");
        }
        if(prints)Console.WriteLine($"the biggest scenic spot is {biggestScenic}");
        return biggestScenic;
    }
}

