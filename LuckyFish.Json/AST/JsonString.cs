namespace LuckyFish.Json.AST;

public class JsonString : JsonValue
{
    private string Value { get; set; }

    public JsonString(string a) => Value = a;
    public override string ToString() => Value;
}