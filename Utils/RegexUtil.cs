using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsiMigrationHelper
{
    class RegexUtil
    {

        public static string FindSubstringMatchingPattern(string input, string patternToMatch, int matchMode, bool caseSensitive)
        {
            RegexOptions ro = new RegexOptions();
            if (!caseSensitive)
            {
                ro = RegexOptions.IgnoreCase;
            }
            var phrases = new List<string> { patternToMatch };

            switch (matchMode)
            {
                case 0:
                    /*
                        match pattern anywhere within the input:
                        input = " a^TEST", patternToMatch = "TEST" <== finds match at index [3] 
                    */
                    break;
                case 1:
                    /*
                        match whole words only but do not include "non-word" characters in search pattern
                        \b matches positions where one side is a word character
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== no match found
                    */
                    patternToMatch = @"\b" + patternToMatch + @"\b";
                    break;
                case 2:
                    /*
                        match whole words and include "non-word" characters in search pattern:
                        \B matches all positions where \b doesn't match
                        (?!\B\w) = require a word boundary on the left only if the char that follows the word boundary is a word char
                        (?<!\w\B) = require a word boundary on the right only if the char that precedes the word boundary is a word char
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== finds match at index [2]
                    */
                    patternToMatch = $@"(?!\B\w)(?:{string.Join(Environment.NewLine, phrases.Select(y => Regex.Escape(y)))})(?<!\w\B)";
                    break;
                default:
                    throw new FormatException(string.Format("Non-accepted option: {0} received; the methods accepts options: 0 - 2", (int)matchMode));
                    //break;
            }
            Match match = Regex.Match(input.ToString(), patternToMatch, ro);
            if (match.Groups[0].Value != String.Empty)
            {
                return match.Groups[0].Value;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ReplaceSubstringMatchingPattern(string input, string patternToMatch, string replacement, int matchMode, bool caseSensitive)
        {
            RegexOptions ro = new RegexOptions();
            if (!caseSensitive)
            {
                ro = RegexOptions.IgnoreCase;
            }
            var phrases = new List<string> { patternToMatch };

            switch (matchMode)
            {
                case 0:
                    /*
                        match pattern anywhere within the input:
                        input = " a^TEST", patternToMatch = "TEST" <== finds match at index [3] 
                    */
                    break;
                case 1:
                    /*
                        match whole words only but do not include "non-word" characters in search pattern
                        \b matches positions where one side is a word character
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== no match found
                    */
                    patternToMatch = @"\b" + patternToMatch + @"\b";
                    break;
                case 2:
                    /*
                        match whole words and include "non-word" characters in search pattern:
                        \B matches all positions where \b doesn't match
                        (?!\B\w) = require a word boundary on the left only if the char that follows the word boundary is a word char
                        (?<!\w\B) = require a word boundary on the right only if the char that precedes the word boundary is a word char
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== finds match at index [2]
                    */
                    patternToMatch = $@"(?!\B\w)(?:{string.Join(Environment.NewLine, phrases.Select(y => Regex.Escape(y)))})(?<!\w\B)";
                    break;
                default:
                    throw new FormatException(string.Format("Non-accepted option: {0} received; the methods accepts options: 0 - 2", (int)matchMode));
                    //break;
            }
            Match match = Regex.Match(input.ToString(), patternToMatch, ro);
            if (match.Groups[0].Value != String.Empty)
            {
                //return match.Groups[0].Value;
                return Regex.Replace(input, match.Groups[0].Value, replacement);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string RemoveSubstringMatchingPattern(string input, string patternToMatch, int matchMode, bool caseSensitive)
        {
            RegexOptions ro = new RegexOptions();
            if (!caseSensitive)
            {
                ro = RegexOptions.IgnoreCase;
            }
            var phrases = new List<string> { patternToMatch };

            switch (matchMode)
            {
                case 0:
                    /*
                        match pattern anywhere within the input:
                        input = " a^TEST", patternToMatch = "TEST" <== finds match at index [3] 
                    */
                    break;
                case 1:
                    /*
                        match whole words only but do not include "non-word" characters in search pattern
                        \b matches positions where one side is a word character
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== no match found
                    */
                    patternToMatch = @"\b" + patternToMatch + @"\b";
                    break;
                case 2:
                    /*
                        match whole words and include "non-word" characters in search pattern:
                        \B matches all positions where \b doesn't match
                        (?!\B\w) = require a word boundary on the left only if the char that follows the word boundary is a word char
                        (?<!\w\B) = require a word boundary on the right only if the char that precedes the word boundary is a word char
                        input = " a^TESTa", patternToMatch = "TEST" <== no match found
                        input = " a^TEST",  patternToMatch = "TEST" <== finds match at index [3] 
                        input = " a^TEST",  patternToMatch = "^TEST" <== finds match at index [2]
                    */
                    patternToMatch = $@"(?!\B\w)(?:{string.Join(Environment.NewLine, phrases.Select(y => Regex.Escape(y)))})(?<!\w\B)";
                    break;
                default:
                    throw new FormatException(string.Format("Non-accepted option: {0} received; the methods accepts options: 0 - 2", (int)matchMode));
                    //break;
            }
            Match match = Regex.Match(input.ToString(), patternToMatch, ro);
            if (match.Groups[0].Value != String.Empty)
            {
                //return match.Groups[0].Value;
                return Regex.Replace(input, match.Groups[0].Value, "");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
