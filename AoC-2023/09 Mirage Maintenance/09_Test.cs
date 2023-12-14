namespace AoC_2023.Day_09;

public class AoC_2023_Day_09 {
  public static void Test() {
    List<List<long>> example = InputParser.ParseInput("09 Mirage Maintenance/Data/ExampleInput.in");
    List<List<long>> sequences = InputParser.ParseInput("09 Mirage Maintenance/Data/PuzzleInput.in");
    long part1 = Part1.Solution(sequences);
    long part2a = Part2A.Solution(sequences);
    long part2b = Part2B.Solution(sequences);
    Console.WriteLine($"Part 1 Answer: {part1}");
    Console.WriteLine($"Part 2A Answer: {part2a}");
    Console.WriteLine($"Part 2B Answer: {part2b}");
  }
}
