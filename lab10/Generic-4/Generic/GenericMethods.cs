using System;
using System.Collections.Generic;
using System.Linq;

public static class GenericMethods
{
    // 1. Method to swap values of two parameters of the same type
    public static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }

    // 2. Method accepting two parameters of different types
    public static void DisplayAndReset<T1, T2>(T1 param1, T2 param2)
    {
        Console.WriteLine($"Type of param1: {typeof(T1).Name}");
        Console.WriteLine($"Type of param2: {typeof(T2).Name}");
        Console.WriteLine($"Value of param1: {param1}");
        Console.WriteLine($"Value of param2: {param2}");

        param1 = default(T1);
        param2 = default(T2);
    }

    // 3. Method returning new object of specified type
    public static T CreateNew<T>() where T : new()
    {
        return new T();
    }

    // 4. Method returning larger of two parameters
    public static T GetLarger<T>(T first, T second) where T : IComparable<T>
    {
        return first.CompareTo(second) > 0 ? first : second;
    }

    // 5. Method returning sorted list of parameters
    public static List<T> GetSortedList<T>(params T[] items) where T : IComparable<T>
    {
        List<T> list = new List<T>(items);
        list.Sort();
        return list;
    }

    // 6. Method creating dictionary with single entry
    public static Dictionary<TKey, TValue> CreateDictionary<TKey, TValue>(TKey key, TValue value)
        where TKey : struct
        where TValue : class
    {
        Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
        dict.Add(key, value);
        return dict;
    }

    // 7. Method to display dictionary elements
    public static void DisplayDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
    {
        foreach (var kvp in dict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    // 8. Method returning queue or stack based on parameter count
    public static IEnumerable<T> CreateCollection<T>(params T[] items)
    {
        if (items.Length < 3)
        {
            Queue<T> queue = new Queue<T>(items);
            return queue;
        }
        else
        {
            Stack<T> stack = new Stack<T>(items);
            return stack;
        }
    }
}