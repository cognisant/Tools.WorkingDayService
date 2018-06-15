// <copyright file="WorkingDayService.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A service which can determine whether a given <see cref="DateTime"/> is on a working day or a non-working day.
    /// </summary>
    public sealed class WorkingDayService : NonWorkingDaySource
    {
        private readonly IReadOnlyCollection<NonWorkingDaySource> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayService"/> class.
        /// </summary>
        /// <param name="sources">The <see cref="NonWorkingDaySource"/>s to use to determine whether a given <see cref="DateTime"/> is on a working day, or a non-working day.</param>
        public WorkingDayService(IReadOnlyCollection<NonWorkingDaySource> sources) => _sources = sources;

        /// <inheritdoc />
        /// <summary>
        /// Uses the <see cref="WorkingDayService"/>'s registered <see cref="NonWorkingDaySource"/>s to determine if a particular <see cref="DateTime"/> is on a non-working day.
        /// If a day according to any registered source is a non-working day, that day will be considered a non-working day.
        /// </summary>
        public override bool IsNonWorkingDay(DateTime date) => _sources.Any(source => source.IsNonWorkingDay(date));

        /// <inheritdoc />
        /// <summary>
        /// Uses the <see cref="WorkingDayService"/>'s registered <see cref="NonWorkingDaySource"/>s to determine if a particular <see cref="DateTime"/> is on a working day.
        /// If a day according to all registered source is a working day, that day will be considered a working day.
        /// </summary>
        public override bool IsWorkingDay(DateTime date) => _sources.All(source => source.IsWorkingDay(date));

        /// <summary>
        /// Gets the next working day after the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> after which the soonest working day should be identified.</param>
        /// <returns>The <see cref="DateTime"/> of the next working day after the provided date.</returns>
        public DateTime NextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            }
            while (IsNonWorkingDay(date));
            return date;
        }

        /// <summary>
        /// Gets the most recent working day from before the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> before which the most recent working day should be identified.</param>
        /// <returns>The <see cref="DateTime"/> of the most recent working day before the provided date.</returns>
        public DateTime PreviousWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsNonWorkingDay(date));
            return date;
        }

        /// <summary>
        /// Gets the date of the day on the provided number of working days after the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="numberToAdd">The number of working days to add to the provided date.</param>
        /// <param name="date">The <see cref="DateTime"/> to which working days should be added.</param>
        /// <returns>The <see cref="DateTime"/> of the day on the provided number of working days after the provided date.</returns>
        public DateTime AddWorkingDays(uint numberToAdd, DateTime date)
        {
            if (numberToAdd == 0)
            {
                return date;
            }

            if (!IsWorkingDay(date))
            {
                numberToAdd++;
            }

            for (var i = 0; i < numberToAdd; i++)
            {
                date = NextWorkingDay(date);
            }

            return date;
        }

        /// <summary>
        /// Gets the date of the day on the provided number of working days before the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="numberToSubtract">The number of working days to subtract from the provided date.</param>
        /// <param name="date">The <see cref="DateTime"/> to subtract working days from.</param>
        /// <returns>The <see cref="DateTime"/> of the day on the provided number of working days before the provided date.</returns>
        public DateTime SubtractWorkingDays(uint numberToSubtract, DateTime date)
        {
            if (numberToSubtract == 0)
            {
                return date;
            }

            if (!IsWorkingDay(date))
            {
                numberToSubtract++;
            }

            for (var i = 0; i < numberToSubtract; i++)
            {
                date = PreviousWorkingDay(date);
            }

            return date;
        }
    }
}
