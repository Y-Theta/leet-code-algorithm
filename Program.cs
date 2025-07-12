// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var count = new Solution().Candy(new int[] { 1,3,2,2,1 });
var count1 = new Solution().Candy(new int[] { 1,2,3,1,0 });
Debug.WriteLine($"{count} {count1}");