namespace AoC_2023.Day_02;

public class Game {
  public int Id;
  public IList<IList<(int,string)>> sets;
  public Game(int Id, IList<IList<(int,string)>> sets) {
    this.Id = Id;
    this.sets = sets;
  }
}

