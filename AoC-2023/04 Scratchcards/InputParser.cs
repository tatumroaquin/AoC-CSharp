namespace AoC_2023.Day_04;

public class InputParser {
  public static IList<Card> ParseInput(string fileName) {
    StreamReader r = new StreamReader(fileName);

    var cards = new List<Card>();
    string? line;
    while ((line = r.ReadLine()) != null) {
      int id = GetCardId(line);
      IList<int> winningNums = GetWinningNumbers(line);
      IList<int> currentNums = GetCurrentNumbers(line);

      Card card = new Card(id, winningNums.ToArray(), currentNums.ToArray());
      cards.Add(card);
    }

    return cards;
  }

  private static int GetCardId(string line) {
    int len = line.Length;
    int id = 0;

    // skip spaces
    for (int i = 4; i < len; i++) {
      if (line[i] == ' ') continue;
      if (line[i] == ':') break;
      id *= 10;
      id += int.Parse(line[i].ToString());
    }

    return id;
  }

  private static IList<int> GetWinningNumbers(string line) {
    var res = new List<int>();
    int len = line.Length;

    int i = 0;
    while (i < len && line[i] != ':') i++;
    i++;
    while (i < len && line[i] == ' ') i++;

    // start at first number after colon at index 10
    // iterate only before the pipe symbol for winning numbers
    int num = 0;
    for (; line[i] != '|'; i++) {
      // if we reach a space add num to results and reset num to zero
      if (line[i] == ' ') {
        if (num != 0) {
          res.Add(num);
          num = 0;
        }
        continue; // skip until line[i] is no longer a space
      }
      // if the current char is a digit at it the num variable
      if (char.IsDigit(line[i])) {
        num *= 10;
        num += int.Parse(line[i].ToString());
      }
    }

    return res;
  }

  private static IList<int> GetCurrentNumbers(string line) {
    var res = new List<int>();
    line = line + ' ';
    int len = line.Length;
    int num = 0;

    int i = 1;
    while (i < len && line[i-1] != '|') i++;
    while (i < len && line[i] == ' ') i++;

    // start at first number after the pipe symbol for card numbers
    for (; i < len; i++) {
      // if we reach a space add num to results and reset num to zero
      if (line[i] == ' ' && num != 0) {
        res.Add(num);
        num = 0;
        continue;
      }
      // if the current char is a digit at it the num variable
      if (char.IsDigit(line[i]) || i == len) {
        num *= 10;
        num += int.Parse(line[i].ToString());
      }
    }

    return res;
  }
}
