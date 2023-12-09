namespace AoC_2023.Day_08;

public static class Document {
  private static string start = "";
  private static string goal = "";
  private static string directions = "";
  private static IDictionary<string, (string, string)> paths =
    new Dictionary<string, (string, string)>();

  public static void SetStart(string start) {
    Document.start = start;
  }

  public static void SetGoal(string goal) {
    Document.goal = goal;
  }

  public static void SetDirections(string directions) {
    Document.directions = directions;
  }

  public static void SetPaths(IDictionary<string,(string,string)> paths) {
    Document.paths = paths;
  }

  public static string GetStart() {
    return Document.start;
  }

  public static string GetGoal() {
    return Document.goal;
  }

  public static string GetDirections() {
    return Document.directions;
  }

  public static IDictionary<string, (string, string)> GetPaths() {
    return Document.paths;
  }
}
