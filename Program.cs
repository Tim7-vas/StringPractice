using System;
using System.Text;
using StringPractice;
Console.OutputEncoding = Encoding.UTF8;
// Практический блок
PracticeExamples.RunAll();
// Задание 1: Анализатор текста
string sampleText = "C# — современный язык программирования. C# используется для создания веб-приложений, игр и сервисов! Строки в C# неизменяемы.";
TextAnalyzer.Analyze(sampleText);
// Задание 2: Генератор отчёта
var reportBuilder = new ReportBuilder();
var sales = new[]
{
new Sale("Ноутбук", 2, 75000m),
new Sale("Беспроводная мышь", 5, 1850m),
new Sale("Механическая клавиатура", 3, 5400m)
};
string report = reportBuilder.BuildReport(sales);
Console.WriteLine(report);
reportBuilder.SaveToFile(report);
// Задание 3: Шифр Цезаря
Console.WriteLine("=== ЗАДАНИЕ 3: ШИФР ЦЕЗАРЯ ===");
string secret = "Hello, World! 2026";
string encrypted = CaesarCipher.Encrypt(secret, 3);
string decrypted = CaesarCipher.Decrypt(encrypted, 3);
Console.WriteLine($"Исходный: {secret} -> Зашифрован: {encrypted} -> Расшифрован: {decrypted}\n");
// Задание 4: Парсер CSV с кавычками
Console.WriteLine("=== ЗАДАНИЕ 4: ПАРСЕР CSV С КАВЫЧКАМИ ===");
string csvInput = ""Smith, John",42,"New York, NY"";
var parsedFields = CsvParser.ParseLine(csvInput);
Console.WriteLine($"Разобрано полей ({parsedFields.Count}): {string.Join(" | ", parsedFields)}");
Console.WriteLine($"Собрано обратно в CSV: {CsvParser.ToCsvLine(parsedFields)}\n");
// Задание 5: Многопоточный логгер
ThreadSafeLogger.RunDemo();
// Задание 6: Unicode
UnicodeHelper.RunDemo();
