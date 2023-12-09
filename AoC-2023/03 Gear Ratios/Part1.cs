namespace AoC_2023.Day_03;

public class Part1 {
  public static int Solution(char[,] schematic) {
    PrintSchematic(schematic);
    HashSet<(int X,int Y)> locs = GetPartLocations(schematic);
    List<int> parts = GetPartNumbers(schematic, locs);

    int total = 0;
    foreach (int part in parts)
      total += part;

    return total;
  }

  private static List<int> GetPartNumbers(char[,] schematic, HashSet<(int X,int Y)> locs) {
    var res = new List<int>();

    int num = 0;
    foreach(var loc in locs) {
      int x = loc.X, y = loc.Y;
      char c = schematic[y, x];
      while (char.IsDigit(c)) {
        num *= 10;
        num += int.Parse(c.ToString());
        if (++x == schematic.GetLength(1)) break;
        c = schematic[y, x];
      }
      res.Add(num);
      num = 0;
    }
    return res;
  }

  private static HashSet<(int,int)> GetPartLocations(char[,] schematic) {
    int[][] dirs = new int[][] {
      new int[] {-1, -1},
      new int[] {0, -1},
      new int[] {1, -1},
      new int[] {-1, 0},
      new int[] {1, 0},
      new int[] {-1, 1},
      new int[] {0, 1},
      new int[] {1, 1},
    };

    int m = schematic.GetLength(0);
    int n = schematic.GetLength(1);
    var locations = new List<(int X, int Y)>();

    for (int i = 0; i < m; i++) {
      for (int j = 0; j < n; j++) {
        if (schematic[i,j] == '.') continue;
        if (char.IsDigit(schematic[i,j])) continue;
        foreach (int[] dir in dirs) {
          int p = i + dir[0];
          int q = j + dir[1];
          if (p >= 0 && q >= 0 && p < m && q < n) {
            if (char.IsDigit(schematic[p,q]))
              locations.Add((q, p));
          }
        }
      }
    }

    for (int i = 0; i < locations.Count; i++) {
      var loc = locations[i];
      while (loc.X > 0) {
        if (!char.IsDigit(schematic[loc.Y,loc.X-1])) break;
        loc.X--;
      }
      locations[i] = loc;
    }

    HashSet<(int X,int Y)> res = locations.ToHashSet();
    return res;
  }

  private static void PrintSchematic(char[,] schematic) {
    Console.WriteLine("=== Print Engine Schematic ===");
    for (int i = 0; i < schematic.GetLength(0); i++) {
      for (int j = 0; j < schematic.GetLength(1); j++) {
        Console.Write($"{schematic[i,j]} ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}
