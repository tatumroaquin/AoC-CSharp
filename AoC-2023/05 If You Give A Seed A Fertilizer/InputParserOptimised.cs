public class InputParserOptimised {
  public static AlmanacOptimised ParserInput(string fileName) {
    IList<string> paragraphs  = GetParagraphs(fileName);
    IList<(long,long)> seeds         = GetSeeds(paragraphs[0]);
    var maps = new List<IList<(long,long,long)>>();

    for (int i = 1; i <= 7; i++) {
      maps.Add(GetMapInParagraph(paragraphs[i]));
    }

    return new AlmanacOptimised(
      seeds,
      maps
    );

  }

  private static IList<(long,long,long)> GetMapInParagraph(string paragraph) {
    var mapList = new List<(long,long,long)>();

    string[] lines = paragraph.Split('\n');
    for (int i = 1; i < lines.Length - 1; i++) {
      string line = lines[i];
      var lineMap = GetMapInLine(line);
      mapList.Add(lineMap);
    }

    mapList.Sort((a, b) => a.Item2.CompareTo(b.Item2));
    return mapList;
  }

  private static (long,long,long) GetMapInLine(string line) {
    string[] nums = line.Split(' ');

    long dst = long.Parse(nums[0]);
    long src = long.Parse(nums[1]);
    long range = long.Parse(nums[2]);

    return (dst, src, range);
  }

  private static IList<string> GetParagraphs(string fileName) {
    StreamReader r = new StreamReader(fileName);

    var paragraphs = new List<string>();
    string? line = "",
      paragraph = "";
    while ((line = r.ReadLine()) != null) {
      if (line == "") {
        paragraphs.Add(paragraph);
        paragraph = "";
      }
      else {
        paragraph += line + '\n';
      }
    }
    paragraphs.Add(paragraph);

    return paragraphs;
  }

  private static IList<(long,long)> GetSeeds(string line) {
    string[] words = line.Split(' ');
    int len = words.Length;
    var seeds = new List<(long,long)>();
    for (long i = 1; i < len - 1; i += 2) {
      long start = Convert.ToInt64(words[i]);
      long range = Convert.ToInt64(words[i+1]);
      seeds.Add((start, range));
    }
    return seeds;
  }

  private static void PrintParagraphs(IList<string> paragraphs) {
    foreach (string p in paragraphs) {
      string[] lines = p.Split('\n');
      for (int i = 0; i < lines.Length; i++) {
        string line = lines[i];
        Console.WriteLine(line);
      }
    }
  }

  private static void PrintMaps(string name, IList<IDictionary<string,long>> maps) {
    Console.WriteLine(name);
    for (int i = 0; i < maps.Count; i++) {
      var map = maps[i];
      foreach (var kvp in map) {
        Console.Write($"{kvp.Key}:{kvp.Value} ");
      }
      Console.WriteLine();
    }
  }
}
