// See https://aka.ms/new-console-template for more information

var lines = File.ReadLines(Path.Combine(Environment.CurrentDirectory, "input.txt"));

// convert lines into reports of numbers
var reports = lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
    .Select(report => report.Select(int.Parse).ToArray());

// check for levels with too much variance
var reportsSafe = reports.Where(report =>
{
    var isSafe = (report[0] < report[^1]) switch
    {
        true => report.Order().SequenceEqual(report),
        false => report.OrderDescending().SequenceEqual(report)
    };
    return isSafe;
}).Where(report => report.Index().Take(1..).All(elem =>
{
    return Math.Abs(report[elem.Index - 1] - elem.Item) is <= 3 and >= 1;
}));

Console.WriteLine($"There are {reportsSafe.Count()} reports that are safe.");