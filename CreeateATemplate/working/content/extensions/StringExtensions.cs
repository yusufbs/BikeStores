namespace System;

public static class StringExtensions
{
    public static string Reverse(this string value)
    {
        char[] charArray = value.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    
}