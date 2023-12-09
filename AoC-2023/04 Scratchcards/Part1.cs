namespace AoC_2023.Day_04;

public class Part1 {
  public static long Solution(IList<Card> cards) {
    var points = new List<long>();

    foreach (Card c in cards) {
      int matches = 0;
      long total = 0;
      foreach (int num in c.winningNums) {
        if (c.currentNums.Contains(num))
          matches++;
      }

      total = (long) Math.Pow(2, matches - 1);
      points.Add(total);
    }
    Console.WriteLine();

    return points.Sum();
  }
}
