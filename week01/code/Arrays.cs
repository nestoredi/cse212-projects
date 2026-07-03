using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Initialize a new array of doubles called 'result' with a size equal to the 'length' parameter.
        // 2. Create a loop that iterates from 0 up to 'length - 1' using a loop counter variable (e.g., i).
        // 3. In each iteration, calculate the multiple by multiplying 'number' by (i + 1).
        // 4. Store the calculated multiple into the 'result' array at index i.
        // 5. After the loop finishes, return the completed 'result' array.

        // 1. Initialize the array
        double[] result = new double[length];

        // 2. Loop through the length of the array
        for (int i = 0; i < length; i++)
        {
            // 3 & 4. Calculate the multiple and store it at index i
            result[i] = number * (i + 1);
        }

        // 5. Return the array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Calculate the starting split index of the segment that needs to move to the front (data.Count - amount).
        // 2. Extract this segment from the end of the list using GetRange() and store it in a temporary list.
        // 3. Remove the extracted segment from its original position at the end of the list using RemoveRange().
        // 4. Insert the temporary list containing the segment at the very beginning (index 0) of the list using InsertRange().

        // 1. Calculate the index where the split happens
        int splitIndex = data.Count - amount;

        // 2. Get the range of numbers from the split index to the end of the list
        List<int> rotatedSegment = data.GetRange(splitIndex, amount);

        // 3. Remove those numbers from the back of the original list
        data.RemoveRange(splitIndex, amount);

        // 4. Insert the removed numbers at the front (index 0) of the list
        data.InsertRange(0, rotatedSegment);
    }
}
