namespace denCtvrty;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "data.txt";
        string content = File.ReadAllText(filePath);
        string[] lines = content.Split("\n");
        int counter = 0;
        bool diagonal = false; 
        bool opositeDiagonal = false;
        int linesLength = lines.Length;
        for (int i = 1; i < linesLength - 1; i++) // y
        {
            for (int j = 1; j < lines[i].Length - 1; j++) //x
            {
                diagonal = false;
                opositeDiagonal = false;
                if (lines[i][j] == 'A')
                {
                    if (lines[i+1][j+1] == 'M' && lines[i-1][j-1] == 'S')  
                    {
                        diagonal = true;
                    }
                    else if (lines[i+1][j+1] == 'S' && lines[i-1][j-1] == 'M') 
                    {
                        diagonal = true;
                    }
                    

                    if (lines[i-1][j+1] == 'M' && lines[i+1][j-1] == 'S')
                    {
                        opositeDiagonal = true;
                    }
                    else if (lines[i-1][j+1] == 'S' && lines[i+1][j-1] == 'M')
                    {
                        opositeDiagonal = true;
                    }
                    if(opositeDiagonal && diagonal) counter++;
                }

                /* if (lines[i][j] == 'X')
                {
                    if (j + 3 < lines[i].Length) // horizontal XMAS
                    {
                        if (i + 3 < linesLength) //diag 
                        {
                            if (lines[i+1][j+1] == 'M' && lines[i+2][j+2] == 'A' && lines[i+3][j+3] == 'S')
                            {
                                counter++;
                            }    
                        }

                        if (lines[i][j+1] == 'M' && lines[i][j+2] == 'A' && lines[i][j+3] == 'S')
                        {
                            counter++;
                        }
                        
                    }

                    if (j - 3 >= 0) // back horizontal
                    {
                        if (i - 3 >= 0) // backdiag
                        {
                            if (lines[i-1][j-1] == 'M' && lines[i-2][j-2] == 'A' && lines[i-3][j-3] == 'S')
                            {
                                counter++;
                            }
                        }
                        if (lines[i][j-1] == 'M' && lines[i][j-2] == 'A' && lines[i][j-3] == 'S') //back horizontal
                        {
                            counter++;
                        }
                    }

                    if (i + 3 < linesLength) //vert
                    {
                        if (j - 3 >= 0) // second diag
                        {
                            if (lines[i+1][j-1] == 'M' && lines[i+2][j-2] == 'A' && lines[i+3][j-3] == 'S')
                            {
                                counter++;
                            }
                        }
                        if (lines[i+1][j] == 'M' && lines[i+2][j] == 'A' && lines[i+3][j] == 'S')
                        {
                            counter++;
                        }
                        
                    }

                    if (i - 3 >= 0) //backvert
                    {
                        if (j + 3 < lines[i].Length) //second back diag
                        {
                            if (lines[i-1][j+1] == 'M' && lines[i-2][j+2] == 'A' && lines[i-3][j+3] == 'S')
                            {
                                counter++;
                            }
                        }
                        if (lines[i-1][j] == 'M' && lines[i-2][j] == 'A' && lines[i-3][j] == 'S')
                        {
                            counter++;
                        }
                        }
                    }*/
                    
            }
        }
        Console.WriteLine(counter);
    }
}