using LuckyFish.Json.AST;
using Newtonsoft.Json.Linq;
using sly.lexer;
using sly.parser.generator;

namespace LuckyFish.Json.Csly;

public class CslyParser
{
    [Production("root:object")]
    public IJsonValue Root(IJsonValue a) => a;
    [Production("object:ACCG[d]  ACCD[d]")]
    public IJsonValue ObjectNull() => new JsonObject(new List<JsonDictionary>());

    [Production("object:ACCG[d] member ACCD[d]")]
    public IJsonValue Object(JsonObject a) => a;
    
    [Production("member: prop and*")]
    public IJsonValue Members(JsonDictionary head,List<IJsonValue> tail)
    {
        if (tail != null)
            tail.Insert(0,head);
        else
            tail = new List<IJsonValue>() { head };
        return new JsonObject(tail.OfType<JsonDictionary>().ToList());
    }

    [Production("and : COMMA[d] prop")]
    public IJsonValue property(JsonDictionary property) => property;

    [Production("prop: STRING COLON[d] value")]
    public IJsonValue property(Token<CslyToken> key,IJsonValue value) 
        => new JsonDictionary(key.Value.Split(@"""")[1],value);

    [Production("value: STRING")]
    public IJsonValue String(Token<CslyToken> s) 
        => new JsonString(s.Value.Split(@"""")[1]);

    [Production("value:INT")]
    public IJsonValue Int(Token<CslyToken> i) => new JsonInt(i.IntValue);

    [Production("value:DOUBLE")]
    public IJsonValue Double(Token<CslyToken> d) => new JsonDouble(double.Parse(d.Value));

    [Production("value:object")]
    public IJsonValue ObjectValue(JsonObject o) => o;

    [Production("value:BOOL")]
    public IJsonValue Bool(Token<CslyToken> b) => new JsonBool(Boolean.Parse(b.Value));

    [Production("value:NULL[d]")]
    public IJsonValue Null() => new JsonNull();

    [Production("value:list")]
    public IJsonValue List(JsonList a) => a;

    [Production("list: CROG[d] CROD[d]")]
    public IJsonValue ListNull() => new JsonList(new List<IJsonValue>());

    [Production("list: CROG[d] listElements CROD[d]")]
    public IJsonValue ListValue(JsonList l) => l;


    [Production("listElements: value addvalue*")]
    public IJsonValue ListElements(IJsonValue head,List<IJsonValue> tail)
    {
        var a = new List<IJsonValue>();
        a.Add(head);
        tail.ForEach(x => a.Add(x));
        return new JsonList(a);
    }

    [Production("addvalue: COMMA[d] value")]
    public IJsonValue ListElementsOne(IJsonValue value) => value;
}