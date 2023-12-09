public class InputParser {
  public static IList<(int,int)> ParseInput1(string fileName) {
    string[] lines = File.ReadAllLines(fileName);

    IList<(int,int)> races  = new List<(int,int)>();
    IList<int> times        = new List<int>();
    IList<int> distances    = new List<int>();

    string line1 = lines[0].Split(':')[1];
    string line2 = lines[1].Split(':')[1];

    for (int i = 0; i < line1.Length; i++) {
      string word = "";
      while (i < line1.Length && line1[i] == ' ') i++;
      while (i < line1.Length && line1[i] != ' ') {
        word += line1[i++];
      }
      times.Add(int.Parse(word));
    }

    for (int i = 0; i < line2.Length; i++) {
      string word = "";
      while (i < line2.Length && line2[i] == ' ') i++;
      while (i < line2.Length && line2[i] != ' ') {
        word += line2[i++];
      }
      distances.Add(int.Parse(word));
    }

    for (int i = 0; i < times.Count; i++) {
      races.Add((times[i], distances[i]));
    }

    return races;
  }
  public static (ulong,ulong) ParseInput2(string fileName) {
    string[] lines = File.ReadAllLines(fileName);

    string line1 = lines[0].Split(':')[1].Replace(" ", "");
    string line2 = lines[1].Split(':')[1].Replace(" ", "");
    ulong time = ulong.Parse(line1);
    ulong distance = ulong.Parse(line2);

    return (time, distance);
  }
}
