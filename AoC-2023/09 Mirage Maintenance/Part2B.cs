namespace AoC_2023.Day_09;

public class Part2B {
  public static long Solution(List<List<long>> sequences) {
    // store the last numbers in every sequence
    long lastNumsTotal = 0;
    foreach (List<long> sequence in sequences) {
      List<long> curr = sequence;
      while (!curr.All(num => num == 0)) {
        lastNumsTotal += curr.Last();
        curr = GetNextSequence(curr);
      }
    }
    return lastNumsTotal;
  }

  private static List<long> GetNextSequence(List<long> sequence) {
    if (sequence.Count < 2) return new List<long> { 0 };
    var res = new List<long>();

    for (int i = sequence.Count - 1; i > 0; i--) {
      long prev = sequence[i-1];
      long curr = sequence[i];

      long diff = curr - prev;
      res.Insert(0, diff);
    }
    return res;
  }
}
