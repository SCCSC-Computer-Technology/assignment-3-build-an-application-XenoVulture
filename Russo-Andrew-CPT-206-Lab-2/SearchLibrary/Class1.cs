namespace SearchLibrary;

public static class StringCheck
{
    public static int ContainsValidData(this string? str) //  public static int ContainsValidData(this string? str) NEEDS C# 8.0+ to allow for null
    {
        int x = 0;
        char ch;

        if (!string.IsNullOrWhiteSpace(str))
        {
            ch = str[0]; // Get the first character of the string
            
            if (char.IsLetter(ch) || char.IsWhiteSpace(ch)) // Allows for letters or spaces.
            {
                foreach (char c in str)
                {
                    if (char.IsLetter(c))
                    {
                        x = 1; // Only contains letters
                    }
                    else
                    {
                        return -1; // Means started with letter, but contains chars that are not letters.
                    }
                }
            }
            else if (char.IsDigit(ch)) // || char.IsWhiteSpace(ch) Allowing for spaces here shouldn't be needed. Include in error message
            {
                foreach (char c in str)
                {
                    if (char.IsDigit(c))
                    {
                        x = 2;
                    }
                    else
                    {
                        return -2; // Means started with digit, but contains chars that are not digits.
                    }
                }
            }
        }
        else
        {

            return 0;
        }

        return x;
    }
}