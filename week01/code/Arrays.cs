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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //
        // Plan:
        // 1. Create a new array of doubles with exactly 'length' slots to hold the results.
        // 2. Walk through each index 'i' of the array from 0 to length - 1.
        // 3. The multiple at position 'i' is 'number' times (i + 1). We add 1 because the
        //    first multiple (index 0) should be 'number' * 1, not 'number' * 0.
        //    Example: MultiplesOf(7, 5) -> index 0 = 7*1, index 1 = 7*2, ... index 4 = 7*5.
        // 4. Store each computed multiple in its slot.
        // 5. After the loop finishes, return the filled array.

        var multiples = new double[length];
        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //
        // Plan (using list slicing):
        // 1. Rotating right by 'amount' means the last 'amount' values wrap around to the front
        //    and everything else shifts to the back.
        //    Example: {1,2,3,4,5,6,7,8,9} rotated right by 3 -> {7,8,9, 1,2,3,4,5,6}.
        //    The last 3 values {7,8,9} move to the front; the first 6 values {1,2,3,4,5,6} follow.
        // 2. Slice out the "tail" = the last 'amount' values. These start at index
        //    (data.Count - amount) and continue for 'amount' values: data.GetRange(data.Count - amount, amount).
        // 3. Slice out the "head" = everything before the tail. It starts at index 0 and
        //    continues for (data.Count - amount) values: data.GetRange(0, data.Count - amount).
        // 4. Rebuild the list in place: clear it, then add the tail first, then the head.
        //    Because we must modify the existing 'data' list (not return a new one), we
        //    Clear() it and AddRange() the two slices back in the rotated order.

        var tail = data.GetRange(data.Count - amount, amount);   // last 'amount' values that wrap to the front
        var head = data.GetRange(0, data.Count - amount);        // the remaining values that move to the back
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
