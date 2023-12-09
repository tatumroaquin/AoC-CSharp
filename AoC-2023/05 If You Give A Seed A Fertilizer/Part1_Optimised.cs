public class Part1_Optimised {
  public static long Solution(Almanac_Part1 almanac) {
    List<long> locs = new List<long>();

    foreach (long seed in almanac.seeds) {
      long currLoc = seed;
      foreach (var maps in almanac.maps) {
        currLoc = GetDestination(currLoc, maps);
      }
      locs.Add(currLoc);
    }

    long[] sortedLocs = locs.ToArray();
    Array.Sort(sortedLocs);

    return sortedLocs[0];
  }

  private static long GetDestination(long loc, IList<(long,long,long)> maps) {
    long destination = loc;

    (long dst,long src,long range) map = (loc,loc,0);

    foreach(var (dst, src, range) in maps) {
      long head = src;
      long tail = src + range;
      if (head <= loc && loc <= tail) {
        map = (dst, src, range);
        break;
      }
    }

    long diff = loc - map.src;
    destination = map.dst + diff;

    return destination;
  }
}
