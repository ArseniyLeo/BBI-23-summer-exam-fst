using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_4
{

    public class Task3
    {
        public class Uniques
        {
            private string input;
            private string[] output;

            public Uniques(string text)
            {
                input = text;
                output = FindUniqueWords(text);
            }

            public string Input => input;
            public string[] Output => output;

            private string[] FindUniqueWords(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return new string[0]; 
                }

                string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> uniqueWords = new List<string>();

                foreach (string word in words)
                {
                    if (word.Length > 1 && HasUniqueLetters(word))
                    {
                        uniqueWords.Add(word.ToLower()); 
                    }
                }

                return uniqueWords.ToArray();
            }

            private bool HasUniqueLetters(string word)
            {
                
                for (int i = 0; i < word.Length; i++)
                {
                   
                    char currentLetter = char.ToLower(word[i]);

                   
                    for (int j = i + 1; j < word.Length; j++)
                    {
                        
                        char otherLetter = char.ToLower(word[j]);

                        if (currentLetter == otherLetter)
                        {
                            return false; 
                        }
                    }
                }

                return true; 
            }

            public override string ToString()
            {
                if (output.Length == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                foreach (string word in output)
                {
                    sb.AppendLine(word);
                }
                return sb.ToString();
            }
        }
    }
}
