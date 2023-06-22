﻿using SFR.TemplateGenerator.Models;
using SFR.TemplateGenerator.Parsers;

namespace SFR.TemplateRandomizer.TypeGenerators;

internal class IntegerGenerator : TypeRandomGenerator
{
    private readonly int min;
    private readonly int max;

    private readonly IArgumentParser<(int, int)> argumentParser = new IntegerRangeParser();

    public IntegerGenerator(Random random, RangeSegment range)
        : base(random)
    {
        (min, max) = argumentParser.Parse(range);
    }

    public override object Execute() => Random.Next(min, max);
}