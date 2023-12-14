namespace AoC_2023.Day_10;

public class Part2 {
  public static int Solution(string[] lines) {
    int m = lines.Length;
    int n = lines[0].Length;

    // string[] lines = new string[m];
    // Array.Copy(_lines, lines, m);
    // // _lines.CopyTo(lines);

    IEnumerable<(int,int)> getNeighbours(int i, int j) {
      IList<(int,int)> neighbours = new List<(int,int)>();

      foreach (var (di, dj) in getDirections(i, j)) {
        int ii = i + di;
        int jj = j + dj;

        // if neighbour is within of bounds of the grid
        if (0 <= ii && ii < m && 0 <= jj && jj < n) {
          neighbours.Add((ii, jj));
        }
      }

      return neighbours;
    }

    var dirMap = new Dictionary<char,(int,int)[]> {
      {'|', new (int,int)[] {(1, 0), (-1, 0)}},
      {'-', new (int,int)[] {(0, 1), (0, -1)}},
      {'L', new (int,int)[] {(-1, 0), (0, 1)}},
      {'J', new (int,int)[] {(-1, 0), (0, -1)}},
      {'7', new (int,int)[] {(1, 0), (0, -1)}},
      {'F', new (int,int)[] {(1, 0), (0, 1)}},
      {'.', Array.Empty<(int,int)>()},
    };

    IEnumerable<(int,int)> getDirections(int i, int j) {
      List<(int,int)> directions = new List<(int,int)>();

      // at the starting point 'S', get 2nd degree neighbours of 'S'
      // and check if those 2nd degree neighbours points to 'S'
      // if they do add them to the directions
      if (lines[i][j] == 'S') {
        foreach (var (di, dj) in new List<(int,int)> {(-1, 0), (1, 0), (0, -1), (0, 1)}) {
          int ii = i + di;
          int jj = j + dj;
          if (getNeighbours(ii, jj).Contains((i, j))) {
            directions.Add((di, dj));
          }
        }

        // find a pipe that connects the same way as 'S'
        char pipe = '.';
        foreach (var kvp in dirMap) {
          Array.Sort(kvp.Value);
          directions.Sort((a, b) => a.CompareTo(b));
          if (directions.SequenceEqual(kvp.Value)) {
            pipe = kvp.Key;
            break;
          }
        }
        // replace 'S' with the pipe to avoid raycasting algo errors
        lines[i] = lines[i].Replace('S', pipe);

        return directions;
      }

      directions.AddRange(dirMap[lines[i][j]]);
      return directions;
    }

    int si = 0, sj = 0;
    for (int i = 0; i < m; i++) {
      if (lines[i].Contains('S')) {
        si = i;
        sj = lines[i].IndexOf('S');
        break;
      }
    }

    var visited = new HashSet<(int,int)>();
    var queue = new Queue<(int,int,int)>();
    queue.Enqueue((si, sj, 0));

    // Breadth First Search
    while (queue.Count != 0) {
      var (i, j, dist) = queue.Dequeue();
      var loc = (i, j);

      if (visited.Contains(loc)) continue;

      visited.Add(loc);

      foreach (var neighbour in getNeighbours(i, j)) {
        if (visited.Contains(neighbour)) continue;

        var (ni, nj) = neighbour;

        queue.Enqueue((ni, nj, dist + 1));
      }
    }

    // raycasting algo to determine if point is inside polygon
    bool IsPointInside(int i, int j) {
      // count (F-J or FJ) and (L-7 or L7) as one crossing
      // valid wall combos can be F,7,| or L,J,|

      char[] validWalls = {'F', '7', '|'};
      int count = 0;

      for (int k = 0; k < j; k++) {
        if (!visited.Contains((i, k))) continue;
        char c = lines[i][k];
        count += validWalls.Contains(c) ? 1 : 0;
      }

      return count % 2 == 1;
    }


    int ans = 0;
    for (int i = 0; i < m; i++) {
      string line = lines[i];
      for (int j = 0; j < n; j++) {
        if (visited.Contains((i, j))) continue;
        if (IsPointInside(i, j)) ans++;
      }
    }
    return ans;
  }
}
