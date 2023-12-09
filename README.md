# C# Advent of Code Solutions

## Adding New Years
```bash
dotnet new console --name "AoC-<YEAR>"
dotnet sln AdventOfCode.sln add AoC-<Year>
```

## Adding Solutions
```bash
mkdir -p AoC-<Year>/00 Problem Title/Data
touch AoC-<YEAR>/00 Problem Title/InputParser.cs
touch AoC-<YEAR>/00 Problem Title/Part1.cs
touch AoC-<YEAR>/00 Problem Title/Part2.cs
touch AoC-<YEAR>/00 Problem Title/00 Test.cs
echo "namespace AoC_[YEAR].Day_[DAY];" > AoC-<YEAR>/00 Problem Title/*.cs
```

## Getting Problem Text
* Navigate to <https://adventofcode.com/[year]/day/[day]>
```bash
# alternatively curl out the page yourself
curl -sL https://adventofcode.com/<year>/day/<day>
```

## Getting Puzzle Data
* Navigate to <https://adventofcode.com/[year]/day/[day]/input>
* Paste or download the output to the following paths
> AoC-<Year>/00 Problem Title/Data/ExampleInput.in  
> AoC-<Year>/00 Problem Title/Data/PuzzleInput.in

## Testing Solutions
* The `00 Test.cs` file inside each day must contain the following boilerplate
```cs
// 00 Test.cs
public class AoC_[YEAR]_Day_[DAY] {
  public static void Test() {
    /* ... */
  }
}
```
* In `AoC_<YEAR>/Program.cs` call the `Test()` method of each problem you're testing:
```cs
// AoC_<YEAR>/Program.cs
using AoC_[YEAR].Day_[DAY];
public static void Main() {
  AoC_[YEAR]_Day_01.Test();
  AoC_[YEAR]_Day_02.Test();
  AoC_[YEAR]_Day_03.Test();
  /* ... */
}
```
