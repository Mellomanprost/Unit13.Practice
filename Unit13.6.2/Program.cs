using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unit13._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"c:\SkillFactory\Text1.txt";
            string allText = File.ReadAllText(pathToFile);
            var noPunctuationText = new string(allText.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] delimiters = { ' ', '\r', '\n' };
            string[] words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);    // Удалияет из текста знаки пунктуации
            var numberOfWordsDictionary = new Dictionary<string, int>();

            /// Заносим слова в словарь и считаем количество их повторений в тексте
            foreach (var word in words)
            {
                if (!numberOfWordsDictionary.ContainsKey(word))
                {
                    numberOfWordsDictionary.TryAdd(word, 1);
                    continue;
                }
                numberOfWordsDictionary[word] += 1;
            }
            
            /// Сортируем словарь по значениям (т.е. количеству повторений слов) и делаем реверс, чтобы начало было с самого большого кол-ва повторений
            var mySortedList = numberOfWordsDictionary.OrderBy(d => d.Value).ToList();
            mySortedList.Reverse();

            /// Выводим в консоль первые 10 элементов с самым большим количеством повторений
            Console.WriteLine("Чаще всего встречаются в тексте:");
            foreach (var wordItem in mySortedList.GetRange(0, 10))
            {
                Console.WriteLine(wordItem.Key + " : " + wordItem.Value);
            }
        }
    }
}
