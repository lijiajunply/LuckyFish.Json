using System.Text;

namespace LuckyFish.Json.AST;

public class JsonObject : JsonValue
{
    private Dictionary<string,JsonValue> Values { get; set; }

    public JsonObject(Dictionary<string,JsonValue> jsonValues) => Values = jsonValues;

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder("{");
        foreach (var value in Values)
            builder.Append($"{value.Key} : {value.Value}\n");
        builder.Append("}");
        return builder.ToString();
    }
}