namespace AoC_2023.Day_08;

public class Part1 {
  public static int Solution() {
    string dirs = Document.GetDirections();
    IDictionary<string, (string L,string R)> paths = Document.GetPaths();

    int steps = 0;
    string location = "AAA";
    while (location != "ZZZ") {
      paths.TryGetValue(location, out (string L, string R) path);
      if (dirs[steps % dirs.Length] == 'L')
        location = path.L;
      if (dirs[steps % dirs.Length] == 'R')
        location = path.R;
      steps++;
    }

    return steps;
  }
}
