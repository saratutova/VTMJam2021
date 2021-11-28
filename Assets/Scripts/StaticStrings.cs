public enum StringType
{
    Chapter1, Chapter2, Chapter3
}

public static class StaticStrings
{
    private static string chapter1 = "Chapter 1";
    private static string chapter2 = "Chapter 2";
    private static string chapter3 = "Chapter 3";

    public static string GetString(StringType type)
    {
        switch (type)
        {
            case StringType.Chapter1:
                return chapter1;
            case StringType.Chapter2:
                return chapter2;
            case StringType.Chapter3:
                return chapter3;
            default:
                return "NONE";
        }
    }
}
