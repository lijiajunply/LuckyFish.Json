using LuckyFish.Json.AST;
using sly.parser.generator;

namespace LuckyFish.Json.csly;

public class Interpreter
{
    public static JsonValue Use(string code)
    {
        var Parser    = new ParserBuilder<CslyToken,JsonValue>();
        var oldParser = new CslyParser();
        var parserBuilder = Parser.BuildParser(oldParser,
                                               ParserType.EBNF_LL_RECURSIVE_DESCENT,"root");
        var buildResult = parserBuilder.Result;
        
        var result = buildResult.Parse(code).Result;
        return result;
    }
}