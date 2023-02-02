namespace LuckyFish.Json.AST;

public class JsonDouble : JsonValue
{
    private double Value { get; set; }

    public JsonDouble(double value) => Value = value;
    public override string ToString() => Value.ToString();
    public          object GetValue() => Value;
}