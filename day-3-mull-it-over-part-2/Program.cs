// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));

var regex = new Regex("(?:mul\\((\\d{1,3}),(\\d{1,})\\)|do\\(\\)|don't\\(\\))");

var matches = regex.Matches(input);

IEnumerable<Match> leftover = matches;
var enabledList = new List<Match>();
bool enabled = true;
while (leftover.Any())
{
    if (enabled)
    {
        enabledList.AddRange(leftover.TakeWhile(x=> x.Value != "don't()"));
        leftover = leftover.SkipWhile(x => x.Value != "don't()").ToList();
        enabled = false;
    }
    else
    {
        leftover = leftover.SkipWhile(x => x.Value != "do()").ToList();
        enabled = leftover.Any();
    }
}

var mulList = enabledList.Where(x => x.Value.Contains("mul"));

var sum = mulList.Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
    .Sum();

Console.WriteLine($"The total sum is: {sum}");  