using System.Text;

namespace LuckyFish.Json.AST;

public class JsonList : JsonValue
{
    private List<JsonValue> Values { get; set; }

    public JsonList(List<JsonValue> values) => Values = values;
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder("[");
        for (int i = 0; i < Values.Count; i++)
            builder.Append(Values[i] + (i == Values.Count - 1 ? "" : ","));
        builder.Append("]");
        return builder.ToString();
    }
    public object GetValue()
    {
        List<object> a = new List<object>();
        Values.ForEach(x => a.Add(x.GetValue()));
        return a;
    }
}