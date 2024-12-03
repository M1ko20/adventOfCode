namespace denDruhy;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "input.txt";
        string content = File.ReadAllText(filePath);
        string[] radek = content.Split("\n");
        int counter = 0;
        bool done = true;
        bool wrong = false;
        int ascdesc = 0; // 1 = asc, 2 = desc
        foreach (var s in radek)
        {
            ascdesc = 0;
            done = true;
            wrong = false;
            string[] line  = s.Split(" ");
            int lengthOfLine = line.Length;
            
               for (int i = 0; i < lengthOfLine - 1; i++)
               {
                       // 1, 2, 4, 2
                       // 1, 4, 4, 6
                   if ((int.Parse(line[i]) > int.Parse(line[i+1]) && int.Parse(line[i]) <= int.Parse(line[i + 1]) + 3) && ascdesc != 2) //asc
                   {
                       ascdesc = 1;
                   }
                   else if ((int.Parse(line[i]) < int.Parse(line[i+1]) && int.Parse(line[i]) >= int.Parse(line[i + 1]) - 3) && ascdesc != 1) //desc
                   {
                       ascdesc = 2;
                   }
                   else if (!wrong)
                   {
                       for (int j = i ; j < lengthOfLine - 1; j++)
                       {
                           line[j] = line[j + 1];
                       }
                       wrong = true;
                       i--;
                       lengthOfLine--;
                   }
                   else
                   {
                       done = false;
                       break;
                   }
               }
               if (done) counter++;
        }
        //256 too low
        
        Console.WriteLine(counter);
    }
}


/*         if (int.Parse(line[0]) > int.Parse(line[1]) &&  int.Parse(line[0]) <= int.Parse(line[1]) + 3) //desc
           {
               for (int i = 1; i < lengthOfLine - 1; i++)
               {
                   if (!(int.Parse(line[i]) > int.Parse(line[i+1]) && int.Parse(line[i]) <= int.Parse(line[i + 1]) + 3))
                   {
                       if (!wrong)
                       {
                           for (int j = i + 1; j < lengthOfLine - 1; j++)
                           {
                               line[j] = line[j + 1];
                           }
                           wrong = true;
                           i--;
                           lengthOfLine--;
                       }
                       else {
                           done = false;
                           break;
                       }
                   }
               }
               if (done) counter++;
           }

           else if (int.Parse(line[0]) < int.Parse(line[1]) &&  int.Parse(line[0]) >= int.Parse(line[1]) - 3) //asc
           {
               for (int i = 1; i < lengthOfLine - 1; i++)
               {
                   if (!(int.Parse(line[i]) < int.Parse(line[i+1]) && int.Parse(line[i]) >= int.Parse(line[i + 1]) - 3))
                   {
                       if (!wrong)
                       {
                           for (int j = i + 1; j < lengthOfLine - 1; j++)
                           {
                               line[j] = line[j + 1];
                           }
                           wrong = true;
                           i--;
                           lengthOfLine--;
                       }
                       else {
                           done = false;
                           break;
                       }
                   }
               }
               if (done) counter++;
           }
       }
*/