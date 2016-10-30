using System.Linq;

namespace Solutions
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/ctci-array-left-rotation
    /// Given an array of integers and a number, , perform  left rotations on the array. Then print the updated array as a single line of space-separated integers.
    /// </summary>
    public class LeftRotation
    {
        public static int[] LeftRotate(int[] array, int numLeftRotations)
        {
            return Enumerable.Range(0, array.Length)
                .Select(i => (i + numLeftRotations) % array.Length)
                .Select(i => array[i]).ToArray();
        }
    }
}
