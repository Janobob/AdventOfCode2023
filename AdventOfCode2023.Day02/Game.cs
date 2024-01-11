namespace AdventOfCode2023.Day02;

public class Game
{
    public int Id { get; set; }
    
    public int Blues { get; set; }
    
    public int Greens { get; set; }
    
    public int Reds { get; set; }

    public int Power => Reds * Blues * Greens;
    
    public void AddIfHigher(string color, int count)
    {
        switch (color)
        {
            case "blue" when count > Blues:
                Blues = count;
                return;
            case "green" when count > Greens:
                Greens = count;
                return;
            case "red" when count > Reds:
                Reds = count;
                return;
        }
    }

    public bool IsValid(int reds, int greens, int blues)
    {
        return reds >= Reds && greens >= Greens && blues >= Blues;
    }
}