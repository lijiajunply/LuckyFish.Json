namespace LuckyFish.Json.AST;

public class JsonNull : JsonValue
{
    private object Value => null;

    public JsonNull()
    {
        JsonType = "Null";
    }
    public override string ToString() => "null";
    public override object? GetValue() => null;
}