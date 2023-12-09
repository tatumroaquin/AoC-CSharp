namespace AoC_2023.Day_04;

public class Part2 {
  public static int Solution(IList<Card> cards) {
    // total amount of cards in the stack
    int result = 0;
    IDictionary<int,int> cardMap = GenCardMap(cards);
    Console.WriteLine(string.Join(" ", cardMap));

    Queue<(int,int)> queue = new Queue<(int,int)>();
    // put all cards into the queue
    foreach(var kvp in cardMap) {
      queue.Enqueue((kvp.Key,kvp.Value));
    }

    // BFS (breadth first search)
    while (queue.Count != 0) {
      (int id,int matches) card = queue.Dequeue();
      for (int j = 0; j < card.matches; j++) {
        int nextId = card.id + j + 1;
        queue.Enqueue((nextId, cardMap[nextId]));
      }
      result++;
    }

    return result;
  }

  private static IDictionary<int,int> GenCardMap(IList<Card> cards) {
    // card number -> matches amount
    var cardMap = new Dictionary<int,int>();

    foreach (Card c in cards) {
      int matches = 0;
      foreach (int num in c.winningNums) {
        if (c.currentNums.Contains(num))
          matches++;
      }
      cardMap.Add(c.id, matches);
    }

    return cardMap;
  }
}
