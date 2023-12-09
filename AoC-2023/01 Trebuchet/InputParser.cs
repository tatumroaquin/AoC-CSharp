namespace AoC_2023.Day_01;

public class InputParser {
  public static string[] ParserInput(string fileName) {
    string[] lines = File.ReadAllLines(fileName);
    return lines;
  }
}
