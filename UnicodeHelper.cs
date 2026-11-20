using System;
using System.Globalization;
using System.Text;
namespace StringPractice;
public static class UnicodeHelper
{
public static void RunDemo()
{
Console.WriteLine("=== ЗАДАНИЕ 6: ВАЛИДАЦИЯ И НОРМАЛИЗАЦИЯ UNICODE ===");
string decomposed = "cafe\u0301 \U0001F468\u200D\U0001F4BB"; // "café" (e + ударение) и эмодзи программиста
bool isFormC = decomposed.IsNormalized(NormalizationForm.FormC);
Console.WriteLine($"Исходная строка: {decomposed}");
Console.WriteLine($"В нормальной форме C (FormC): {isFormC}");
Console.WriteLine($"Длина в char (UTF-16): {decomposed.Length}");
Console.WriteLine($"Количество графем (StringInfo): {new StringInfo(decomposed).LengthInTextElements}");
if (!isFormC)
{
string normalized = decomposed.Normalize(NormalizationForm.FormC);
Console.WriteLine($"После Normalize(FormC): isFormC = {normalized.IsNormalized(NormalizationForm.FormC)}, длина в char = {normalized.Length}\n");
}
}
}
