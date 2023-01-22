using System.Text.RegularExpressions;
namespace BlackHolesSweeper.Helpers;

public static class InputValidator
{
    private const string LocationInputPattern = "^[0-9]*,[0-9]*$";
    
    public static bool IsValidBoardSizeInput(string input)
    {
        if (int.TryParse(input, out var result))
        {
            return result is > 1 and <= 40;
        }

        return false;
    }

    public static bool IsValidLocationInput(string input)
    {
            
        return Regex.IsMatch(input, LocationInputPattern);
    }
}