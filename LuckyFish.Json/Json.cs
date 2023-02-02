using LuckyFish.Json.csly;

namespace LuckyFish.Json;

public static class Json
{
    public static string Serialization(object obj)
    {
        var type = obj.GetType();
        var p = type.GetProperties();
        
        return "";
    }
    public static T DeSerialization<T>(string s)
    {
        var  a    = Interpreter.Use(s);
        Type type = typeof(T);
        type.InvokeMember()
    }
}