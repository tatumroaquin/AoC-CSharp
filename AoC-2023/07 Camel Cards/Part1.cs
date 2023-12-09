namespace AoC_2023.Day_07;

public class Part1 {
  public static int Solution(IList<(string,int)> cards) {
    int total = 0;
    var hands = new Dictionary<int,List<(string,int)>>();

    for (int i = 1; i <= 7; i++) {
      hands[i] = new List<(string,int)>();
    }

    foreach (var (hand, bid) in cards) {
      int handRank = IdentifyHand(hand);
      // int handValue = 0;
      // foreach (char c in hand) {
      //   handValue += GetCardVal(c);
      // }
      hands[handRank].Add((hand, bid));
    }

    // sort all hand groups in ascending order
    foreach (var kvp in hands) {
      kvp.Value.Sort((a, b) => {
        for (int i = 0; i < 5; i++) {
          int val1 = GetCardVal(a.Item1[i]);
          int val2 = GetCardVal(b.Item1[i]);
          if (val1 == val2) continue;
          if (val1 < val2) return -1;
          if (val1 > val2) return 1;
        }
        return 0;
      });
    }

    // hand hierarchy order from lowest to highest
    int[] handOrder = new int[] {1,2,3,4,5,6,7};

    int rank = 1;
    foreach (int handType in handOrder) {
      foreach (var (hand, bid) in hands[handType]) {
        Console.WriteLine($"H:{hand} B:{bid}, R:{rank}");
        total += rank * bid;
        rank += 1;
      }
    }

    return total;
  }

  private static int IdentifyHand(string cards) {
    var hands = new Dictionary<int,int> {
      {5, 7}, // five of kind
      {14, 6}, // four of kind
      {23, 5}, // full house
      {113, 4}, // three of kind
      {122, 3}, // two pair
      {1112, 2}, // one pair
      {11111, 1}, // high card
    };

    var map = new Dictionary<char,int>();
    foreach (char c in cards) {
      map.TryGetValue(c, out int count);
      map[c] = count + 1;
    }

    int[] rawHand = map.Values.ToArray();
    Array.Sort(rawHand);

    int hand = 0;
    foreach (int value in rawHand) {
      hand *= 10;
      hand += value;
    }
    return hands.ContainsKey(hand) ? hands[hand] : -1;
  }

  private static int GetCardVal(char card) {
    var map = new Dictionary<char,int> {
      {'2',1},
      {'3',2},
      {'4',3},
      {'5',4},
      {'6',5},
      {'7',6},
      {'8',7},
      {'9',8},
      {'T',9},
      {'J',10},
      {'Q',11},
      {'K',12},
      {'A',13},
    };

    return map[card];
  }
}
