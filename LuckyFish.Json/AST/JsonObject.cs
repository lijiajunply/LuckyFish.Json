using System.Text;
using System.Threading.Tasks.Dataflow;

namespace LuckyFish.Json.AST;

public class JsonObject : JsonValue
{
    private List<JsonDictionary> Values { get; set; }

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
    public object GetValue(string name)
    {
        object a = new object();
        foreach (var value in Values)
            if (value.GetName() == name)
                a = value.GetValue();
        if (a is JsonObject jsonObject)
        {
            
        }
        return a;
    }
    public object GetValue() => Values;
}