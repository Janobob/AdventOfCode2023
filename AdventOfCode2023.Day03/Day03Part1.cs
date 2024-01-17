namespace AdventOfCode2023.Day03;

public class Day03Part1
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
        
        var parts = new List<int>();
        
        for (var i = 0; i < rows; i++)
        {
        	for (var j = 0; j < cols; j++)
        	{
        		if (IsNumber(engine[i, j], out var parse))
        		{
        			var part = parse;
        			var found = HasSymbolAround(i, j);
        			
        			while(j + 1 < cols && IsNumber(engine[i, j + 1], out parse))
        			{
        				part = part * 10 + parse;
        				found = found || HasSymbolAround(i, j + 1);
        				j++;
        			}
        
        			if (found)
        			{
        				parts.Add(part);
        			}
        		}
        	}
        }
        
        Console.WriteLine(parts.Sum());
        
        bool IsNumber(char c, out int parse)
        {
        	return int.TryParse(c.ToString(), out parse);
        }
        
        bool IsSymbol(char c)
        {
        	return c != '.' && !IsNumber(c, out var p);
        }
        
        bool HasSymbolAround(int i, int j)
        {
        	var upperRow = i > 0 && 
        	               ((j - 1 >= 0 && IsSymbol(engine[i - 1, j - 1])) || // top left
        	                IsSymbol(engine[i - 1, j]) || // top mid
        	                (j + 1 < cols && IsSymbol(engine[i - 1, j + 1]))); // top right
        	var middleRow = 
        					(j - 1 >= 0 && IsSymbol(engine[i, j - 1])) || // left
        					IsSymbol(engine[i, j]) || // mid
        	                (j + 1 < cols && IsSymbol(engine[i, j + 1])); // right;
        	var bottomRow = i + 1 < rows && 
        	                ((j - 1 >= 0 && IsSymbol(engine[i + 1, j - 1])) || // bottom left
        	                IsSymbol(engine[i + 1, j]) || // bottom mid
        	                (j + 1 < cols && IsSymbol(engine[i + 1, j + 1]))); // bottom right;
        
        	return upperRow || middleRow || bottomRow;
        }
	}
}