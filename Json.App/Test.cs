namespace Json.App;

public class Test
{
    public int         I { get; set; }
    public string      S { get; set; }
    public Test2       T { get; set; }
    public List<Test2> A { get; set; }
}

public class Test2
{
    public int A { get; set; }
}
public class LibInfo
{
    public string LibName { get; set; }
    public double Var     { get; set; }
    public bool   IsDir   { get; set; }
}
public class LangInfo
{
    public string ImportPath { get; set; }

    public LibInfo Ex { get; set; }
    
    public List<LibInfo> LibInfos { get; set; }

    public string Ver { get; set; }

    public string Url { get; set; }
}