using System.Text;

namespace Fluent.Regex.Standard
{
    public interface IOutputTypes
    {
        /// <summary>
        /// Return the generated regular expression as a string
        /// </summary>
        string AsString();

        /// <summary>
        /// Returns the generated regular expression as a StringBuilder
        /// </summary>
        StringBuilder AsStringBuilder();

        /// <summary>
        /// Returns the generated regular expression as a Regex class
        /// </summary>
        System.Text.RegularExpressions.Regex AsRegex();
    }
}
