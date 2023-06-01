namespace LuckyFish.Json.AST;

public class JsonNull : IJsonValue
{
    private object Value => null;

    public override string ToString() => "null";
    public object? GetValue() => null;
}