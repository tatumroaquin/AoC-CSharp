public class Almanac_Part1 {
  public IList<long> seeds;
  public IList<IList<(long,long,long)>> maps;

  public Almanac_Part1(
    IList<long> seeds,
    IList<IList<(long,long,long)>> maps
  ) {
    this.seeds = seeds;
    this.maps  = maps;
  }
}
