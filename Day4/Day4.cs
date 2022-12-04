using System.ComponentModel.DataAnnotations;
public static class Day4 {
    public static void SolvePart1() {
        var lines = File.ReadAllLines("Day4/input.txt");
        var count = 0;
        var groups = new List<List<string>>();
        foreach (var line in lines) {
            var elf1 = new Elf(line.Split(',') [0]);
            var elf2 = new Elf(line.Split(',') [1]);
            if ((elf1.Start >= elf2.Start && elf1.End <= elf2.End) || elf2.Start >= elf1.Start && elf2.End <= elf1.End) {
                count++;
            }
        }
        Console.WriteLine(count);
    }
    public static void SolvePart2() {
        var lines = File.ReadAllLines("Day4/input.txt");
        var count = 0;
        var groups = new List<List<string>>();
        foreach (var line in lines) {
            var elf1 = new Elf(line.Split(',') [0]);
            var elf2 = new Elf(line.Split(',') [1]);
            if (elf1.Range.Intersect(elf2.Range).Any()) {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    public record Elf(int Start, int End) {
        public Elf(string input) : this(int.Parse(input.Split('-') [0]), int.Parse(input.Split('-') [1])) { }
        public List<int> Range => Enumerable.Range(Start, End - Start + 1).ToList();
    };
}