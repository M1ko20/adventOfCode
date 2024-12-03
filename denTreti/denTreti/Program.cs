namespace denTreti;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "untitled.txt";
        string content = File.ReadAllText(filePath);
        int result = 0;
        bool can = true;
        for (int i = 0; i < content.Length - 3; i++)
        {
            if (content[i] == 'd' && content[i+1] == 'o')
            {
                i += 2;
                if (content[i] == '(' && content[i + 1] == ')')
                {
                    can = true;
                    i += 2;
                }
                else if (content[i] == 'n' && content[i + 1] == '\'' && content[i + 2] == 't' && content[i + 3] == '(' && content[i + 4] == ')')
                {
                    i += 5;
                    can = false;
                }
                
            }
            
            if (content[i] == 'm' && content [i+1] == 'u' && content[i+2] == 'l' && content[i+3] == '(' && can)
            {
                i += 4; 
                string test = content.Substring(i, 8); 
                int start = test.IndexOf(',');
                int end = test.IndexOf(')');
                if (start == -1 || end == -1 )
                {
                    continue;
                }
                if ( int.TryParse(test.Substring(0, start ), out int value) && int.TryParse(test.Substring(start+1, end - start - 1), out value))
                {
                    Console.WriteLine(test);
                    result += int.Parse(test.Substring(0, start )) * int.Parse(test.Substring(start + 1, end - start - 1));
                }
            }
        }
        Console.WriteLine(result);
    }
}