namespace BlackHolesSweeper.ConsoleWrapper;

public class ConsoleOutput : IOutput
{
    public void Write(string message) =>
        Console.WriteLine(message);
}