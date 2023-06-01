namespace LuckyFish.Json.AST;

public class JsonBool : JsonValue
{
    private bool Value { get; set; }

    public JsonBool(bool value)
    {
        JsonType = "Bool";
        Value = value;
    }

    public override string ToString() => Value.ToString();
    public override object? GetValue() => Value;
}