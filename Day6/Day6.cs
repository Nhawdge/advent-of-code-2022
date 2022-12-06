using System.Net.NetworkInformation;
public static class Day6
{
    public static void SolvePart1()
    {
        var file = File.ReadAllText("Day6/input.txt");
        var characters = file.ToCharArray().ToList();
        var index = 0;
        foreach (var character in characters)
        {
            var segment = characters.Skip(index).Take(4).ToList();

            var unique = segment.Distinct().ToList();

            if (unique.Count == 4)
            {
                Console.WriteLine(string.Join("", segment) + "at index " + index);
                break;
            }
            index++;
            //Console.WriteLine(character);
        }
    }
    public static void SolvePart2()
    {
        var file = File.ReadAllText("Day6/input.txt");
        var characters = file.ToCharArray().ToList();
        var index = 0;
        foreach (var character in characters)
        {
            var segment = characters.Skip(index).Take(14).ToList();

            var unique = segment.Distinct().ToList();

            if (unique.Count == 14)
            {
                Console.WriteLine(string.Join("", segment) + "at index " + (index + 14));
                break;
            }
            index++;
        }
    }
}