using System;
using System.Collections.Generic;

namespace secondTaskNamespace

{
public class secondTaskProgram
{
    public static List<int> FlattenArray(List<object> array)
    {
        List<int> flattened = new List<int>();

        foreach (var item in array)
        {
            if (item is int)
            {
                flattened.Add((int)item);
            }
            else if (item is List<object>)
            {
                flattened.AddRange(FlattenArray((List<object>)item));
            }
        }

        return flattened;
    }

    public static void secondTaskMain(string[] args)
    {
        List<object> nestedArray = new List<object>
        {
            435,
            2028,
            new List<object>
            {
                new List<object> { 3047, 4910, 8146, 7999, 1433, 7211, 1197, 6002 },
                2821,
                3508
            }
        };

        List<int> flattenedArray = FlattenArray(nestedArray);

        Console.WriteLine("Flattened Array:");
        Console.WriteLine("[ " + string.Join(", ", flattenedArray) + " ]");
    }
}

}