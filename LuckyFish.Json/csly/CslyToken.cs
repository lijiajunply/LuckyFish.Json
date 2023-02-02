using sly.lexer;

namespace LuckyFish.Json.csly;

public enum CslyToken
{
    [String] STRING = 1,
    [Double] DOUBLE = 2,
    [Int] INT    = 3,

    [Lexeme(GenericToken.KeyWord,"true","false")]
    BOOL = 4,
    [Lexeme(GenericToken.SugarToken,"{")]    ACCG  = 5,
    [Lexeme(GenericToken.SugarToken,"}")]    ACCD  = 6,
    [Lexeme(GenericToken.SugarToken,"[")]    CROG  = 7,
    [Lexeme(GenericToken.SugarToken,"]")]    CROD  = 8,
    [Lexeme(GenericToken.SugarToken,",")]    COMMA = 9,
    [Lexeme(GenericToken.SugarToken,":")]    COLON = 10,
    [Lexeme(GenericToken.KeyWord,   "null")] NULL  = 11
}