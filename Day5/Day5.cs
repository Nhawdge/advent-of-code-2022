public static class Day5
{
    public static void SolvePart1()
    {
        var stacks = new Dictionary<int, List<string>>() {
            { 0, new List<string>() },
            { 1, new List<string>() },
            { 2, new List<string>() },
            { 3, new List<string>() },
            { 4, new List<string>() },
            { 5, new List<string>() },
            { 6, new List<string>() },
            { 7, new List<string>() },
            { 8, new List<string>() }
        };
        var input = File.ReadAllText("Day5/input.txt");
        var moves = new List<string>();

        foreach (var line in input.Split("\n"))
        {
            if (line.StartsWith("move"))
            {
                moves.Add(line.ToString());
            }
            else
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                stacks[0].AddFirstIf(line.Substring(0, 3));
                stacks[1].AddFirstIf(line.Substring(4, 3));
                stacks[2].AddFirstIf(line.Substring(8, 3));
                stacks[3].AddFirstIf(line.Substring(12, 3));
                stacks[4].AddFirstIf(line.Substring(16, 3));
                stacks[5].AddFirstIf(line.Substring(20, 3));
                stacks[6].AddFirstIf(line.Substring(24, 3));
                stacks[7].AddFirstIf(line.Substring(28, 3));
                stacks[8].AddFirstIf(line.Substring(32, 3));
            }
        }
        Console.WriteLine("Part 1:");
        PrintPuzzle(stacks);

        foreach (var move in moves)
        {
            var count = int.Parse(move.Split(" ")[1]);
            var to = int.Parse(move.Split(" ")[5]) - 1;

            var from = int.Parse(move.Split(" ")[3]) - 1;

            while (count > 0)
            {
                Console.WriteLine($"Moving {stacks[from].Last()} from {from + 1} to {to + 1}");
                if (stacks[from].Count == 0)
                    break;
                stacks[to].Add(stacks[from].Last());
                stacks[from].RemoveAt(stacks[from].Count - 1);
                count--;
                PrintPuzzle(stacks);
            }
        }

        Console.WriteLine("\nPart 2:");
        PrintPuzzle(stacks);

        Console.WriteLine("\nDone: " + string.Join("", stacks.Select(x => x.Value.LastOrDefault())));
    }

    public static void SolvePart2()
    {
        var stacks = new Dictionary<int, List<string>>() {
            { 0, new List<string>() },
            { 1, new List<string>() },
            { 2, new List<string>() }, { 3, new List<string>() }, { 4, new List<string>() }, { 5, new List<string>() }, { 6, new List<string>() }, { 7, new List<string>() }, { 8, new List<string>() } };
        var input = File.ReadAllText("Day5/input.txt");
        var moves = new List<string>();

        foreach (var line in input.Split("\n"))
        {
            if (line.StartsWith("move"))
            {
                moves.Add(line.ToString());
            }
            else
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                stacks[0].AddFirstIf(line.Substring(0, 3));
                stacks[1].AddFirstIf(line.Substring(4, 3));
                stacks[2].AddFirstIf(line.Substring(8, 3));
                stacks[3].AddFirstIf(line.Substring(12, 3));
                stacks[4].AddFirstIf(line.Substring(16, 3));
                stacks[5].AddFirstIf(line.Substring(20, 3));
                stacks[6].AddFirstIf(line.Substring(24, 3));
                stacks[7].AddFirstIf(line.Substring(28, 3));
                stacks[8].AddFirstIf(line.Substring(32, 3));
            }
        }
        Console.WriteLine("Part 1:");
        PrintPuzzle(stacks);

        foreach (var move in moves)
        {
            var count = int.Parse(move.Split(" ")[1]);
            var to = int.Parse(move.Split(" ")[5]) - 1;

            var from = int.Parse(move.Split(" ")[3]) - 1;


            Console.WriteLine($"Moving {count} from {from + 1} to {to + 1}");
            count = Math.Min(count, stacks[from].Count);
            var itemsToMove = stacks[from].TakeLast(count).ToList();
            stacks[to].AddRange(itemsToMove);
            itemsToMove.ToList().ForEach(x => stacks[from].Remove(x));
            count--;
            PrintPuzzle(stacks);
        }

        Console.WriteLine("\nPart 2:");
        PrintPuzzle(stacks);

        Console.WriteLine("\nDone: " + string.Join("", stacks.Select(x => x.Value.LastOrDefault())));
    }


    public static void AddIf(this List<string> list, string item)
    {
        if (!string.IsNullOrWhiteSpace(item) && item.StartsWith("["))
            list.Add(item);
    }
    public static void AddFirstIf(this List<string> list, string item)
    {
        if (!string.IsNullOrWhiteSpace(item) && item.StartsWith("["))
            list.Insert(0, item);
    }
    public static void PrintPuzzle(Dictionary<int, List<string>> stacks)
    {
        foreach (var stack in stacks)
        {
            Console.Write($"\n{stack.Key}:");
            foreach (var item in stack.Value)
            {
                Console.Write(item);
            }
        }
        Console.WriteLine("\n");
    }
}