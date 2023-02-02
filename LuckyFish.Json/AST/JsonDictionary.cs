namespace LuckyFish.Json.AST;

public class JsonDictionary : JsonValue
{
    public string    Key   { get; set; }
    private JsonValue Value { get; set; }

    public JsonDictionary(string key,JsonValue value)
    {
        Key   = key;
        Value = value;
    }
    public          KeyValuePair<string,JsonValue> Get()      => new KeyValuePair<string,JsonValue>(Key,Value);
    public override string                         ToString() => @""""+Key+@""" : "+Value;
    

    public object GetValue() => Value.GetValue();
}