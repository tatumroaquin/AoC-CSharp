namespace AoC_2023.Day_11;

public class Part1 {
  public static int Solution(string[] lines) {
    int m = lines.Length, n = lines[0].Length;
    IList<(int X,int Y)> points = FindPoints(lines);

    bool[] rowMarks = new bool[m];
    bool[] colMarks = new bool[n];

    foreach (var p in points) {
      rowMarks[p.Y] = true;
      colMarks[p.X] = true;
    }

    int distance = 0;
    for (int i = 0; i < points.Count - 1; i++) {
      for (int j = i+1; j < points.Count; j++) {
        distance += Distance(
          points[i], points[j], rowMarks, colMarks
        );
      }
    }

    return distance;
  }

  private static int Distance((int X,int Y) p1, (int X,int Y) p2, bool[] rowMarks, bool[] colMarks) {
    // first calculate the original manhattan distance
    int dist = Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

    int x1 = Math.Min(p1.X, p2.X);
    int x2 = Math.Max(p1.X, p2.X);
    
    int y1 = Math.Min(p1.Y, p2.Y);
    int y2 = Math.Max(p1.Y, p2.Y);

    // if between two x coords is empty space add one to dist
    for (int i = x1; i < x2; i++) {
      if (colMarks[i] == false) dist += 1;
    }

    // if between two y coords is empty space add one to dist
    for (int i = y1; i < y2; i++) {
      if (rowMarks[i] == false) dist += 1;
    }

    return dist;
  }

  private static IList<(int,int)> FindPoints(string[] lines) {
    var res = new List<(int,int)>();
    for (int i = 0; i < lines.Length; i++) {
      for (int j = 0; j < lines[i].Length; j++) {
        if (lines[i][j] == '.') continue;
        res.Add((j, i));
      }
    }
    return res;
  }
}
