namespace LuckyFish.Json.AST;

public class JsonDictionary : IJsonValue
{
    public string Key { get; set; }
    public IJsonValue Value { get; set; }

    public JsonDictionary(string key, IJsonValue value)
    {
        Key = key;
        Value = value;
    }

    public KeyValuePair<string, IJsonValue> Get() => new KeyValuePair<string, IJsonValue>(Key, Value);
    public override string ToString() => @"""" + Key + @""" : " + Value;


    public string? JsonType { get; set; } = "Dictionary";
    public object? GetValue() => Value.GetValue();
}