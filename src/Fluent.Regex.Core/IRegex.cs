using System;

namespace Fluent.Regex.Core
{
    public interface IRegex : IOutputTypes
    {
        /// <summary>
        /// Use this if you know the regex or is a simple output
        /// Matches the beginning of input. For example, /^A/ does not match the "A" in "an A", but does match the first "A" in "An A".
        /// </summary>
        Regex MatchFromBeginningOfInput(string match);

        /// <summary>
        /// Use this if you want to create a more complex regex query
        /// Matches the beginning of input. For example, /^A/ does not match the "A" in "an A", but does match the first "A" in "An A".
        /// </summary>
        Regex MatchFromBeginningOfInput(Func<Regex, Regex> func);

        /// <summary>
        /// Matches the end of input. If the multiline flag is set to true, also matches immediately before a line break character. For example, /t$/ does not match the "t" in "eater", but does match it in "eat".
        /// </summary>
        Regex MatchFromEndOfInput(string match);
        Regex MatchFromEndOfInput(Func<Regex, Regex> func);

        /// <summary>
        /// Matches any single character except a newline character.
        ///</summary>
        Regex MatchSingleCharacter(char characher);

        /// <summary>
        /// Matches a digit character. Equivalent to [0-9].
        /// </summary>
        Regex MatchDigit();

        /// <summary>
        /// Matches any character that is not a digit (Arabic numeral). Equivalent to [^0-9]. For example, /\D/ or /[^0-9]/ matches "B" in "B2 is the suite number".
        /// </summary>
        Regex MatchNoneDigit();

        /// <summary>
        /// Matches any alphanumeric character from the basic Latin alphabet, including the underscore. Equivalent to [A-Za-z0-9_]. For example, /\w/ matches "a" in "apple", "5" in "$5.28", and "3" in "3D".
        /// </summary>
        Regex MatchCharacter();

        /// <summary>
        /// Matches any character that is not a word character from the basic Latin alphabet. Equivalent to [^A-Za-z0-9_]. For example, /\W/ or /[^A-Za-z0-9_]/ matches "%" in "50%".
        /// </summary>
        Regex MatchNoneCharacter();

        /// <summary>
        /// A character set. Matches any one of the enclosed characters. For example, [abc] matches the a in plain.
        /// OR
        /// Matches any character in the specified range. For example, "[a-z]" matches any lowercase alphabetic character in the range a through z.
        /// </summary>
        Regex MatchCharacterSet(string sequence);

        /// <summary>
        /// A negative character set. Matches any character not enclosed. For example, [^abc] matches the p in plain.
        /// OR
        /// A negative range characters. Matches any character not in the specified range. For example, [^m-z] matches any character not in the range m through z.
        /// </summary>
        Regex MatchNegativeCharacterSet(string sequence);

        /// <summary>
        /// n is a non negative integer. Matches exactly n times. For example, o{2} does not match the o in Bob, but matches the first two o's in foooood.
        /// </summary>
        Regex MatchExactNCharInstance(string sequence, uint instance);

        /// <summary>
        /// n is a non negative integer. Matches at least n times.
        /// For example, o{2,} does not match the o in Bob and matches all the o's in "foooood."
        /// o{1,} is equivalent to o+. o{0,} is equivalent to o*.
        /// </summary>
        Regex MatchAtLeastNCharInstance(string sequence, uint instance);

        /// <summary>
        /// m and n are nonnegative integers. Matches at least n and at most m times. For example, o{1,3} matches the first three o's in "fooooood." o{0,1} is equivalent to o?.
        /// </summary>
        Regex MatchInRangeCharInstanc(string sequence, uint start, uint max);

        /// <summary>
        /// Matches the input string exactly
        /// </summary>
        Regex MatchWord(string word);

        /// <summary>
        /// Marks the next character as either a special character or a literal. For example:
        /// n matches the character n. "\n" matches a newline character.
        /// The sequence \\ matches \ and \( matches (.
        /// </summary>
        Regex EscapeChar(char character);

        /// <summary>
        /// Matches a single white space character, including space, tab, form feed, line feed, and other Unicode spaces. Equivalent to [ \f\n\r\t\v\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]. For example, /\s\w*/ matches " bar" in "foo bar".
        /// </summary>
        Regex MatchSingleWhitespace();

        /// <summary>
        /// Matches a single character other than white space. Equivalent to [^ \f\n\r\t\v\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]. For example, /\S\w*/ matches "foo" in "foo bar".
        /// </summary>
        Regex MatchNoneWhitespace();

        /// <summary>
        /// Matches a horizontal tab.
        /// </summary>
        Regex MatchTab();

        /// <summary>
        /// Matches a carriage return.
        /// </summary>
        Regex MatchCarriageReturn();

        /// <summary>
        /// Matches a linefeed.
        /// </summary>
        Regex MatchLineFeed();

        /// <summary>
        /// Matches a vertical tab.
        /// </summary>
        Regex MatchVerticalTab();

        /// <summary>
        /// Matches a form-feed.
        /// </summary>
        Regex MatchFormFeed();

        /// <summary>
        /// Matches a backspace. If you're looking for the word-boundary character (\b)
        /// </summary>
        Regex MatchBackspace();

        /// <summary>
        /// Matches a NUL character. Do not follow this with another digit.
        /// </summary>
        Regex MatchNullCharacter();

        /// <summary>
        /// Matches a control character using caret notation, where "X" is a letter from A–Z (corresponding to codepoints U+0001–U+001F). For example, /\cM/ matches "\r" in "\r\n"
        /// </summary>
        Regex MatchControlCharacter(char character);

        /// <summary>
        /// Matches the character with the code hh (two hexadecimal digits).
        /// </summary>
        Regex MatchHexidecimalCharacter(string hexcode);

        /// <summary>
        /// Matches a UTF-16 code-unit with the value hhhh (four hexadecimal digits).
        /// </summary>
        Regex MatchUTF16Character(string hexcode);

        /// <summary>
        /// Lookahead assertion: Matches "x" only if "x" is followed by "y". For example, /Jack(?=Sprat)/ matches "Jack" only if it is followed by "Sprat".
        /// /Jack(?=Sprat|Frost)/ matches "Jack" only if it is followed by "Sprat" or "Frost". However, neither "Sprat" nor "Frost" is part of the match results.
        /// </summary>
        Regex MatchLookAheadAssertion(string x, string y);

        /// <summary>
        /// Negative lookahead assertion: Matches "x" only if "x" is not followed by "y". For example, /\d+(?!\.)/ matches a number only if it is not followed by a decimal point. /\d+(?!\.)/.exec('3.141') matches "141" but not "3".
        /// </summary>
        Regex MatchNagativeLookAheadAssertion(string x, string y);

        /// <summary>
        /// Lookbehind assertion: Matches "x" only if "x" is preceded by "y". For example, /(?<=Jack)Sprat/ matches "Sprat" only if it is preceded by "Jack". /(?<=Jack|Tom)Sprat/ matches "Sprat" only if it is preceded by "Jack" or "Tom". However, neither "Jack" nor "Tom" is part of the match results.
        /// </summary>
        Regex MatchLookBehindAssertion(string x, string y);

        /// <summary>
        /// Negative lookbehind assertion: Matches "x" only if "x" is not preceded by "y". For example, /(?<!-)\d+/ matches a number only if it is not preceded by a minus sign. /(?<!-)\d+/.exec('3') matches "3". /(?<!-)\d+/.exec('-3')  match is not found because the number is preceded by the minus sign.
        /// </summary>
        Regex MatchNegativeLookBehindAssertion(string x, string y);

        /// <summary>
        /// Matches either "x" or "y". For example, /green|red/ matches "green" in "green apple" and "red" in "red apple".
        /// </summary>
        Regex MatchWithOr(string x, string y);

        /// <summary>
        /// Matches subexpression and remembers the match. If a part of a regular expression is enclosed in parentheses, that part of the regular expression is grouped together. Thus a regex operator can be applied to the entire group.
        /// - If you need to use the matched substring within the same regular expression, you can retrieve it using the backreference \num, where num = 1..n.
        /// - If you need to refer the matched substring somewhere outside the current regular expression (for example, in another regular expression as a replacement string), you can retrieve it using the dollar sign $num, where num = 1..n.
        /// - If you need to include the parentheses characters into a subexpression, use EscapeChar().
        /// </summary>
        ISubExpression AddSubexpression(Func<Regex, Regex> pattern);
    }
}
