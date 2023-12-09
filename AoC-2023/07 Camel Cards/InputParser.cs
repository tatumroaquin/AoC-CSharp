namespace AoC_2023.Day_07;

public class InputParser {
  public static List<(string,int)> ParseInput(string fileName) {
    string[] lines = File.ReadAllLines(fileName);
    var res = new List<(string,int)>();
    foreach (string line in lines) {
      string hand = line.Split(' ')[0];
      string bid = line.Split(' ')[1];
      res.Add((hand, int.Parse(bid)));
    }
    return res;
  }
}
