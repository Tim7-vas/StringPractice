using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice;

public static class PracticeExamples
{
public static void RunAll()
{
Console.WriteLine("=== ПРАКТИЧЕСКИЙ БЛОК ===");

// 1. Неизменяемость и пул интернирования
string original = "Hello";
string modified = original.ToUpper();
Console.WriteLine($"[1] original: {original}, modified: {modified}, ReferenceEquals: {object.ReferenceEquals(original, modified)}");

string a = "world";
string b = "world";
string c = new string("world".ToCharArray());
string d = string.Intern(c);
Console.WriteLine($"[1] Literals ref: {object.ReferenceEquals(a, b)}, Literal vs new: {object.ReferenceEquals(a, c)}, After Intern: {object.ReferenceEquals(a, d)}");

// 2. Сравнение производительности += и StringBuilder
const int N = 20_000;
Stopwatch sw1 = Stopwatch.StartNew();
string s = "";
for (int i = 0; i < N; i++) s += i.ToString();
sw1.Stop();

Stopwatch sw2 = Stopwatch.StartNew();
StringBuilder sb = new StringBuilder();
for (int i = 0; i < N; i++) sb.Append(i);
sw2.Stop();
Console.WriteLine($"[2] String += ({N} итер.): {sw1.ElapsedMilliseconds} ms | StringBuilder: {sw2.ElapsedMilliseconds} ms");

// 3. Разбор текста: Split, Join, Trim
string text = " это пример текста для обработки ";
string[] words = text
.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
.Select(w => w.Trim().ToUpper())
.ToArray();
Console.WriteLine($"[3] Join результат: {string.Join("-", words)}");

// 4. Многопоточная сборка строки с lock
StringBuilder threadSb = new StringBuilder();
object gate = new object();
Parallel.For(0, 1000, i =>
{
lock (gate)
{
threadSb.Append('A');
}
});
Console.WriteLine($"[4] Многопоточный StringBuilder с lock, длина: {threadSb.Length}");

// 5. ReadOnlySpan<char> и StringInfo
string emojiText = "Hello, 🌍!";
ReadOnlySpan<char> span = emojiText.AsSpan(0, 5);
var si = new StringInfo(emojiText);
Console.WriteLine($"[5] Span: {span.ToString()}, Length: {emojiText.Length}, Графем (StringInfo): {si.LengthInTextElements}\n");
}
}
