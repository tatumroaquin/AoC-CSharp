namespace AoC_2023.Day_09;

public class AoC_2023_Day_09 {
  public static void Test() {
    List<List<long>> example = InputParser.ParseInput("09 Mirage Maintenance/Data/ExampleInput.in");
    List<List<long>> sequences = InputParser.ParseInput("09 Mirage Maintenance/Data/PuzzleInput.in");
    // foreach (var sequence in sequences) {
    //   foreach (long num in sequence) {
    //     Console.Write($"{num} ");
    //   }
    //   Console.WriteLine();
    // }
    long part1 = Part1.Solution(sequences);
    long part2 = Part2.Solution2(sequences);
    Console.WriteLine($"Part 1 Answer: {part1}");
    Console.WriteLine($"Part 2 Answer: {part2}");
  }
}
