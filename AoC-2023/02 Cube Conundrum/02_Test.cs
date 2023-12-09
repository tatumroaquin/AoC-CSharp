namespace AoC_2023.Day_02;

public class AoC_2023_Day_02 {
  public static void Test() {
    List<Game> games = InputParser.ParseInput("02 Cube Conundrum/Data/PuzzleInput.txt");

    foreach(Game game in games) {
      Console.WriteLine($"GAME: {game.Id}");
      for (int i = 0; i < game.sets.Count; i++) {
        IList<(int,string)> set = game.sets[i];
        Console.WriteLine($"SET: {i+1} | LEN: {set.Count}");
        Console.WriteLine(string.Join(" ", set));
      }
    }

    int res = Part2.Solution(games);
    Console.WriteLine($"RESULT: {res}");
  }
}

