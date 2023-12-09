namespace AoC_2023.Day_08;

public class InputParser {
  public static void ParseInput(string fileName) {
    string[] lines        = File.ReadAllLines(fileName);
    string directions     = lines[0];
    var paths             = InputParser.ParsePaths(lines.Skip(2));
    Document.SetDirections(directions);
    Document.SetPaths(paths);
  }

  private static IDictionary<string, (string, string)> ParsePaths(IEnumerable<string> lines) {
    var res = new Dictionary<string,(string,string)>();
    foreach (string line in lines) {
      string[] parts = line.Split(' ');
      string key = parts[0];
      string left = parts[2].Substring(1,3);
      string right = parts[3].Substring(0,3);
      res.Add(key, (left, right));
    }
    return res;
  }
}
