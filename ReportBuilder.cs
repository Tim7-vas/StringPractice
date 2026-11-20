using System;
using System.IO;
using System.Text;

namespace StringPractice;

public record Sale(string Product, int Quantity, decimal Price);

public class ReportBuilder
{
public string BuildReport(Sale[] sales)
{
StringBuilder sb = new StringBuilder();
sb.AppendLine("=== ЗАДАНИЕ 2: ОТЧЁТ О ПРОДАЖАХ ===");
sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
sb.AppendLine(new string('-', 58));
sb.AppendLine($"{"Товар".PadRight(22)} | {"Кол-во".PadLeft(8)} | {"Цена".PadLeft(10)} | {"Сумма".PadLeft(10)}");
sb.AppendLine(new string('-', 58));

decimal grandTotal = 0;
foreach (var sale in sales)
{
decimal lineTotal = sale.Quantity * sale.Price;
grandTotal += lineTotal;
sb.AppendLine($"{sale.Product.PadRight(22)} | {sale.Quantity.ToString().PadLeft(8)} | {sale.Price.ToString("F2").PadLeft(10)} | {lineTotal.ToString("F2").PadLeft(10)}");
}

sb.AppendLine(new string('-', 58));
sb.AppendLine($"{"ИТОГО:".PadRight(45)} {grandTotal:F2} руб.");
return sb.ToString();
}

public void SaveToFile(string report, string filePath = "sales_report.txt")
{
File.WriteAllText(filePath, report, Encoding.UTF8);
}
}
