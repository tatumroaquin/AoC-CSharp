namespace AoC_2023.Day_02;

public class Part2 {
  public static int Solution(List<Game> games) {
    var minSet = new List<(int,int,int)>();
    int res = 0;

    foreach(Game game in games) {
      var map = new Dictionary<string,int> {
        {"red", 0},
        {"green", 0},
        {"blue", 0},
      };

      for (int i = 0; i < game.sets.Count; i++) {
        IList<(int Number, string Color)> set = game.sets[i];
        foreach((int Count, string Color) kvp in set) {
          map.TryGetValue(kvp.Color, out int num);
          map[kvp.Color] = Math.Max(num, kvp.Count);
        }
      }
      minSet.Add((map["red"], map["green"], map["blue"]));
    }

    foreach (var triplet in minSet) {
      res += triplet.Item1 * triplet.Item2 * triplet.Item3;
    }

    return res;
  }
}

