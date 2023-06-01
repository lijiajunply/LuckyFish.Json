using System.Collections;
using System.Reflection;
using LuckyFish.Json.AST;
using LuckyFish.Json.Csly;

namespace LuckyFish.Json;

public static class Json
{
    public static string Serialization(object obj)
    {
        var type = obj.GetType();
        var p = type.GetProperties();
        var f = type.GetFields();

        List<JsonDictionary> a = p.Select
            (info => GetValue(info.Name, info.GetValue(obj)!)).ToList();
        a.AddRange(f.Select(info => GetValue
            (info.Name, info.GetValue(obj)!)));

        return new JsonObject(a).ToString();
    }

    public static IJsonValue? DeSerialization(string jsonString) => Interpreter.Use(jsonString);

    public static T DeSerialization<T>(string jsonString) where T : new()
    {
        T a = new T();
        var b = (JsonObject)Interpreter.Use(jsonString)!;
        var type = a.GetType();
        var p = type.GetProperties();
        foreach (var info in p)
            info.SetValue(a, b.GetValue(info.Name, info.PropertyType));
        var f = type.GetFields();
        foreach (var info in f)
            info.SetValue(a, b.GetValue(info.Name, info.FieldType));
        return a;
    }

    #region Get

    private static JsonDictionary GetValue(string name, object obj) => new(name, Get(obj));

    private static IJsonValue Get(object obj)
    {
        switch (obj)
        {
            case int i:
                return new JsonInt(i);
            case double d:
                return new JsonDouble(d);
            case string s:
                return new JsonString(s);
            case bool b:
                return new JsonBool(b);
            case IList list:
            {
                List<IJsonValue> values = new List<IJsonValue>();
                foreach (var variable in list)
                    values.Add(Get(variable));

                return new JsonList(values);
            }
            case not null:
            {
                var type = obj.GetType();
                var p = type.GetProperties();
                var f = type.GetFields();

                List<JsonDictionary> a = p.Select(info => GetValue(info.Name, info.GetValue(obj)!)).ToList();
                a.AddRange(f.Select(info => GetValue(info.Name, info.GetValue(obj)!)));
                return new JsonObject(a);
            }
            default:
                return new JsonNull();
        }
    }

    #endregion
}