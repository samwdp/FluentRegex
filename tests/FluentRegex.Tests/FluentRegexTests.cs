using Xunit;
using FluentAssertions;
namespace FluentRegex.Tests;

public class FluentRegexTests
{
    [Fact]
    public void FluentRegex_Digit_Match_Output()
    {
        var a = FluentRegex.Start().MatchCharacter().AsString();

        a.Should().NotBeNull();
        a.Should().Be(@"/\w");
    }

    [Fact]
    public void FluentRegex_NoneDigit_Match_Output()
    {
        var a = FluentRegex.Start().MatchNoneCharacter().AsString();

        a.Should().NotBeNull();
        a.Should().Be(@"/\W");
    }

    [Fact]
    public void FluentRegex_MatchWord()
    {
        var a = FluentRegex.Start().MatchCharacterSet("test").AsString();
        a.Should().NotBeNull();
        a.Should().Be(@"/[test]");
    }

    [Fact]
    public void FluentRegex_AddSubsequence()
    {
        var a = FluentRegex.Start().AddSubexpression(e => e.MatchCharacterSet("test")).EndSubexpression().AsString();
        a.Should().NotBeNull();
        a.Should().Be(@"/([test])");
    }

    [Fact]
    public void FluentRegex_MatchFromBeginning_Basic()
    {
        var result = FluentRegex.Start().MatchFromBeginningOfInput("basic").AsString();
        result.Should().Be(@"/^basic");
    }

    [Fact]
    public void FluentRegex_MatchFromBeginning_Advanced()
    {
        var result = FluentRegex.Start().MatchFromBeginningOfInput(a =>
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
