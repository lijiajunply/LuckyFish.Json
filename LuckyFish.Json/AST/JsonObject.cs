using System.Text;
using System.Threading.Tasks.Dataflow;

namespace LuckyFish.Json.AST;

public class JsonObject : IJsonValue
{
    public List<JsonDictionary> Values { get; set; }

    public JsonObject(List<JsonDictionary> jsonValues) => Values = jsonValues;

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder("{\n");
        for (int i = 0; i < Values.Count; i++)
        {
            builder.Append(Values[i] + (i == Values.Count -1 ?"":",\n"));
        }
        builder.Append("\n}");
        return builder.ToString();
    }
    public object? GetValue(string name,Type type)
    {
        var b = Values.FirstOrDefault(x => x.Key == name).Get().Value;
        if (b is JsonObject jsonObject)
            return jsonObject.GetValue(type);
        if (b is JsonList list)
            return list.GetValue(type);
        return b.GetValue();
    }
    public object GetValue(Type type)
    {
        var a = Activator.CreateInstance(type);
        var p = type.GetProperties();
        foreach (var info in p)
            info.SetValue(a,GetValue(info.Name,info.PropertyType));
        var f = type.GetFields();
        foreach (var info in f)
            info.SetValue(a,GetValue(info.Name,info.FieldType));
        return a;
    }

    public string? JsonType { get; set; } = "Object";
}