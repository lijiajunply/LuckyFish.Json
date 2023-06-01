namespace LuckyFish.Json.AST;

public class JsonInt : IJsonValue
{
    private int Value { get; set; }

    public JsonInt(int a) => Value = a;
    public override string ToString() => Value.ToString();
    public object? GetValue() => Value;
}