namespace LuckyFish.Json.AST;

public class JsonNull : JsonValue
{
    private object Value => null;

    public override string ToString() => "null";
    public          object GetValue() => null;
}