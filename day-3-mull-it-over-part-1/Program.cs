// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));

var regex = new Regex("mul\\((\\d{1,3}),(\\d{1,})\\)");

var matches = regex.Matches(input);

var sum = matches.Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
    .Sum();

Console.WriteLine($"The total sum is: {sum}");