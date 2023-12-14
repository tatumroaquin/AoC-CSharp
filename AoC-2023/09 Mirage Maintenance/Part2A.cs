namespace AoC_2023.Day_09;

public class Part2A {
  public static long Solution(List<List<long>> sequences) {
    // store the last numbers in every sequence
    long lastNumsTotal = 0;
    foreach (List<long> sequence in sequences) {
      List<long> curr = sequence;
      curr.Reverse(); // just reverse the input
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

    for (int i = 0; i < sequence.Count - 1; i++) {
      long curr = sequence[i];
      long next = sequence[i+1];

      long diff = next - curr;
      res.Add(diff);
    }
    return res;
  }
}
