using AdventOfCode2023.Day02;

var content = File.ReadAllLines("input.txt");
var games = new List<Game>();

foreach (var line in content)
{
    var splitted = line.Split(":");
    var gameId = Convert.ToInt32(splitted[0].Remove(0, 4));
    var game = new Game
    {
        Id = gameId
    };

    foreach (var takeOut in splitted[1].Split(";"))
    {
        foreach (var balls in takeOut.Split(","))
        {
            var splittedBalls = balls.Trim().Split(" ");
            var count = Convert.ToInt32(splittedBalls[0]);
            var color = splittedBalls[1];

            game.AddIfHigher(color, count);
        }
    }
    
    games.Add(game);
}

const int reds = 12;
const int greens = 13;
const int blues = 14;
var validGames = games.Where(g => g.IsValid(reds, greens, blues));

Console.WriteLine(validGames.Sum(g => g.Id));
Console.WriteLine(games.Sum(g => g.Power));