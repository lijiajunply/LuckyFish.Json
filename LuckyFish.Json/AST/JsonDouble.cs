using System.Globalization;

namespace LuckyFish.Json.AST;

public class JsonDouble : JsonValue
{
    private double Value { get; set; }

    public JsonDouble(double value)
    {
        JsonType = "Double";
        Value = value;
    }

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    public override object GetValue() => Value;
}