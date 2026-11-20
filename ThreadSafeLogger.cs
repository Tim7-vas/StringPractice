using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace StringPractice;
public class ThreadSafeLogger
{
private readonly StringBuilder _safeLog = new StringBuilder();
private readonly StringBuilder _unsafeLog = new StringBuilder();
private readonly object _lock = new object();
public void LogSafe(string message)
{
lock (_lock)
{
_safeLog.AppendLine(message);
}
}
public void LogUnsafe(string message)
{
_unsafeLog.AppendLine(message);
}
public string GetSafeLog()
{
lock (_lock)
{
return _safeLog.ToString();
}
}
public string GetUnsafeLog() => _unsafeLog.ToString();
public void SaveToFile(string filePath = "thread_log.txt")
{
File.WriteAllText(filePath, GetSafeLog(), Encoding.UTF8);
}
public static void RunDemo()
{
Console.WriteLine("=== ЗАДАНИЕ 5: МНОГОПОТОЧНЫЙ ЛОГГЕР ===");
var logger = new ThreadSafeLogger();
const int messagesCount = 500;
Parallel.For(0, messagesCount, i =>
{
logger.LogSafe($"[Thread {Environment.CurrentManagedThreadId}] Событие #{i}");
try
{
logger.LogUnsafe($"[Thread {Environment.CurrentManagedThreadId}] Событие #{i}");
}
catch
{
// Игнорируем исключения гонки данных в небезопасном режиме
}
});
int safeLines = logger.GetSafeLog().Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
int unsafeLines = logger.GetUnsafeLog().Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
Console.WriteLine($"Ожидалось строк: {messagesCount}");
Console.WriteLine($"С синхронизацией (lock): {safeLines} строк");
Console.WriteLine($"Без синхронизации: {unsafeLines} строк (потеряно {messagesCount - unsafeLines})\n");
}
}
