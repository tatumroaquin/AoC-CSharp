namespace AoC_2023.Day_08;

// upon observation each starting point and end point is cyclical.
// traversing the length of a cycle, we return to the starting node.
// we must count the amount of repeats every cycle must make to sync up.
// we use the LCM because it is the common number that is equally divisible in all cycle lengths

public class Part2 {
  public static long Solution() {
    string dirs = Document.GetDirections();
    IDictionary<string, (string L,string R)> paths = Document.GetPaths();
    // map and filter dictionary get all keys ending with 'A'
    var startPoints =  paths
      .Select(p => p.Key)
      .Where(key => key[2] == 'A');
    var cycleLengths = new List<long>();

    foreach (string point in startPoints) {
      int steps = 0;
      string curr = point;
      // if the current node ends with z break the loop
      while (curr[2] != 'Z') {
        if (dirs[steps % dirs.Length] == 'L')
          curr = paths[curr].L;
        if (dirs[steps % dirs.Length] == 'R')
          curr = paths[curr].R;
        steps++;
      }
      cycleLengths.Add(steps);
    }

    // calculate the LCM of all the cycle lengths
    return cycleLengths.Aggregate((long a, long b) => LCM(a, b));
  }

  private static long GCD(long a, long b) {
    while (b != 0) {
      // long tmp = b;
      // b = a % b;
      // a = tmp;
      (a, b) = (b, a % b); // fancy tuple variable swap
    }
    return a;
  }

  private static long LCM(long a, long b) {
    return a * b / GCD(a, b);
  }
}
