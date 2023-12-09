public class Part2 {
  public static long Solution(AlmanacOptimised almanac) {
    long ans = long.MaxValue;

    foreach (var (start, range) in almanac.seeds) {
      var curIntervals = new List<(long,long)> { (start, start + range - 1) };
      var newIntervals = new List<(long,long)>();
      foreach (var map in almanac.maps) {
        foreach (var (lo, hi) in curIntervals) {
          newIntervals.AddRange(Remap(lo,hi,map));
        }
        curIntervals = newIntervals;
        newIntervals = new List<(long,long)>();
      }
      foreach (var (lo, hi) in curIntervals) {
        ans = Math.Min(ans, lo);
      }
    }

    return ans;
  }

  private static IEnumerable<(long,long)> Remap(long lo, long hi, IList<(long,long,long)> map) {
    var locs = new List<(long L,long R,long D)>();

    foreach(var (dst, src, range) in map) {
      long end = src + range - 1;
      long D = dst - src;

      if (lo <= end && hi >= src) {
        locs.Add(( Math.Max(src, lo), Math.Min(end, hi), D));
      }
    }

    for (int i = 0; i < locs.Count; i++) {
      var (L, R, D) = locs[i];
      yield return (L + D, R + D);

      // if there is a gap between the current interval and the next
      if (i < locs.Count - 1 && locs[i+1].L > R + 1) {
        // return a range that covers that gap
        yield return (R + 1, locs[i+1].L - 1);
      }
    }

    // this means (lo and hi) does not overlap any source range
    if (locs.Count == 0) {
      yield return (lo, hi);
      yield break;
    }

    // this means there is a gap between seed lo and overlapping source start
    if (locs[0].L != lo) {
      yield return (lo, locs[0].L - 1);
    }

    // this means there is a gap between overlapping source end and seed hi
    if (locs[^1].R != hi) {
      yield return (locs[^1].R + 1, hi);
    }
  }
}
