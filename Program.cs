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
        case "3":
            Day3();
            break;
        default:
            Console.WriteLine("Error, try again.");
            break;
    }
}

void Day3()
{
    Console.WriteLine("Enter input\nEnter \"END\" when finished.");
    
    var list = new List<string>();
    var input = Console.ReadLine();
    
    do
    {
        list.Add(input);
        input = Console.ReadLine();
    } while (input != "END");

    var matrix = list.Select(x => x.ToCharArray()).ToArray();
    var partSum = 0;
    
    var gears = new Dictionary<(int, int), Gear>();
    
    //Part 1
    for (var y = 0; y < matrix.Length; y++)
    {
        for (var x = 0; x < matrix[y].Length; x++)
        {
            if (int.TryParse(matrix[y][x].ToString(), out var numericValue))
            {
                var endingX = x;
                var tmpX = x;
                while (tmpX + 1 < matrix[y].Length && int.TryParse(matrix[y][++tmpX].ToString(), out var numericValue2))
                {
                    numericValue *= 10;
                    numericValue += numericValue2;
                    endingX = tmpX;
                }

                var isPart = false;

                int minY = y, maxY = y, minX = x, maxX = endingX;
                if (minY != 0) // Check upper line for symbols
                {
                    minY -= 1;
                }

                if (maxY != matrix.Length - 1) // Check lower line for symbols
                {
                    maxY += 1;
                }

                if (minX != 0) // Check left line for symbols
                {
                    minX -= 1;
                }

                if (maxX != matrix[y].Length - 1) // Check right line for symbols
                {
                    maxX += 1;
                }

                for (var i = minY; i <= maxY; i++)
                {
                    for (var j = minX; j <= maxX; j++)
                    {
                        if (matrix[i][j] == '.')
                            continue;
                        if (int.TryParse(matrix[i][j].ToString(), out _))
                            continue;
                        if (matrix[i][j] == '*')
                        {
                            if (!gears.ContainsKey((i, j)))
                                gears.Add((i, j), new Gear());
                            gears[(i, j)].AddValue(numericValue);
                        }
                        isPart = true;
                    }
                }

                if (isPart)
                    partSum += numericValue;

                x = endingX;
            }
        }
    }
    
    //Part 2
    var gearRatioSum = gears.Sum(g => g.Value.GearRatio);
    
    Console.WriteLine("PART1: " + partSum);
    Console.WriteLine("PART2: " + gearRatioSum);
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