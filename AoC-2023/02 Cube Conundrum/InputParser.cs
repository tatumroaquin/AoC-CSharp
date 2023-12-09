namespace AoC_2023.Day_02;

public class InputParser {
  public static List<Game> ParseInput(string fileName) {
    List<Game> games = new List<Game>();
    StreamReader reader = File.OpenText(fileName);
    string? line;

    while ((line = reader.ReadLine()) != null) {
      int.TryParse(GetGameId(line), out int gameId);
      IList<IList<(int,string)>> gameSets = GetGameSets(line);
      games.Add(new Game(gameId, gameSets));
    }

    return games;
  }

  private static string GetGameId(string line) {
    int i = 5;
    while (i < line.Length && line[i] != ':') i++;
    return line.Substring(5, i-5);
  }

  private static IList<IList<(int,string)>> GetGameSets(string line) {
    var res = new List<IList<(int,string)>>();

    int i = 0;
    // Skip the Game Id go to first non-whitespace character after the colon
    while (i < line.Length && line[i] != ':')
      i++;
    i += 2; // cursor is currently at colon skip both colon and whitespace

    string setLine = "";
    while (i < line.Length) {
      setLine += line[i];
      i++;
    }

    string[] subsets = setLine.Split("; ");
    foreach (string subset in subsets) {
      string[] cubes = subset.Split(", ");
      var list = new List<(int, string)>();
      foreach (string cube in cubes) {
        string[] cubeData = cube.Split(' ');
        int.TryParse(cubeData[0], out int num);
        list.Add((num, cubeData[1]));
      }
      res.Add(list);
    }

    return res;
  }
}

