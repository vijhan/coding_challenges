// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


List<Letter> letters = new List<Letter>();
        letters.Add(new Letter()
        {
            character = "a",
            DependsOn = new[] { "f" }
        });
        letters.Add(new Letter()
        {
            character = "b",
            DependsOn = new[] { "f" }
        });
        letters.Add(new Letter()
        {
            character = "c",
            DependsOn = new[] { "d" }
        });
        letters.Add(new Letter()
        {
            character = "d",
            DependsOn = new[] { "a", "b" }
        });
        letters.Add(new Letter() { character = "e" });
        letters.Add(new Letter() { character = "f" });
        
        

        foreach (var field in letters)
        {
            Console.WriteLine(field.character);
            if(field.DependsOn != null)
                foreach (var item in field.DependsOn)
                {
                    Console.WriteLine(" -{0}",item);
                }
        }

        Console.WriteLine("\n...Sorting...\n");

        int[] sortOrder = getTopologicalSortOrder(letters);

        for (int i = sortOrder.Length - 1; i >= 0; i--)
        {
            var field = letters[sortOrder[i]];
            Console.WriteLine(field.character);
            /*if (field.DependsOn != null)
                foreach (var item in field.DependsOn)
                {
                    Console.WriteLine(" -{0}", item);
                }
            */
        }


 static int[] getTopologicalSortOrder(List<Letter> letters)
    {
        TopologicalSorter g = new TopologicalSorter(letters.Count);
        Dictionary<string, int> _indexes = new Dictionary<string, int>();

        //add vertices
        for (int i = 0; i < letters.Count; i++)
        {
            _indexes[letters[i].character.ToLower()] = g.AddVertex(i);
        }

        //add edges
        for (int i = 0; i < letters.Count; i++)
        {
            if (letters[i].DependsOn != null)
            {
                for (int j = 0; j < letters[i].DependsOn.Length; j++)
                {
                    g.AddEdge(i,
                        _indexes[letters[i].DependsOn[j].ToLower()]);
                }
            }
        }

        int[] result = g.Sort();
        return result;

    }





