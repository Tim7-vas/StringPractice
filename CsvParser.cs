using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringPractice;

public static class CsvParser
{
public static List<string> ParseLine(string line)
{
List<string> fields = new List<string>();
StringBuilder current = new StringBuilder();
bool inQuotes = false;

for (int i = 0; i < line.Length; i++)
{
char c = line[i];
if (c == '"')
{
if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
{
current.Append('"');
i++;
}
else
{
inQuotes = !inQuotes;
}
}
else if (c == ',' && !inQuotes)
{
fields.Add(current.ToString());
current.Clear();
}
else
{
current.Append(c);
}
}
fields.Add(current.ToString());
return fields;
}
public static string ToCsvLine(IEnumerable fields)
{
return string.Join(",", fields.Select(f =>
f.Contains(',') || f.Contains('"') ? $""{f.Replace(""", """")}"" : f));
}
}
