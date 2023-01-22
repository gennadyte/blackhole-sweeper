namespace BlackHolesSweeper.ConsoleWrapper;

public class ConsoleInput : IInput
{
    public string Ask(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }
}