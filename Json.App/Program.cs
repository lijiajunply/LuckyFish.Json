using Json.App;

/*
var b = Interpreter.Use(File.ReadAllText("/home/luckyfish/RiderProjects/LuckyFish.Json/LuckyFish.Json/Ex/Ex.json"));
Console.WriteLine(b);
var a = new Test(){I = 1,S = "asdf",T = new Test2(){A = 1},A = new List<Test2>(){new Test2(){A = 1}}};
Console.WriteLine(LuckyFish.Json.Json.Serialization(a));
*/
var _ = LuckyFish.Json.Json.DeSerialization<LangInfo>(File.ReadAllText("/home/luckyfish/RiderProjects/LuckyFish.Json/LuckyFish.Json/Ex/Ex.json"));
_.GetType();