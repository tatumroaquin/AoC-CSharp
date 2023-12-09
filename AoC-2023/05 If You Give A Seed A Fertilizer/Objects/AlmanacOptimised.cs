public class AlmanacOptimised {
  public IList<(long,long)> seeds;
  public IList<IList<(long,long,long)>> maps;

  public AlmanacOptimised(
    IList<(long,long)> seeds,
    IList<IList<(long,long,long)>> maps
  ) {
    this.seeds = seeds;
    this.maps  = maps;
  }
}
