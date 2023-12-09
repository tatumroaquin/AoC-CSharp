namespace AoC_2023.Day_07;

public class AoC_2023_Day_07 {
  public static void Test() {
    List<(string,int)> cards = InputParser.ParseInput("07 Camel Cards/Data/PuzzleInput.in");
    // List<(string,int)> cards = InputParser.ParseInput("07 Camel Cards/Data/ExampleInput.in");
    // int part1 = Part1.Solution(cards);
    // Console.WriteLine($"Part 1 Answer: {part1}");

    long part2 = Part2.Solution(cards);
    Console.WriteLine($"Part 2 Answer: {part2}");
  }
}
