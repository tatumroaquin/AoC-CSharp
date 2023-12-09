namespace AoC_2023.Day_03;

public class Part2 {
  public static long Solution(char[,] schematic) {
    // PrintSchematic(schematic);
    List<(int, int)> gearLocs = GetGearLocations(schematic);
    HashSet<(int, int)> partLocs = GetPartLocations(schematic, gearLocs);
    List<int> partNums = GetPartNumbers(schematic, partLocs);

    // Console.WriteLine(string.Join("\n", gearLocs));

    long total = 0;
    for (int i = 1; i < partNums.Count; i += 2) {
      int n1 = partNums[i - 1];
      int n2 = partNums[i];
      total += (n1 * n2);
    }

    return total;
  }

  private static List<int> GetPartNumbers(char[,] schematic, HashSet<(int X, int Y)> partLocs) {
    var res = new List<int>();

    int num = 0;
    foreach (var loc in partLocs) {
      int x = loc.X,
        y = loc.Y;
      char c = schematic[y, x];
      while (char.IsDigit(c)) {
        num *= 10;
        num += int.Parse(c.ToString());
        if (++x == schematic.GetLength(1))
          break;
        c = schematic[y, x];
      }
      res.Add(num);
      num = 0;
    }

    return res;
  }

  private static HashSet<(int, int)> GetPartLocations(
    char[,] schematic,
    List<(int X, int Y)> gearLocs
  ) {
    var partLocs = new List<(int, int)>();
    var dirs = new int[][] {
      new int[] { -1, -1 },
      new int[] { 0, -1 },
      new int[] { 1, -1 },
      new int[] { -1, 0 },
      new int[] { 1, 0 },
      new int[] { -1, 1 },
      new int[] { 0, 1 },
      new int[] { 1, 1 },
    };

    int m = schematic.GetLength(0),
      n = schematic.GetLength(1);
    foreach ((int X, int Y) loc in gearLocs) {
      foreach (int[] dir in dirs) {
        int p = loc.Y + dir[0];
        int q = loc.X + dir[1];
        if (p >= 0 && q >= 0 && p < m && q < n) {
          if (char.IsDigit(schematic[p, q]))
            partLocs.Add((q, p));
        }
      }
    }

    for (int i = 0; i < partLocs.Count; i++) {
      (int X, int Y) loc = partLocs[i];
      while (loc.X > 0) {
        if (!char.IsDigit(schematic[loc.Y, loc.X - 1]))
          break;
        loc.X--;
      }
      partLocs[i] = loc;
    }

    return partLocs.ToHashSet();
  }

  private static List<(int,int)> GetGearLocations(char[,] schematic) {
    int m = schematic.GetLength(0);
    int n = schematic.GetLength(1);

    var locations = new List<(int,int)>();

    for (int i = 0; i < m; i++) {
      for (int j = 0; j < n; j++) {
        if (schematic[i, j] != '*') {
          continue;
        }

        if (IsGear(schematic, i, j)) {
          locations.Add((j, i));
        }
      }
    }

    return locations;
  }

  private static bool IsGear(char[,] schematic, int i, int j) {
    int[][] topRow = new int[][] {
     new int[] { -1, -1 },
     new int[] { 0, -1 },
     new int[] { 1, -1 },
    };
    int[][] midRow = new int[][] {
     new int[] { -1, 0 },
     new int[] { 1, 0 }, 
    };
    int[][] botRow = new int[][] {
      new int[] { -1, 1 },
      new int[] { 0, 1 },
      new int[] { 1, 1 },
    };
    var map = new Dictionary<string, int> { 
      { "000", 0 },
      { "001", 1 },
      { "010", 1 },
      { "011", 1 },
      { "100", 1 },
      { "101", 2 },
      { "110", 1 },
      { "111", 1 },
      { "10",  1 },
      { "01",  1 },
      { "11",  2 },
    };

    int m = schematic.GetLength(0), n = schematic.GetLength(1);

    int adjacentValuesCount = 0;

    string topKey = "";
    foreach (int[] dir in topRow) {
      int p = i + dir[1];
      int q = j + dir[0];
      if (p >= 0 && q >= 0 && p < m && q < n) {
        if (char.IsDigit(schematic[p, q])) {
          topKey += '1';
        } else {
          topKey += '0';
        }
      }
    }

    string midKey = "";
    foreach (int[] dir in midRow) {
      int p = i + dir[1];
      int q = j + dir[0];
      if (p >= 0 && q >= 0 && p < m && q < n) {
        if (char.IsDigit(schematic[p, q]))
          midKey += '1';
        else
          midKey += '0';
      }
    }

    string botKey = "";
    foreach (int[] dir in botRow) {
      int p = i + dir[1];
      int q = j + dir[0];
      if (p >= 0 && q >= 0 && p < m && q < n) {
        if (char.IsDigit(schematic[p, q]))
          botKey += '1';
        else
          botKey += '0';
      }
    }

    map.TryGetValue(topKey, out int topNum);
    map.TryGetValue(botKey, out int botNum);
    map.TryGetValue(midKey, out int midNum);
    adjacentValuesCount += topNum;
    adjacentValuesCount += botNum;
    adjacentValuesCount += midNum;

    Console.WriteLine($"X:{j} Y:{i}; ADJ: {adjacentValuesCount}");
    Console.WriteLine($"top: {topKey}, mid: {midKey}, bot: {botKey}");
    Console.WriteLine();
    return adjacentValuesCount == 2;
  }

  private static void PrintSchematic(char[,] schematic) {
    Console.WriteLine("=== Print Engine Schematic ===");
    for (int i = 0; i < schematic.GetLength(0); i++) {
      for (int j = 0; j < schematic.GetLength(1); j++) {
        Console.Write($"{schematic[i, j]} ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}
