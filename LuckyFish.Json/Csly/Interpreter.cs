using LuckyFish.Json.AST;
using sly.parser.generator;

namespace LuckyFish.Json.Csly;

public static class Interpreter
{
    public static IJsonValue? Use(string code)
    {
        var parser = new ParserBuilder<CslyToken, IJsonValue>();
        var oldParser = new CslyParser();
        var parserBuilder = parser.BuildParser(oldParser,
            ParserType.EBNF_LL_RECURSIVE_DESCENT, "root");
        var buildResult = parserBuilder.Result;
        var result = buildResult.Parse(code).Result;
        return result;
    }
}