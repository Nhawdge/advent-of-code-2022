public static class Day3 {
    public static void SolvePart1() {
        var input = File.ReadAllLines("Day3/input.txt");
        var prioritySum = 0;

        foreach (var line in input) {
            var firstHalf = line.Substring(0, line.Length / 2).ToList();
            var secondHalf = line.Substring(line.Length / 2).ToList();

            foreach (var character in firstHalf) {
                if (secondHalf.Contains(character)) {
                    prioritySum += GetNumberValue(character);
                    secondHalf.Remove(character);
                    break;
                }
            }

        }
        Console.WriteLine($"Sum: {prioritySum}");
    }

    const string validLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static void SolvePart2() {
        var input = File.ReadAllLines("Day3/input.txt");
        var prioritySum = 0;

        var elfGroups = new List<List<string>>();
        var lineGroup = new List<string>();
        foreach (var line in input) {
            lineGroup.Add(line);
            if (lineGroup.Count == 3) {
                elfGroups.Add(lineGroup);
                lineGroup = new List<string>();
            }
        }
        foreach (var group in elfGroups) {
            var result = group[0].Intersect(group[1].ToList()).Intersect(group[2].ToList());
            prioritySum += result.Sum(c => GetNumberValue(c));
        }
        Console.WriteLine($"Sum: {prioritySum}");

    }

    public static int GetNumberValue(char letter) {
        if (char.IsUpper(letter))
            return letter - 64 + 26;
        else
            return letter - 96;
    }
}