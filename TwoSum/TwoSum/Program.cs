// See https://aka.ms/new-console-template for more information
using TwoSum;

Solution solution = new Solution();

int[] test1 = solution.TwoSumBruteForce(new int[] { 2, 7, 11, 15 }, 9);
var test2 = solution.TwoSumBruteForce(new int[] { 3, 2, 4 }, 6);
var test3 = solution.TwoSumBruteForce(new int[] { 3, 3 }, 6);

Console.WriteLine($"{test1[0]}, {test1[1]} ");
Console.WriteLine($"{test2[0]}, {test2[1]} ");
Console.WriteLine($"{test3[0]}, {test3[1]} ");

var test4 = solution.TwoSumTwoPointers(new int[] { 2, 7, 11, 15 }, 9);
var test5 = solution.TwoSumTwoPointers(new int[] { 3, 2, 4 }, 6);
var test6 = solution.TwoSumTwoPointers(new int[] { 3, 3 }, 6);

Console.WriteLine($"{test4[0]}, {test4[1]} ");
Console.WriteLine($"{test5[0]}, {test5[1]} ");
Console.WriteLine($"{test6[0]}, {test6[1]} ");

var test7 = solution.TwoSumHashMap(new int[] { 2, 7, 11, 15 }, 9);
var test8 = solution.TwoSumHashMap(new int[] { 3, 2, 4 }, 6);
var test9 = solution.TwoSumHashMap(new int[] { 3, 3 }, 6);

Console.WriteLine($"{test7[0]}, {test7[1]} ");
Console.WriteLine($"{test8[0]}, {test8[1]} ");
Console.WriteLine($"{test9[0]}, {test9[1]} ");