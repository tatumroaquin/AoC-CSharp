namespace AoC_2023.Day_11;

public class AoC_2023_Day_11 {
  public static void Test() {
    string[] input   = InputParser.ParseInput("11 Cosmic Expansion/Data/Input.in");
    string[] example = InputParser.ParseInput("11 Cosmic Expansion/Data/Example.in");
    int part1 = Part1.Solution(input);
    long part2 = Part2.Solution(input);
    Console.WriteLine($"Part 1 Answer: {part1}");
    Console.WriteLine($"Part 2 Answer: {part2}");
  }
}
