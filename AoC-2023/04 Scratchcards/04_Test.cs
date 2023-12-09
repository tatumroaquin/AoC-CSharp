namespace AoC_2023.Day_04;

public class AoC_2023_Day_04 {
  public static void Test() {
    IList<Card> cards = InputParser.ParseInput("04 Scratchcards/Data/PuzzleInput.txt");
    foreach (Card c in cards) {
      Console.WriteLine(c.toString());
    }

    // long totalPoints = Part1.Solution(cards);
    // Console.WriteLine("total points: " + totalPoints);
    int totalCards = Part2.Solution(cards);
    Console.WriteLine("total cards " + totalCards);
  }
}
