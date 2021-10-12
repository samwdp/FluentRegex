using System;
using System.Text;

namespace Fluent.Regex.Core
{
    public class Regex : IRegex, ISubExpression
    {
        public StringBuilder sb = new StringBuilder();
        private Regex(bool clean = false)
        {
            if (!clean)
            {
                sb.Append("/");
            }
        }

        public static Regex Start() => new Regex();
        private static Regex Clean() => new Regex(true);
        public Regex MatchSingleCharacter(char character)
        {
            sb.Append($".{character}");
            return this;
        }

        public Regex MatchDigit()
        {
            sb.Append(@"\d");
            return this;
        }

        public Regex EndSubexpression()
        {
            return this;
        }

        public Regex MatchNoneDigit()
        {
            sb.Append(@"\D");
            return this;
        }

        public Regex MatchCharacter()
        {
            sb.Append(@"\w");
            return this;
        }

        public Regex MatchNoneCharacter()
        {
            sb.Append(@"\W");
            return this;
        }

        public Regex MatchCharacterSet(string sequence)
        {
            sb.Append($"[{sequence}]");
            return this;
        }

        public Regex MatchWord(string word)
        {
            sb.Append(word);
            return this;
        }

        public ISubExpression AddSubexpression(Func<Regex, Regex> pattern)
        {
            sb.Append($"({pattern.Invoke(Regex.Clean()).AsString()})");
            return this;
        }

        public StringBuilder AsStringBuilder()
        {
            return sb;
        }

        public string AsString()
        {
            return sb.ToString();
        }

        public System.Text.RegularExpressions.Regex AsRegex()
        {
            return new System.Text.RegularExpressions.Regex(sb.ToString());
        }

        public Regex EscapeChar(char character)
        {
            sb.Append($@"\{character}");
            return this;
        }

        public Regex MatchNegativeCharacterSet(string sequence)
        {
            sb.Append($"[^{sequence}]");
            return this;
        }

        public Regex MatchExactNCharInstance(string sequence, uint instance)
        {
            sb.Append(sequence + "{" + instance + "}");
            return this;
        }

        public Regex MatchAtLeastNCharInstance(string sequence, uint instance)
        {
            sb.Append(sequence + "{" + instance + ",}");
            return this;
        }

        public Regex MatchInRangeCharInstanc(string sequence, uint start, uint max)
        {
            sb.Append(sequence + "{" + $"{start},{max}" + "}");
            return this;
        }

        public Regex MatchSingleWhitespace()
        {
            sb.Append(@"\s");
            return this;
        }

        public Regex MatchNoneWhitespace()
        {
            sb.Append(@"\S");
            return this;
        }

        public Regex MatchTab()
        {
            sb.Append(@"\t");
            return this;
        }

        public Regex MatchCarriageReturn()
        {
            sb.Append(@"\r");
            return this;
        }

        public Regex MatchLineFeed()
        {
            sb.Append(@"\n");
            return this;
        }

        public Regex MatchVerticalTab()
        {
            sb.Append(@"\v");
            return this;
        }

        public Regex MatchFormFeed()
        {
            sb.Append(@"\f");
            return this;
        }

        public Regex MatchBackspace()
        {
            sb.Append(@"[\b]");
            return this;
        }

        public Regex MatchNullCharacter()
        {
            sb.Append(@"\0");
            return this;
        }

        public Regex MatchControlCharacter(char character)
        {
            sb.Append($@"\c{character}");
            return this;
        }

        public Regex MatchHexidecimalCharacter(string hexcode)
        {
            sb.Append($@"\x{hexcode}");
            return this;
        }

        public Regex MatchUTF16Character(string hexcode)
        {
            sb.Append($@"\u{hexcode}");
            return this;
        }

        public Regex MatchLookAheadAssertion(string x, string y)
        {
            sb.Append($"{x}(?={y})");
            return this;
        }

        public Regex MatchNagativeLookAheadAssertion(string x, string y)
        {
            sb.Append($"{x}(?!{y})");
            return this;
        }

        public Regex MatchLookBehindAssertion(string x, string y)
        {
            sb.Append($"(?<={y}){x}");
            return this;
        }

        public Regex MatchNegativeLookBehindAssertion(string x, string y)
        {
            sb.Append($"(?<!{y}){x}");
            return this;
        }

        public Regex MatchWithOr(string x, string y)
        {
            sb.Append($"{x}|{y}");
            return this;
        }

        public Regex MatchFromEndOfInput(string match)
        {
            sb.Append($"{match}$");
            return this;
        }

        public Regex MatchFromBeginningOfInput(string match)
        {
            sb.Append($"^{match}");
            return this;
        }

        public Regex MatchFromBeginningOfInput(Func<Regex, Regex> func)
        {
            sb.Append($"^{func.Invoke(Regex.Clean()).AsString()}");
            return this;
        }

        public Regex MatchFromEndOfInput(Func<Regex, Regex> func)
        {
            sb.Append($"{func.Invoke(Regex.Clean()).AsString()}$");
            return this;
        }
    }
}
