using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabluary
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.Write("Введите сообщение, чтобы вычислить его словарный запас. Чтобы остановить ввод, введите: %stop%: ");

            string prompt = Console.ReadLine();
            string message = "";

            while (prompt != "%stop%")
            {
                message += prompt + ' ';
                prompt = Console.ReadLine();
            }

            prog.GetResult(message, false);

            Console.WriteLine("\n\nРусские слова: ");

            prog.GetResult(message, true);

            Console.ReadKey();
        }

        private void GetResult(in string message, bool russianWords)
        {
            List<string> vocabluary = new List<string>();

            vocabluary = GetVocabluary(GetWordsInMessage(message, russianWords));

            Console.WriteLine("\nСловарный запас сообщения: \n");

            for (int i = 0; i < vocabluary.Count; i++)
                Console.Write(vocabluary[i] + (i < vocabluary.Count - 1 ? ", " : ". ") + (Console.CursorLeft >= 100 ? "\n" : null));

            Console.WriteLine($"\n\nКоличество слов: {vocabluary.Count}.");
        }

        private List<string> GetWordsInMessage(string message, bool getRussianWords)
        {
            string word;
            List<string> result = new List<string>();
            List<char> symbolsInWord = new List<char>();

            foreach (char symbol in message)
            {
                if (symbolsInWord.Count == 0 && (symbol == ' ' || IsPunctuationMark(symbol)))
                    continue;

                if (symbol == ' ' || IsPunctuationMark(symbol))
                {
                    word = new string(symbolsInWord.ToArray());

                    if (!getRussianWords || IsRussianWord(word))
                        result.Add(word);

                    symbolsInWord.Clear();
                }
                else
                    symbolsInWord.Add(symbol);
            }

            return result;
        }

        private List<string> GetVocabluary(List<string> wordList)
        {
            List<string> result = wordList;

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int k = i + 1; k < result.Count; k++)
                {
                    if (result[k].ToLower() == result[i].ToLower())
                    {
                        result.RemoveAt(k);
                        k--;
                    }
                }
            }

            return result;
        }

        private bool IsPunctuationMark(char symbol)
        {
            char[] punctuationMarks = new char[] { ',', '.', '!', '?', '-', '"', '(', ')', '—', '«', '»', '[', ']', '{', '}', '+', '-', '*', '/', ';' };

            foreach (char mark in punctuationMarks)
            {
                if (symbol == mark)
                    return true;
            }

            return false;
        }

        private bool IsRussianWord(string word)
        {
            string wordTU = word.ToUpper();

            foreach (char symbol in wordTU)
            {
                if (symbol < 'А' || symbol > 'Я')
                    return false;
            }

            return true;
        }
    }
}