using System.Collections;
using System.Reflection;
using LuckyFish.Json.AST;
using LuckyFish.Json.csly;

namespace LuckyFish.Json;

public static class Json
{
    public static string Serialization(object obj)
    {
        var type = obj.GetType();
        var p    = type.GetProperties();
        var f    = type.GetFields();

        List<JsonDictionary> a = new List<JsonDictionary>();
        foreach (var info in p)
            a.Add(GetValue(info.Name,info.GetValue(obj)!));
        foreach (var info in f)
            a.Add(GetValue(info.Name,info.GetValue(obj)!));

        return new JsonObject(a).ToString();
    }
    public static T DeSerialization<T>(string jsonString) where T : new()
    {
        T   a    = new T();
        var b    = (JsonObject)Interpreter.Use(jsonString);
        var type = a.GetType();
        var p    = type.GetProperties();
        foreach (var info in p)
            info.SetValue(a,b.GetValue(info.Name));
        var f    = type.GetFields();
        foreach (var info in f)
            info.SetValue(a,b.GetValue(info.Name));
        return a;
    }

    #region Set

    
    
    #endregion

    #region Get

    private static JsonDictionary GetValue(string name,object obj)
    {
        if (obj is int i)
        {
            return new JsonDictionary(name,new JsonInt(i));
        }
        if (obj is double d)
        {
            return new JsonDictionary(name,new JsonDouble(d));
        }
        if (obj is string s)
        {
            return new JsonDictionary(name,new JsonString(s));
        }
        if (obj is bool b)
        {
            return new JsonDictionary(name,new JsonBool(b));
        }
        if (obj is IList list)
        {
            List<JsonValue> values = new List<JsonValue>();
            foreach (var VARIABLE in list)
                values.Add(Get(VARIABLE));

            return new JsonDictionary(name,new JsonList(values));
        }
        if (obj is object)
        {
            var type = obj.GetType();
            var p    = type.GetProperties();
            var f    = type.GetFields();

            List<JsonDictionary> a = new List<JsonDictionary>();
            foreach (var info in p)
                a.Add(GetValue(info.Name,info.GetValue(obj)!));
            foreach (var info in f)
                a.Add(GetValue(info.Name,info.GetValue(obj)!));
            return new JsonDictionary(name,new JsonObject(a));
        }
        return new JsonDictionary(name,new JsonNull());
    }
    private static JsonValue Get(object obj)
    {
        if (obj is int i)
        {
            return new JsonInt(i);
        }
        if (obj is double d)
        {
            return new JsonDouble(d);
        }
        if (obj is string s)
        {
            return new JsonString(s);
        }
        if (obj is bool b)
        {
            return new JsonBool(b);
        }
        if (obj is IList list)
        {
            List<JsonValue> values = new List<JsonValue>();
            foreach (var variable in list)
                values.Add(Get(variable));

            return new JsonList(values);
        }
        if (obj is object)
        {
            var type = obj.GetType();
            var p    = type.GetProperties();
            var f    = type.GetFields();

            List<JsonDictionary> a = new List<JsonDictionary>();
            foreach (var info in p)
                a.Add(GetValue(info.Name,info.GetValue(obj)!));
            foreach (var info in f)
                a.Add(GetValue(info.Name,info.GetValue(obj)!));
            return new JsonObject(a);
        }
        return new JsonNull();
    }

    #endregion
}