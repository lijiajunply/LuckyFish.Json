using LuckyFish.Json.AST;
using Newtonsoft.Json.Linq;
using sly.lexer;
using sly.parser.generator;

namespace LuckyFish.Json.csly;

public class CslyParser
{
    [Production("root:object")]
    public JsonValue Root(JsonValue a) => a;
    [Production("object:ACCG[d]  ACCD[d]")]
    public JsonValue ObjectNull() => new JsonObject(new List<JsonDictionary>());

    [Production("object:ACCG[d] member ACCD[d]")]
    public JsonValue Object(JsonObject a) => a;
    
    [Production("member: prop and*")]
    public JsonValue Members(JsonDictionary head,List<JsonValue> tail)
    {
        if (tail != null)
        {
            tail.Insert(0,head);
        }
        else
        {
            tail = new List<JsonValue>() { head };
        }
        return new JsonObject(tail.OfType<JsonDictionary>().ToList());
    }

    [Production("and : COMMA[d] prop")]
    public JsonValue property(JsonDictionary property) => property;

    [Production("prop: STRING COLON[d] value")]
    public JsonValue property(Token<CslyToken> key,JsonValue value) => new JsonDictionary(key.Value.Split(@"""")[1],value);

    [Production("value: STRING")]
    public JsonValue String(Token<CslyToken> s) => new JsonString(s.Value.Split(@"""")[1]);

    [Production("value:INT")]
    public JsonValue Int(Token<CslyToken> i) => new JsonInt(i.IntValue);

    [Production("value:DOUBLE")]
    public JsonValue Double(Token<CslyToken> d) => new JsonDouble(double.Parse(d.Value));

    [Production("value:object")]
    public JsonValue ObjectValue(JsonObject o) => o;

    [Production("value:BOOL")]
    public JsonValue Bool(Token<CslyToken> b) => new JsonBool(Boolean.Parse(b.Value));

    [Production("value:NULL[d]")]
    public JsonValue Null() => new JsonNull();

    [Production("value:list")]
    public JsonValue List(JsonList a) => a;

    [Production("list: CROG[d] CROD[d]")]
    public JsonValue ListNull() => new JsonList(new List<JsonValue>());

    [Production("list: CROG[d] listElements CROD[d]")]
    public JsonValue ListValue(JsonList l) => l;


    [Production("listElements: value addvalue*")]
    public JsonValue ListElements(JsonValue head,List<JsonValue> tail)
    {
        var a = new List<JsonValue>();
        a.Add(head);
        tail.ForEach(x => a.Add(x));
        return new JsonList(a);
    }

    [Production("addvalue: COMMA[d] value")]
    public JsonValue ListElementsOne(JsonValue value) => value;
}