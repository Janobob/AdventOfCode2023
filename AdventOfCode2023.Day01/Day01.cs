using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace AdventOfCode2023.Day01;

public class Day01
{
	public static void Main(string[] args)
	{
		var content = File.ReadAllLines("input.txt");
		var sum = content.Sum(line => FindFirstAndLastDigit(line));

		Console.WriteLine(sum);
	}

	private static int FindFirstAndLastDigit(string input)
	{
		var numerics = new Dictionary<string, int>()
		{
			{ "1", 1 },
			{ "2", 2 },
			{ "3", 3 },
			{ "4", 4 },
			{ "5", 5 },
			{ "6", 6 },
			{ "7", 7 },
			{ "8", 8 },
			{ "9", 9 },
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 },
			{ "four", 4 },
			{ "five", 5 },
			{ "six", 6 },
			{ "seven", 7 },
			{ "eight", 8 },			
			{ "nine", 9 },
		};
		
		var firstDigit = 0;
		var lastDigit = 0;
		
		for (var i = 0; i < input.Length; i++)
		{
			var segment = input[i..];
			var result = numerics.FirstOrDefault(numeric => segment!.StartsWith(numeric.Key));
			if (result.Key == null) continue;
			firstDigit = result.Value;
			break;
		}
		
		for (var i = input.Length - 1; i >= 0; i--)
		{
			var segment = input[i..];
			var result = numerics.FirstOrDefault(numeric => segment!.StartsWith(numeric.Key));
			if (result.Key == null) continue;
			lastDigit = result.Value;
			break;
		}
		
		return firstDigit * 10 + lastDigit;
	}
}