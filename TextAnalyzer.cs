using System;
using System.Linq;

namespace StringPractice;

public static class TextAnalyzer
{
public static void Analyze(string text)
{
Console.WriteLine("=== ЗАДАНИЕ 1: АНАЛИЗАТОР ТЕКСТА ===");
int totalChars = text.Length;
int charsWithoutSpaces = text.Count(c => !char.IsWhiteSpace(c));

char[] wordSeparators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' };
string[] words = text.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries)
.Select(w => w.Trim())
.ToArray();

char[] sentenceSeparators = { '.', '!', '?' };
string[] sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries)
.Where(s => !string.IsNullOrWhiteSpace(s))
.ToArray();

string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault() ?? "";
string shortestWord = words.OrderBy(w => w.Length).FirstOrDefault() ?? "";

var top5 = words
.Select(w => w.ToLower())
.GroupBy(w => w)
.OrderByDescending(g => g.Count())
.Take(5);

Console.WriteLine($"Символов (всего / без пробелов): {totalChars} / {charsWithoutSpaces}");
Console.WriteLine($"Слов: {words.Length} | Предложений: {sentences.Length}");
Console.WriteLine($"Самое длинное слово: {longestWord} | Самое короткое: {shortestWord}");
Console.WriteLine("Топ-5 частых слов:");
foreach (var item in top5)
{
Console.WriteLine($" - {item.Key}: {item.Count()} раз(а)");
}
Console.WriteLine();
}
}
