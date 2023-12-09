namespace AoC_2023.Day_06;

public class Part2 {
  public static ulong Solution((ulong,ulong) race) {
    ulong ans = 0;

    (ulong time,ulong dist) = race;

    for (ulong i = 1; i <= time; i++) {
      ulong travel = i * (time-i);
      if (travel > dist) ans++;
    }

    return ans;
  }
}
