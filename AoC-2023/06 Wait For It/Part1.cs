namespace AoC_2023.Day_06;

public class Part1 {
  public static int Solution(IList<(int,int)> races) {
    var ans = new List<int>();

    foreach ((int time, int dist) in races) {
      int winCount = 0;
      for (int i = 1; i <= time; i++) {
        if (i * (time-i) > dist) winCount++;
      }
      ans.Add(winCount);
    }

    return ans.Aggregate((a, b) => a * b);
  }
}
