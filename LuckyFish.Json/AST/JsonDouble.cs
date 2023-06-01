using System.Globalization;

namespace LuckyFish.Json.AST;

public class JsonDouble : IJsonValue
{
    private double Value { get; set; }

    public JsonDouble(double value) => Value = value;
    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    public object GetValue() => Value;
}