namespace LuckyFish.Json.AST;

public interface IJsonValue
{
    public string? JsonType { get; set; }
    public virtual object? GetValue() => new object();
}