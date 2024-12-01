// See https://aka.ms/new-console-template for more information

var lines = File.ReadLines(Path.Combine(Environment.CurrentDirectory, "input.txt"));

var splitLines = lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();

var leftList = splitLines.Select(x => int.Parse(x[0].Trim())).Order();
var rightList = splitLines.Select(x => int.Parse(x[1].Trim())).Order();

var combinedList = leftList.Zip(rightList);

var distances = combinedList.Select(row => row.First - row.Second).Select(Math.Abs);

var totalDistance = distances.Sum();

Console.WriteLine($"The total distance is: {totalDistance}");