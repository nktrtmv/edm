namespace Edm.Entities.Approval.Rules.GenericSubdomain.Extensions.Arrays.Comparers;

public static class ArrayComparer
{
    public static int CompareTo<T>(T[] first, T[] second)
    {
        int result = CompareArray(first, second, (a, b) => Comparer<T>.Default.Compare(a, b));

        return result;
    }

    public static bool Equals<T>(T[] first, T[] second)
    {
        int result = CompareArray(first, second, (a, b) => EqualityComparer<T>.Default.Equals(a, b) ? 0 : 1);

        return result == 0;
    }

    private static int CompareArray<T>(T[] first, T[] second, Func<T, T, int> comparer)
    {
        int result = first.Length.CompareTo(second.Length);

        if (result != 0)
        {
            return result;
        }

        T[] sortedFirst = first.Order().ToArray();
        T[] sortedSecond = second.Order().ToArray();

        for (var i = 0; i < sortedFirst.Length; i++)
        {
            result = comparer.Invoke(sortedFirst[i], sortedSecond[i]);

            if (result != 0)
            {
                return result;
            }
        }

        return result;
    }
}
