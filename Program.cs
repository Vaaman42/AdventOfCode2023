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
        case "2":
            Day2();
            break;
        default:
            Console.WriteLine("Error, try again.");
            break;
    }
}

void Day2()
{
    Console.WriteLine("Enter input\nEnter \"END\" when finished.");
    var input = Console.ReadLine();
    var idSum = 0;
    int powerSum = 0;
    int maxRed = 12, maxGreen = 13, maxBlue = 14;
    do
    {
        // Id is the first number found
        var gameSplit = input!.Split(": ");
        var id = int.Parse(gameSplit[0].Split(' ')[1]);
        var sets = gameSplit[1].Split("; ");
        bool isRoundPossible = true;
        int minRed = 0, minGreen = 0, minBlue = 0;
        foreach (var set in sets)
        {
            var dices = set.Split(", ");
            foreach (var dice in dices)
            {
                var split = dice.Split(' ');
                var count = int.Parse(split[0]);
                switch (split[1])
                {
                    case "red":
                        if (count > maxRed)
                            isRoundPossible = false;
                        if (count > minRed)
                            minRed = count;
                        break;
                    case "green":
                        if (count > maxGreen)
                            isRoundPossible = false;
                        if (count > minGreen)
                            minGreen = count;
                        break;
                    case "blue":
                        if (count > maxBlue)
                            isRoundPossible = false;
                        if (count > minBlue)
                            minBlue = count;
                        break;
                }
            }
        }

        if (isRoundPossible)
            idSum += id;
        
        var power = minRed * minGreen * minBlue;
        powerSum += power;

        input = Console.ReadLine();
    } while (input != "END");
    
    Console.WriteLine("PART1: " + idSum);
    Console.WriteLine("PART2: " + powerSum);
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