namespace AoC_2023.Day_01;

public class AoC_2023_Day_01 {
  public static void Test() {
    string[] calibrationDocument = InputParser.ParserInput("01 Trebuchet/Data/PuzzleInput.txt");
    long res = Part2.Solution(calibrationDocument);
    Console.WriteLine($"res {res}");
  }
}

