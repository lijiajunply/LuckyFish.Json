using System.Collections;
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
    public object GetValue(Type type)
    {
        var    a        = Activator.CreateInstance(type);
        string listtype = type.ToString().Split("[")[^1][..^1];
        var    aaa      = type.GetProperties();
        if (a is IList list)
        {
            Type[] genericArgTypes = type.GetGenericArguments();
            Type   item            = genericArgTypes[0];
            foreach (var value in Values)
            {
                if (value is JsonObject o)
                    list.Add(o.GetValue(item));
                else
                    list.Add(value.GetValue());
            }
        }
        return a;
    }
}