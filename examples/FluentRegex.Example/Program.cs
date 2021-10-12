// outputs /((([abc])))
using Fluent.Regex.Core;

string a = Regex.Start()
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

var result = Regex.Start().MatchFromBeginningOfInput(a =>
{
    return a.AddSubexpression(b =>
        {
            return b.MatchTab()
                .AddSubexpression(c => c.MatchCharacterSet("A-Za-z").MatchWord("basic")).EndSubexpression();
        }).EndSubexpression();
}).AsString();

Console.WriteLine(result);
