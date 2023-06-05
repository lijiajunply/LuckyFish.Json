using System.Collections.ObjectModel;
using System.Linq;
using LuckyFish.Json.AST;

namespace VisualJson.Models;

public class JsonModel
{
    public string? ValueType { get; set; }
    public ObservableCollection<JsonModel>? Children { get; set; }
    public string? Name { get; set; }
    public IJsonValue? Value { get; set; }
    public bool IsHasChildren { get; set; }

    public JsonModel(IJsonValue? value)
    {
        if(value == null)return;
        IsHasChildren = true;
        Value = value;
        ValueType = value.JsonType;
        if (value is JsonDictionary dictionary)
        {
            Name = dictionary.Key;
            if (dictionary.Value is JsonValue jsonValue)
            {
                IsHasChildren = false;
                Value = jsonValue;
                return;
            }
            Children = new ObservableCollection<JsonModel> { new (dictionary.Value) };
            return;
        }
        if (value is JsonObject obj)
        {
            Name = "Obj";
            Children = new ObservableCollection<JsonModel>(
                obj.Values.Select(x => new JsonModel(x)));
            return;
        }

        if (value is JsonList list)
        {
            Name = "List";
            Children = new ObservableCollection<JsonModel>(
                list.Values.Select(x => new JsonModel(x)));
            return;
        }

        Name = ToName(value);
        IsHasChildren = false;
    }

    private string? ToName(IJsonValue value)
    {
        var v = value.GetValue();
        if (v == null) return "null";
        return v.ToString();
    }
}