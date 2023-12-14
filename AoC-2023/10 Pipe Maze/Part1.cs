namespace AoC_2023.Day_10;

public class Part1 {
  public static int Solution(string[] lines) {
    int m = lines.Length;
    int n = lines[0].Length;

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
        return directions;
      }

      switch(lines[i][j]) {
        case '|': // north and south
          return new (int,int)[] {(1, 0), (-1, 0)};
        case '-': // east and west
          return new (int,int)[] {(0, 1), (0, -1)};
        case 'L': // north and east
          return new (int,int)[] {(-1, 0), (0, 1)};
        case 'J': // north and west
          return new (int,int)[] {(-1, 0), (0, -1)};
        case '7': // south and west
          return new (int,int)[] {(1, 0), (0, -1)};
        case 'F': // south and east
          return new (int,int)[] {(1, 0), (0, 1)};
        case '.': // ground
          return Array.Empty<(int,int)>();
      }

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
    var dists = new Dictionary<(int,int),int>();
    var queue = new Queue<(int,int,int)>();
    queue.Enqueue((si, sj, 0));

    // Breadth First Search
    while (queue.Count != 0) {
      var (i, j, dist) = queue.Dequeue();
      var loc = (i, j);

      if (visited.Contains(loc)) continue;

      visited.Add(loc);
      dists[loc] = dist;

      foreach (var neighbour in getNeighbours(i, j)) {
        if (visited.Contains(neighbour)) continue;

        var (ni, nj) = neighbour;

        queue.Enqueue((ni, nj, dist + 1));
      }
    }

    return dists.Values.Max();
  }
}
