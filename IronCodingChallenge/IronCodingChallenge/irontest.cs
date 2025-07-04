using System.Collections.Generic;
using System.Text;

public class irontest
{
    public static string Decode(List<string> sequences)
    {
        var keypad = new Dictionary<char, string>
        {
            { '1', "" }, { '2', "ABC" }, { '3', "DEF" },
            { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
            { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" },
            { '0', " " }
        };

        StringBuilder result = new StringBuilder();

        foreach (string sequence in sequences)
        {
            if (string.IsNullOrEmpty(sequence))
                continue;

            char key = sequence[0];
            int count = sequence.Length;

            if (keypad.ContainsKey(key) && keypad[key].Length > 0)
            {
                string letters = keypad[key];
                int index = (count - 1) % letters.Length;
                result.Append(letters[index]);
            }
        }

        return result.ToString();
    }
}
