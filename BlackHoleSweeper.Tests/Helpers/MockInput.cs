using BlackHolesSweeper.ConsoleWrapper;

namespace BlackHoleSweeper.Tests.Helpers;

public class MockInput : IInput
{
    private readonly Queue<string> _testResponses = new();

    public MockInput(IEnumerable<string> testResponse)
    {
        foreach (var response in testResponse) _testResponses.Enqueue(response);
    }

    public string Ask(string question)
    {
        var response = _testResponses.Dequeue();
        return response;
    }
}
