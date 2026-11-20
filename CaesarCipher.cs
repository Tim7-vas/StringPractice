namespace StringPractice;

public static class CaesarCipher
{
public static string Encrypt(string input, int shift)
{
char[] buffer = input.ToCharArray();
int normalizedShift = ((shift % 26) + 26) % 26;

for (int i = 0; i < buffer.Length; i++)
{
char c = buffer[i];
if (c >= 'A' && c <= 'Z')
{
buffer[i] = (char)('A' + (c - 'A' + normalizedShift) % 26);
}
else if (c >= 'a' && c <= 'z')
{
buffer[i] = (char)('a' + (c - 'a' + normalizedShift) % 26);
}
}
return new string(buffer);
}

public static string Decrypt(string input, int shift)
{
return Encrypt(input, -shift);
}
}
