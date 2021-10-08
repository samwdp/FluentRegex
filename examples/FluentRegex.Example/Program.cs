// outputs /((([abc])))
string a = FluentRegex.FluentRegex.Start()
    .AddSubexpression(s =>
    {
        return s.AddSubexpression(b =>
        {
            return b.AddSubexpression(c => c.MatchCharacterSet("abc"))
            .EndSubexpression();
        }).EndSubexpression();
    })
    .EndSubexpression()
    .AsString();

var result = FluentRegex.FluentRegex.Start().MatchFromBeginningOfInput(a =>
{
    return a.MatchTab()
        .AddSubexpression(b =>
        {
            return b.AddSubexpression(c => c.MatchCharacterSet("A-Za-z").MatchWord("basic")).EndSubexpression();
        }).EndSubexpression();
}).AsString();

Console.WriteLine(result);
