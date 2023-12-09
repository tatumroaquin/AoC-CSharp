namespace AoC_2023.Day_02;

public class Part1 {
  public static int Solution(List<Game> games) {
    List<int> validGames = new List<int>();
    int res = 0;

    foreach(Game game in games) {

      bool gameIsValid = true;
      for (int i = 0; i < game.sets.Count; i++) {

        var map = new Dictionary<string,int> {
          {"red", 12},
          {"green", 13},
          {"blue", 14},
        };

        IList<(int Number, string Color)> set = game.sets[i];
        foreach((int Count, string Color) kvp in set) {
          map.TryGetValue(kvp.Color, out int num);
          map[kvp.Color] = num - kvp.Count;
        }

        foreach(var kvp in map) {
          if (kvp.Value < 0) {
            gameIsValid = false;
            break;
          }
        }
      }
      if (gameIsValid) validGames.Add(game.Id);

      res += gameIsValid ? game.Id : 0;
    }
    Console.WriteLine($"VALID GAMES: {string.Join(" ", validGames)}");
    return res;
  }
}

