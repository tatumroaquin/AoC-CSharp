namespace AoC_2023.Day_01;

public class Part2 {
  private static int findLeftOccurrence(string s, string t) {
    int sLen = s.Length,
      tLen = t.Length;

    for (int i = 0; i <= sLen - tLen; i++) {
      int j;
      for (j = 0; j < tLen; j++) {
        if (s[i + j] != t[j])
          break;
      }
      if (j == tLen)
        return i;
    }
    return -1;
  }

  private static int findRightOccurrence(string s, string t) {
    int sLen = s.Length,
      tLen = t.Length;

    for (int i = sLen - tLen + 1; i >= 0; i--) {
      int j;
      for (j = 0; j < tLen; j++) {
        if (s[i + j] != t[j])
          break;
      }
      if (j == tLen)
        return i;
    }
    return -1;
  }

  public static long Solution(string[] calibrationDocument) {
    long result = 0;

    var map = new Dictionary<string, int> { { "zero", 0 }, { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 },
    };

    foreach (string s in calibrationDocument) {
      var leftIndexMap = new List<(int Left,string Right)>();
      foreach (var kvp in map) {
        int leftIndex = findLeftOccurrence(s, kvp.Key);
        if (leftIndex != -1 && !leftIndexMap.Contains((leftIndex, kvp.Key)))
          leftIndexMap.Add((leftIndex, kvp.Key));
      }

      var rightIndexMap = new List<(int Left,string Right)>();
      foreach (var kvp in map) {
        int rightIndex = findRightOccurrence(s, kvp.Key);
        if (rightIndex != -1 && !rightIndexMap.Contains((rightIndex, kvp.Key)))
          rightIndexMap.Add((rightIndex, kvp.Key));
      }

      leftIndexMap.Sort((a, b) => a.Left - b.Left);
      rightIndexMap.Sort((a, b) => b.Left - a.Left);

      (int,string) leftMostWord = leftIndexMap.DefaultIfEmpty((-1, "NaN")).First();
      (int,string) rightMostWord = rightIndexMap.DefaultIfEmpty((-1, "NaN")).First();

      int sLen = s.Length;
      int l = 0, r = sLen - 1;
      while (l < sLen) {
        if (char.IsDigit(s[l])) break;
        l++;
      }
      while (r >= 0) {
        if (char.IsDigit(s[r])) break;
        r--;
      }
      int a = 0, b = 0;
      if (l <= leftMostWord.Item1 || leftMostWord.Item1 == -1) {
        a = int.Parse(s[l].ToString());
      } else {
        map.TryGetValue(leftMostWord.Item2, out int num);
        a = num;
      }
      if (r >= rightMostWord.Item1 || rightMostWord.Item1 == -1) {
        b = int.Parse(s[r].ToString());
      } else {
        map.TryGetValue(rightMostWord.Item2, out int num);
        b = num;
      }
      if (a == 0) a = b;
      if (b == 0) b = a;
      Console.WriteLine($"L:{a} R:{b} N: {(a*10)+b} {s}");
      result += (a*10)+b;
    }
    return result;
  }
}
