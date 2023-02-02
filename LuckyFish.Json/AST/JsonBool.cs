namespace LuckyFish.Json.AST;

public class JsonBool : JsonValue
{
    private bool Value { get; set; }

    public JsonBool(bool value) => Value = value;
    public override string ToString() => Value.ToString();
}