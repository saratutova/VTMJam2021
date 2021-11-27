public enum StringType
{
    Chapter1
}

public static class StaticStrings
{
    private static string chapter1 = "Chapter 1";

    public static string GetString(StringType type)
    {
        switch (type)
        {
            case StringType.Chapter1:
                return chapter1;
            default:
                return "NONE";
        }
    }
}
