using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Unit13._6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\SkillFactory\Text1.txt";
            string allText = File.ReadAllText(path);
            char[] delimiters = { ' ', '\r', '\n' };
            string[] words = allText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var stopWatch = Stopwatch.StartNew();
            var listOFWords = new List<string>(words);
            Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}мс затрачено на добавления текста в List");

            stopWatch = Stopwatch.StartNew();
            var linkedListOfWords = new LinkedList<string>(words);
            Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}мс затрачено на добавления текста в LinkedList");
        }
    }
}
