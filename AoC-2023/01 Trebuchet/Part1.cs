namespace AoC_2023.Day_01;

public class Part1 {
  public static long Solution(string[] calibrationDocument) {
    long result = 0;
    foreach (string s in calibrationDocument) {
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
      int a = int.Parse(s[l].ToString());
      int b = int.Parse(s[r].ToString());
      int num = (a * 10) + b;
      result += num;
    }
    return result;
  }
}
