namespace LuckyFish.Json.AST;

public class JsonInt : JsonValue
{
    private int Value { get; set; }

    public JsonInt(int a)
    {
        Value = a;
        JsonType = "Int";
    }

    public override string ToString() => Value.ToString();
    public override object? GetValue() => Value;
}