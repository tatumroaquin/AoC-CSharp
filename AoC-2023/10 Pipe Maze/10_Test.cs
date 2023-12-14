namespace AoC_2023.Day_10;

public class AoC_2023_Day_10 {
  public static void Test() {
    string[] lines = InputParser.ParseInput("10 Pipe Maze/Data/PuzzleInput.in");
    string[] ex3 = InputParser.ParseInput("10 Pipe Maze/Data/Example3.in");
    int part1 = Part1.Solution(lines);
    int part2 = Part2.Solution(lines);
    Console.WriteLine($"Part 1 Answer: {part1}");
    Console.WriteLine($"Part 2 Answer: {part2}");
  }
}
