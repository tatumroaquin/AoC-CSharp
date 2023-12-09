namespace AoC_2023.Day_06;

public class AoC_2023_Day_06 {
  public static void Test() {
    // IList<(int T,int D)> races = InputParser.ParseInput1("06 Wait For It/Data/ExampleInput.in");
    IList<(int T,int D)> races = InputParser.ParseInput1("06 Wait For It/Data/PuzzleInput.in");

    int res1 = Part1.Solution(races);
    Console.WriteLine($"Part1 Answer: {res1}");

    (ulong,ulong) race = InputParser.ParseInput2("06 Wait For It/Data/PuzzleInput.in");
    ulong res2 = Part2.Solution(race);
    Console.WriteLine($"Part2 Answer: {res2}");
  }
}
