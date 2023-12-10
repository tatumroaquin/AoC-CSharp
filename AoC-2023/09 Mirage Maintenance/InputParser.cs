namespace AoC_2023.Day_09;

public class InputParser {
  public static List<List<long>> ParseInput(string fileName) {
    string[] lines = File.ReadAllLines(fileName);
    var res = new List<List<long>>();
    foreach (string line in lines) {
      res.Add(line.Split(' ').Select(num => long.Parse(num)).ToList<long>());
    }
    return res;
  }
}
