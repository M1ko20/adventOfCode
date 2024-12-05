using System.Data;
using System.Runtime.InteropServices.Marshalling;
using System.Collections.Generic;

namespace denPaty;

class Program
{
    public static int MiddleSorted(string line, Dictionary<int, List<int>> rulesDict)
    {
        string[] oneLine = line.Split(',');
        int result = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < oneLine.Length; i++)
        {
            list.Add(int.Parse(oneLine[i]));
        }

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (Compare(list[i], list[j], rulesDict) == -1)
                {
                        (list[i], list[j]) = (list[j], list[i]);
                }
            }
        }
        return list[list.Count / 2];

             //jit zleva do prava, kazde cislo zkontroluju jestli jake ma pravidla
            //pokud je splnuje tak jdu dal, jinak hledam na jakem indexu je cislo pro ktere to nesplnuje//COMPARER!!!!!
    }
    public static int Compare(int x, int y, Dictionary<int, List<int>> rulesDict)
    {
        if (!(rulesDict.ContainsKey(x)))
            return 1; 
        if (rulesDict[x].Contains(y))
        {
            return -1;
        }

        return 1;
    }
    
    static void Main(string[] args)
    {
       // string data =
         //   "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";
        string filePath = "data.txt";
        string data = File.ReadAllText(filePath);
        
        string[] separated = data.Split("\n\n");  
        string[] rules = separated[0].Split("\n");
        string[] lines = separated[1].Split("\n");
        Dictionary<int, List<int>> rulesDict = new Dictionary<int, List<int>>();
        for (int i = 0; i < rules.Length; i++)
        {
            string[] rule = rules[i].Split("|");
            int before = int.Parse(rule[0]);
            int current = int.Parse(rule[1]);

            if (!rulesDict.ContainsKey(current))
            {
                rulesDict.Add(current, new List<int>());
            }

            rulesDict[current].Add(before);
        }

        int result = 0;
        for (int i = 0; i < lines.Length; i++) //radky
        {
            string[] oneLine = lines[i].Split(",");
                bool rulesApplied = true;
            for (int j = 0; j < oneLine.Length; j++)
            {
                for (int k = j; k < oneLine.Length; k++)
                {
                    int key = int.Parse(oneLine[j]);
                    int value = int.Parse(oneLine[k]);
                    if (!rulesDict.ContainsKey(key)) continue;
                    if(rulesDict[key].Contains(value)) rulesApplied = false;
                }
            }
            //if(rulesApplied) result += int.Parse(oneLine[oneLine.Length/2]);
            if(!rulesApplied) result += MiddleSorted(lines[i], rulesDict);
        }
        Console.WriteLine(result);
    }
}