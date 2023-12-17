namespace AoC_2023.Day_11;

public class InputParser {
  public static string[] ParseInput(string fileName) {
    string[] lines = File.ReadAllLines(fileName);
    return lines;
  }
}
