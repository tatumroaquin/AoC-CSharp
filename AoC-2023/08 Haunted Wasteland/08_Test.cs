namespace AoC_2023.Day_08;

public class AoC_2023_Day_08 {
  public static void Test() {
    InputParser.ParseInput("08 Haunted Wasteland/Data/PuzzleInput.in");
    int steps1 = Part1.Solution();
    long steps2 = Part2.Solution();
    Console.WriteLine($"Part 1 Answer: {steps1}");
    Console.WriteLine($"Part 2 Answer: {steps2}");
  }
}
