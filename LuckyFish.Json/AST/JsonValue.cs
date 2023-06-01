namespace LuckyFish.Json.AST;

public class JsonValue : IJsonValue
{
    public object? Value { get; set; }
    public string? JsonType { get; set; }
    public virtual object? GetValue() => Value;
}