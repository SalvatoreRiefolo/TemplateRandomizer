﻿using SFR.TemplateRandomizer.Parsers;

namespace SFR.TemplateRandomizer.TypeGenerator
{
    public class DateGenerator : TypeGenerator
    {
        private readonly DateTimeOffset min;
        private readonly DateTimeOffset max;

        private readonly IArgumentParser<(DateTimeOffset, DateTimeOffset)> argumentParser = new DateRangeParser();
        private readonly string formatting;

        public DateGenerator(Random random, string args, string formatting = "yyyy-MM-ddThh:mm:ssZ")
            : base(random)
        {
            (min, max) = this.argumentParser.Parse(args);
            this.formatting = formatting;
        }

        public override object Execute()
        {
            var range = this.max - this.min;

            var randTimeSpan = new TimeSpan((long)(base.random.NextDouble() * range.Ticks));

            return (this.min + randTimeSpan).ToString(formatting);
        }
    }
}
