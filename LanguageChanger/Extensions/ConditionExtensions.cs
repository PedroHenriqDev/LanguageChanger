namespace LanguageChanger.Extensions;

public static class ConditionExtensions
{
    public static T ExecuteIf<T>(this T value, bool condition, Func<T> func) 
    {
        if (condition)
            return func();

        return value;
    }
}
