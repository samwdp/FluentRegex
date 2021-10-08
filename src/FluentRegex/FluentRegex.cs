using System.Text;
using System.Text.RegularExpressions;

namespace FluentRegex;
    public class FluentRegex : IFluentRegex, ISubExpression
    {
        public StringBuilder sb = new StringBuilder();
        private FluentRegex(bool clean = false)
        {
            if (!clean)
            {
                sb.Append("/");
            }
        }
        public static FluentRegex Start() => new FluentRegex();
        private static FluentRegex Clean() => new FluentRegex(true);
        public FluentRegex MatchSingleCharacter(char character)
        {
            sb.Append($".{character}");
            return this;
        }

        public FluentRegex MatchDigit()
        {
            sb.Append(@"\d");
            return this;
        }

        public FluentRegex EndSubexpression()
        {
            return this;
        }

        public FluentRegex MatchNoneDigit()
        {
            sb.Append(@"\D");
            return this;
        }

        public FluentRegex MatchCharacter()
        {
            sb.Append(@"\w");
            return this;
        }

        public FluentRegex MatchNoneCharacter()
        {
            sb.Append(@"\W");
            return this;
        }

        public FluentRegex MatchCharacterSet(string sequence)
        {
            sb.Append($"[{sequence}]");
            return this;
        }

        public FluentRegex MatchWord(string word)
        {
            sb.Append(word);
            return this;
        }

        public ISubExpression AddSubexpression(Func<FluentRegex, FluentRegex> pattern)
        {
            sb.Append($"({pattern.Invoke(FluentRegex.Clean()).AsString()})");
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

        public Regex AsRegex()
        {
            return new Regex(sb.ToString());
        }

        public FluentRegex EscapeChar(char character)
        {
            sb.Append($@"\{character}");
            return this;
        }

        public FluentRegex MatchNegativeCharacterSet(string sequence)
        {
            sb.Append($"[^{sequence}]");
            return this;
        }

        public FluentRegex MatchExactNCharInstance(string sequence, uint instance)
        {
            sb.Append(sequence + "{" + instance + "}");
            return this;
        }

        public FluentRegex MatchAtLeastNCharInstance(string sequence, uint instance)
        {
            sb.Append(sequence + "{" + instance + ",}");
            return this;
        }

        public FluentRegex MatchInRangeCharInstanc(string sequence, uint start, uint max)
        {
            sb.Append(sequence + "{" + $"{start},{max}" + "}");
            return this;
        }

        public FluentRegex MatchSingleWhitespace()
        {
            sb.Append(@"\s");
            return this;
        }

        public FluentRegex MatchNoneWhitespace()
        {
            sb.Append(@"\S");
            return this;
        }

        public FluentRegex MatchTab()
        {
            sb.Append(@"\t");
            return this;
        }

        public FluentRegex MatchCarriageReturn()
        {
            sb.Append(@"\r");
            return this;
        }

        public FluentRegex MatchLineFeed()
        {
            sb.Append(@"\n");
            return this;
        }

        public FluentRegex MatchVerticalTab()
        {
            sb.Append(@"\v");
            return this;
        }

        public FluentRegex MatchFormFeed()
        {
            sb.Append(@"\f");
            return this;
        }

        public FluentRegex MatchBackspace()
        {
            sb.Append(@"[\b]");
            return this;
        }

        public FluentRegex MatchNullCharacter()
        {
            sb.Append(@"\0");
            return this;
        }

        public FluentRegex MatchControlCharacter(char character)
        {
            sb.Append($@"\c{character}");
            return this;
        }

        public FluentRegex MatchHexidecimalCharacter(string hexcode)
        {
            sb.Append($@"\x{hexcode}");
            return this;
        }

        public FluentRegex MatchUTF16Character(string hexcode)
        {
            sb.Append($@"\u{hexcode}");
            return this;
        }

        public FluentRegex MatchLookAheadAssertion(string x, string y)
        {
            sb.Append($"{x}(?={y})");
            return this;
        }

        public FluentRegex MatchNagativeLookAheadAssertion(string x, string y)
        {
            sb.Append($"{x}(?!{y})");
            return this;
        }

        public FluentRegex MatchLookBehindAssertion(string x, string y)
        {
            sb.Append($"(?<={y}){x}");
            return this;
        }

        public FluentRegex MatchNegativeLookBehindAssertion(string x, string y)
        {
            sb.Append($"(?<!{y}){x}");
            return this;
        }

        public FluentRegex MatchWithOr(string x, string y)
        {
            sb.Append($"{x}|{y}");
            return this;
        }

        public FluentRegex MatchFromEndOfInput(string match)
        {
            sb.Append($"{match}$");
            return this;
        }

        public FluentRegex MatchFromBeginningOfInput(string match)
        {
            sb.Append($"^{match}");
            return this;
        }

        public FluentRegex MatchFromBeginningOfInput(Func<FluentRegex, FluentRegex> func)
        {
            sb.Append($"^{func.Invoke(FluentRegex.Clean()).AsString()}");
            return this;
        }

        public FluentRegex MatchFromEndOfInput(Func<FluentRegex, FluentRegex> func)
        {
            sb.Append($"{func.Invoke(FluentRegex.Clean()).AsString()}$");
            return this;
        }
    }
