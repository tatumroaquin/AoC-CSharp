namespace AoC_2023.Day_04;

public class Card {
  public int id;
  public int[] winningNums;
  public int[] currentNums;
  public int points;

  public Card(int id, int[] winningNums, int[] currentNums) {
    this.id = id;
    this.winningNums = winningNums;
    this.currentNums = currentNums;
  }

  public string toString() {
    string res = "";
    res += $"ID: {this.id} ";
    res += "W:";
    foreach (int num in winningNums) {
      if (num > 9)
        res += $" {num}";
      else
        res += $"  {num}";
    }
    res += ' ';
    // res += $"W: {string.Join(' ', this.winningNums)} ";
    res += "C:";
    foreach (int num in currentNums) {
      if (num > 9)
        res += $" {num}";
      else
        res += $"  {num}";
    }
    res += ' ';
    return res;
  }

  public void SetPoints(int points) {
    this.points = points;
  }
}
