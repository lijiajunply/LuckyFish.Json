namespace LuckyFish.Json.AST;

public class JsonInt : JsonValue
{
    private int Num { get; set; }

    public JsonInt(int    a) => Num = a;
    public override string ToString() => Num.ToString();
}