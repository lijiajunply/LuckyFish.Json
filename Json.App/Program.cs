using Json.App;

/*
var b = Interpreter.Use(File.ReadAllText("/home/luckyfish/RiderProjects/LuckyFish.Json/LuckyFish.Json/Ex/Ex.json"));
Console.WriteLine(b);

*/
//var _ = LuckyFish.Json.Json.DeSerialization<LangInfo>(File.ReadAllText("/home/luckyfish/RiderProjects/LuckyFish.Json/LuckyFish.Json/Ex/Ex.json"));
//_.GetType();
var a = LuckyFish.Json.Json.Serialization(new Test(){T = new Test2(){A = 32},I = 123,S = "3124"});
Console.WriteLine(a);