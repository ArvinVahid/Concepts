public sealed class String
{
    private readonly char[] _chars;
    public String(char[] value)
    {
        _chars = new char[value.Length];
        Array.Copy(value, _chars, value.Length);
    }

    public static String Concat(String str1, String str2)
    {
        int str1Length = str1._chars.Length;
        int str2Length = str2._chars.Length;

        char[] result = new char[str1Length + str2Length];
        Array.Copy(str1._chars, 0, result, 0, str1Length);
        Array.Copy(str2._chars, 0, result, str1Length, str2Length);

        return new String(result);
    }
}