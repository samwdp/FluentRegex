using Xunit;
using FluentAssertions;
using Fluent.Regex.Core;
namespace Fluent.Regex.Tests;

public class FluentRegexTests
{
    [Fact]
    public void Regex_Digit_Match_Output()
    {
        var a = Regex.Core.Regex.Start().MatchCharacter().AsString();

        a.Should().NotBeNull();
        a.Should().Be(@"/\w");
    }

    [Fact]
    public void Regex_NoneDigit_Match_Output()
    {
        var a = Regex.Core.Regex.Start().MatchNoneCharacter().AsString();

        a.Should().NotBeNull();
        a.Should().Be(@"/\W");
    }

    [Fact]
    public void Regex_MatchWord()
    {
        var a = Regex.Core.Regex.Start().MatchCharacterSet("test").AsString();
        a.Should().NotBeNull();
        a.Should().Be(@"/[test]");
    }

    [Fact]
    public void Regex_AddSubsequence()
    {
        var a = Regex.Core.Regex.Start().AddSubexpression(e => e.MatchCharacterSet("test")).EndSubexpression().AsString();
        a.Should().NotBeNull();
        a.Should().Be(@"/([test])");
    }

    [Fact]
    public void Regex_MatchFromBeginning_Basic()
    {
        var result = Regex.Core.Regex.Start().MatchFromBeginningOfInput("basic").AsString();
        result.Should().Be(@"/^basic");
    }

    [Fact]
    public void Regex_MatchFromBeginning_Advanced()
    {
        var result = Regex.Core.Regex.Start().MatchFromBeginningOfInput(a =>
        {
            return a.AddSubexpression(b =>
                {
                    return b.MatchTab()
                        .AddSubexpression(c => c.MatchCharacterSet("A-Za-z")
                                                    .MatchWord("basic"))
                        .EndSubexpression();
                })
                .EndSubexpression();
        })
        .AsString();
        result.Should().Be(@"/^(\t([A-Za-z]basic))");
    }
}
