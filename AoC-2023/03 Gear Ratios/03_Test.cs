namespace AoC_2023.Day_03;

public class AoC_2023_Day_3 {
  public static void Test() {
    char[,] schematic = InputParser.ParseInput("03 Gear Ratios/Data/ExampleInput.in");
    long res = Part2.Solution(schematic);
    Console.WriteLine(res);
  }
}

