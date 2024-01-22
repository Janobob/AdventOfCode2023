// See https://aka.ms/new-console-template for more information

var content = File.ReadAllLines("input.txt");
var total = 0;

foreach (var line in content)
{
    var parsed = line.Split(":")[1].Split("|");
    var winningsNumbers = parsed[0].Trim().Split(" ").Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList();
    var numbers = parsed[1].Trim().Split(" ").Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList();

    total += (int)Math.Pow(2, winningsNumbers.Count(x => numbers.Contains(x)) - 1);
}

Console.WriteLine(total);