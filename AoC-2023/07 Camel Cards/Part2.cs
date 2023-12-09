namespace AoC_2023.Day_07;

public class Part2 {
  public static long Solution(List<(string, int)> hands) {
    // https://learn.microsoft.com/en-us/dotnet/api/system.string.compareordinal?view=net-8.0
    // This sorting logic replicates python's "sorted" function behaviour
    // By default C# comparison compares alphabetically, but we need to calculate based on numeric values of letters instead.
    hands.Sort((a,b) => {
        var strengthA = Strength(a.Item1);
        var strengthB = Strength(b.Item1);
        int cmp = strengthA.Item1.CompareTo(strengthB.Item1);
        if (cmp == 0) {
          return String.CompareOrdinal(strengthA.Item2, strengthB.Item2);
        }
        return cmp;
    });

    int totalScore = 0;
    // Calculate the total score based on the sorted hands
    for (int i = 0; i < hands.Count; i++) {
      totalScore += (i + 1) * hands[i].Item2;
    }

    // Return the total score for the current part
    return totalScore;
  }

  // Function to determine the strength of a hand
  private static (int, string) Strength(string hand) {
    hand = hand.Replace('T', (char)(('9') + 1)).ToString();
    hand = hand.Replace('J', (char)(('2') - 1)).ToString();
    hand = hand.Replace('Q', (char)(('9') + 3)).ToString();
    hand = hand.Replace('K', (char)(('9') + 4)).ToString();
    hand = hand.Replace('A', (char)(('9') + 5)).ToString();

    Dictionary<char, int> C = hand
     .GroupBy(c => c)
     .ToDictionary(g => g.Key, g => g.Count());

    char target = C.Keys.Last();
    foreach (var k in C.Keys) {
      if (k == '1')
        continue;

      if (C[k] > C[target] || target == '1') {
        target = k;
      }
    }

    if (C.ContainsKey('1') && target != '1') {
      C[target] += C['1'];
      C.Remove('1');
    }

    IEnumerable<int> sortedValues = C.Values.OrderBy(v => v);

    (int, string) res = (0, hand);
    if (sortedValues.SequenceEqual(new[] { 5 })) {
      res = (7, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 1, 4 })) {
      res = (6, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 2, 3 })) {
      res = (5, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 1, 1, 3 })) {
      res = (4, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 1, 2, 2 })) {
      res = (3, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 1, 1, 1, 2 })) {
      res = (2, hand);
    }
    else if (sortedValues.SequenceEqual(new[] { 1, 1, 1, 1, 1 })) {
      res = (1, hand);
    }

    Console.WriteLine(res);
    return res;
  }
}
