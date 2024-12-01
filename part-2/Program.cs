// See https://aka.ms/new-console-template for more information

using System.Drawing;

var lines = File.ReadLines(Path.Combine(Environment.CurrentDirectory, "input.txt"));

var splitLines = lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

var leftList = splitLines.Select(x => int.Parse(x[0].Trim())).ToList();
var rightList = splitLines.Select(x => int.Parse(x[1].Trim()));

var similarityList = leftList.Select(num => rightList.Count(x => x == num));

var totalSimilarity = leftList.Zip(similarityList).Select(row => row.First * row.Second).Sum();

Console.WriteLine($"The total similarity is: {totalSimilarity}");