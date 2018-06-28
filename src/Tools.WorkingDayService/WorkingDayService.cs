// <copyright file="WorkingDayService.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc />
    /// <summary>
    /// A service which can determine whether a given <see cref="DateTime" /> is on a working day or a non-working day.
    /// </summary>
    public class WorkingDayService : NonWorkingDaySource
    {
        private readonly IReadOnlyCollection<NonWorkingDaySource> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayService"/> class using the provided <see cref="NonWorkingDaySource"/>s.
        /// </summary>
        /// <param name="sources">The <see cref="NonWorkingDaySource"/>s to use to determine whether a given <see cref="DateTime"/> is on a working day, or a non-working day.</param>
        internal WorkingDayService(IReadOnlyCollection<NonWorkingDaySource> sources) => _sources = sources;

        /// <inheritdoc />
        /// <summary>
        /// Uses the <see cref="WorkingDayService"/>'s registered <see cref="NonWorkingDaySource"/>s to determine whether a provided <see cref="DateTime"/> is on a non-working day.
        /// </summary>
        /// <returns>
        /// True if any of the sources consider the provided <see cref="DateTime"/> to be on a non-working day; otherwise, returns false.
        /// </returns>
        public override bool IsNonWorkingDay(DateTime date) => _sources?.Any(source => source.IsNonWorkingDay(date)) ?? false;

        /// <inheritdoc />
        /// <summary>
        /// Uses the <see cref="WorkingDayService"/>'s registered <see cref="NonWorkingDaySource"/>s to determine whether a provided <see cref="DateTime"/> is on a working day.
        /// </summary>
        /// <returns>
        /// True if all of the sources consider the provided <see cref="DateTime"/> to be on a working day (or there are no configured <see cref="NonWorkingDaySource"/>s); otherwise, returns false.
        /// </returns>
        public override bool IsWorkingDay(DateTime date) => _sources == null || _sources.Count <= 0 || _sources.All(source => source.IsWorkingDay(date));

        /// <summary>
        /// Gets the next working day after the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to get the next working day after.</param>
        /// <returns>The next working day <see cref="DateTime.Date"/> after the provided <see cref="DateTime"/>.</returns>
        public DateTime NextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            }
            while (IsNonWorkingDay(date));
            return date.Date;
        }

        /// <summary>
        /// Gets the last working day before the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to get the last working day before.</param>
        /// <returns>The last working day <see cref="DateTime.Date"/> before the provided <see cref="DateTime"/>.</returns>
        public DateTime PreviousWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsNonWorkingDay(date));
            return date.Date;
        }

        /// <summary>
        /// Gets the <see cref="DateTime.Date"/> once the provided number of working days have passed after the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="numberToAdd">The number of working days to add to the provided <see cref="DateTime"/>.</param>
        /// <param name="date">The <see cref="DateTime"/> to which working days should be added.</param>
        /// <returns>The <see cref="DateTime.Date"/> after the provided number of working days have passed after the provided <see cref="DateTime"/>.</returns>
        /// <remarks>If the provided <c>numerToAdd</c> is 0, the provided <see cref="DateTime"/>'s <c>.Date</c> property will be returned.</remarks>
        public DateTime AddWorkingDays(uint numberToAdd, DateTime date)
        {
            if (numberToAdd == 0)
            {
                return date.Date;
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
        /// Gets the <see cref="DateTime.Date"/> where the provided number of working days have passed to get to the provided <see cref="DateTime"/>.
        /// </summary>
        /// <param name="numberToSubtract">The number of working days to subtract from the provided <see cref="DateTime"/>.</param>
        /// <param name="date">The <see cref="DateTime"/> which working days should be subtracted from.</param>
        /// <returns>The <see cref="DateTime.Date"/> where the provided number of working days have passed to get to the provided <see cref="DateTime"/>.</returns>
        /// <remarks>If the provided <c>numberToSubtract</c> is 0, the provided <see cref="DateTime"/>'s <c>.Date</c> property will be returned.</remarks>
        public DateTime SubtractWorkingDays(uint numberToSubtract, DateTime date)
        {
            if (numberToSubtract == 0)
            {
                return date.Date;
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
