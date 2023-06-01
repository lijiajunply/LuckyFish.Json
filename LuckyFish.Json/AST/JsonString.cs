namespace LuckyFish.Json.AST;

public class JsonString : IJsonValue
{
    private string Value { get; set; }

    public JsonString(string a) => Value = a;
    public override string ToString() => Value;
    public object GetValue() => Value;
}