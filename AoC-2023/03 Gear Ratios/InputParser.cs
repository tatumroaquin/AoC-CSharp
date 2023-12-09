namespace AoC_2023.Day_03;

public class InputParser {
  public static char[,] ParseInput(string fileName) {
    int xSize = GetX(fileName);
    int ySize = GetY(fileName);
    var res = new char[xSize,ySize];

    StreamReader reader = new StreamReader(fileName);
    string? line; int i = 0;
    while ((line = reader.ReadLine()) != null) {
      for (int j = 0; j < line.Length; j++) {
        res[i, j] = line[j];
      }
      i++;
    }

    return res;
  }
  private static int GetY(string fileName) {
    StreamReader reader = new StreamReader(fileName);
    int res = 0;
    while (reader.ReadLine() != null) res++;
    return res;
  }
  private static int GetX(string fileName) {
    StreamReader reader = new StreamReader(fileName);
    return reader.ReadLine()!.Length;
  }
}
