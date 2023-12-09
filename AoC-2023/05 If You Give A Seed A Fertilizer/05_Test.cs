public class AoC_2023_Day_05 {
  public static void Test() {
    // AlmanacNaive a = InputParserNaive.ParserInput("Data/ExampleInput.txt");
    // long res = Part1_Naive.Solution(a);

    AlmanacOptimised a = InputParserOptimised.ParserInput("Data/PuzzleInput.txt");

    // Console.WriteLine(string.Join('\n', a.maps[0]));

    long res = Part2.Solution(a);
    Console.WriteLine(res);
  }
}
