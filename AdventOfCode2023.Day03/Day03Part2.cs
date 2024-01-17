namespace AdventOfCode2023.Day03;

public class Day03Part2
{
	public static void Run()
	{
		var content = File.ReadAllLines("input.txt");
		var engine = new char[content.Length, content[0].Length];
		var rows = content.Length;
		var cols = content[0].Length;

		// fill engine array
		for (var i = 0; i < rows; i++)
		{
			var line = content[i];
			for (var j = 0; j < cols; j++)
			{
				engine[i, j] = line[j];
			}
		}
		
		var gears = new Dictionary<Point, List<int>>();
		
		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < cols; j++)
			{
				if (IsNumber(engine[i, j], out var parse))
				{
					var part = parse;
					var found = GetGear(i, j);
        			
					while(j + 1 < cols && IsNumber(engine[i, j + 1], out parse))
					{
						part = part * 10 + parse;

						found ??= GetGear(i, j + 1);
						
						j++;
					}
        
					if (found.HasValue)
					{
						var gear = found.Value;
						if (!gears.ContainsKey(gear))
						{
							gears.Add(gear, new List<int>());
						}
						gears[gear].Add(part);
					}
				}
			}
		}
		
		Console.WriteLine(gears.Where(g => g.Value.Count >= 2).Sum(g => g.Value.Aggregate(1, (x,y) => x * y)));
		
		bool IsNumber(char c, out int parse)
		{
			return int.TryParse(c.ToString(), out parse);
		}

		bool IsGear(char c)
		{
			return c == '*';
		}

		Point? GetGear(int i, int j)
		{
			if (i > 0)
			{
				if (j - 1 >= 0 && IsGear(engine[i - 1, j - 1]))
				{
					return new Point(i - 1, j - 1);
				}
				
				if (IsGear(engine[i - 1, j]))
				{
					return new Point(i - 1, j);
				}
				
				if (j + 1 < cols && IsGear(engine[i - 1, j + 1]))
				{
					return new Point(i - 1, j + 1);
				}
			}

			if (j - 1 >= 0 && IsGear(engine[i, j - 1]))
			{
				return new Point(i, j - 1);
			}
			
			if (IsGear(engine[i, j]))
			{
				return new Point(i, j);
			}
			
			if (j + 1 < cols && IsGear(engine[i, j + 1]))
			{
				return new Point(i, j + 1);
			}

			if (i + 1 < rows)
			{
				if (j - 1 >= 0 && IsGear(engine[i + 1, j - 1]))
				{
					return new Point(i + 1, j - 1);
				}
			
				if (IsGear(engine[i + 1, j]))
				{
					return new Point(i + 1, j);
				}
			
				if (j + 1 < cols && IsGear(engine[i + 1, j + 1]))
				{
					return new Point(i + 1, j + 1);
				}
			}
			
			return null;
		}
	}
	
	struct Point
	{
		public int x;
		public int y;
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}