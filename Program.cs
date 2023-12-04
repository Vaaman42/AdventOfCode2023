using AdventOfCode2023;

while (true)
{
    Console.WriteLine("Enter day number ");
    var day = Console.ReadLine();
    switch (day)
    {
        case "1":
            Day1();
            break;
        default:
            Console.WriteLine("Error, try again.");
            break;
    }
}

void Day1()
{
    Console.WriteLine("Enter input\nEnter \"END\" when finished.");

    int calibrationSumPart1 = 0, calibrationSumPart2 = 0;
    var input = Console.ReadLine();
    do
    {
        int digitTenthPart1 = 0, digitUnitsPart1 = 0;
        digitTenthPart1 = input!.Where(i => int.TryParse(i.ToString(), out _)).Select(i => int.Parse(i.ToString())).First();
        digitUnitsPart1 = input!.Where(i => int.TryParse(i.ToString(), out _)).Select(i => int.Parse(i.ToString())).Last();
        calibrationSumPart1 += (digitTenthPart1 * 10) + digitUnitsPart1;
        
        int digitTenthPart2 = 0, digitUnitsPart2 = 0;
        var modifiedInput = input!
            .Replace("nine", "nine9nine")
            .Replace("eight", "eight8eight")
            .Replace("seven", "seven7seven")
            .Replace("six", "six6six")
            .Replace("five", "five5five")
            .Replace("four", "four4four")
            .Replace("three", "three3three")
            .Replace("two", "two2two")
            .Replace("one", "one1one")
            .Replace("zero", "zero0zero");
        
        digitTenthPart2 = modifiedInput.Where(i => int.TryParse(i.ToString(), out _)).Select(i => int.Parse(i.ToString())).First();
        digitUnitsPart2 = modifiedInput.Where(i => int.TryParse(i.ToString(), out _)).Select(i => int.Parse(i.ToString())).Last();
        calibrationSumPart2 += (digitTenthPart2 * 10) + digitUnitsPart2;
        
        input = Console.ReadLine();
    } while (input != "END");

    Console.WriteLine("PART1: " + calibrationSumPart1);
    Console.WriteLine("PART2: " + calibrationSumPart2);
}