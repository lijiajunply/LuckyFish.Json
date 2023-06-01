using System.Collections;
using System.Reflection;
using System.Text;

namespace LuckyFish.Json.AST;

public class JsonList : IJsonValue
{
    public List<IJsonValue> Values { get; set; }

    public JsonList(List<IJsonValue> values) => Values = values;

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder("[");
        for (int i = 0; i < Values.Count; i++)
            builder.Append(Values[i] + (i == Values.Count - 1 ? "" : ","));
        builder.Append(']');
        return builder.ToString();
    }

    public object? GetValue(Type type)
    {
        var a = Activator.CreateInstance(type, BindingFlags.CreateInstance);
        if (a is IList list)
        {
            Type? item = type;
            if (a is Array)
            {
                var b = item.ToString()[..^2];
                item = Activator.CreateInstanceFrom(type.Module.ToString(), b)?.Unwrap()?.GetType();
                int i = 0;
                foreach (var value in Values)
                {
                    if (value is JsonObject o)
                    {
                        if (item != null) 
                            list[i] = o.GetValue(item);
                    }
                    else
                        list[i] = value.GetValue();
                    i++;
                }
            }
            else
            {
                Type[] genericArgTypes = type.GetGenericArguments();
                item = genericArgTypes[0];
                foreach (var value in Values)
                {
                    if (value is JsonObject o)
                        list.Add(o.GetValue(item));
                    else
                        list.Add(value.GetValue());
                }
            }
        }

        return a;
    }

    public string? JsonType { get; set; } = "List";
}