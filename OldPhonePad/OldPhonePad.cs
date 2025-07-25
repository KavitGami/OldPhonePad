using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public static class PhonePad
    {
        /// <summary>
        /// Decodes a string of keypresses from an old-style phone keypad into text.
        /// </summary>
        /// <param name="input">The input string representing key presses (must end with '#').</param>
        /// <returns>The decoded message as a string.</returns>
        public static string Decode(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            // Holds the final decoded message
            var result = new StringBuilder();

            // Maps keypad digits to their corresponding characters
            var keyMap = new Dictionary<char, string>
            {
                {'1', "&'("},
                {'2', "ABC"},
                {'3', "DEF"},
                {'4', "GHI"},
                {'5', "JKL"},
                {'6', "MNO"},
                {'7', "PQRS"},
                {'8', "TUV"},
                {'9', "WXYZ"},
                {'0', " "} // 0 maps to a space
            };

            // Tracks the previous key pressed
            char prevKey = '\0';

            // Counts how many times the same key has been pressed
            int pressCount = 0;

            // Iterate through each character in the input
            foreach (char ch in input)
            {
                if (ch == '#')
                {
                    // End of input — process the last key sequence and exit
                    AppendCharacter();
                    break;
                }
                else if (ch == '*')
                {
                    // '*' means "backspace": finalize current character and remove last character from result
                    AppendCharacter();
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);
                    prevKey = '\0';
                    pressCount = 0;
                }
                else if (ch == ' ')
                {
                    // A space separates keypress sequences — commit current character
                    AppendCharacter();
                    prevKey = '\0';
                    pressCount = 0;
                }
                else if (char.IsDigit(ch))
                {
                    if (ch == prevKey)
                    {
                        // Same key pressed again — cycle to next character
                        pressCount++;
                    }
                    else
                    {
                        // New key — commit previous character and start counting this one
                        AppendCharacter();
                        prevKey = ch;
                        pressCount = 1;
                    }
                }
            }

            return result.ToString();

            // Appends the current character (based on prevKey and pressCount) to the result
            void AppendCharacter()
            {
                if (prevKey != '\0' && keyMap.ContainsKey(prevKey))
                {
                    var chars = keyMap[prevKey];
                    int index = (pressCount - 1) % chars.Length; // Wrap around if pressCount exceeds available letters
                    result.Append(chars[index]);
                }
            }
        }
    }
}
