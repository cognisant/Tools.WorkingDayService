// <copyright file="WeekendDaysNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.DayOfWeekSource
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// An implementation of <see cref="NonWorkingDaySource"/> which uses the <see cref="DayOfWeek"/> of the provided <see cref="DateTime"/> to determine whether the day is a Working Day or Non-Working Day.
    /// </summary>
    public sealed class WeekendDaysNonWorkingDaySource : NonWorkingDaySource
    {
        private static readonly IEnumerable<DayOfWeek> WeekendDays = new HashSet<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };

        private readonly HashSet<DayOfWeek> _nonWorkingDays;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeekendDaysNonWorkingDaySource"/> class, which considers each <see cref="DayOfWeek"/> contained in the provided <see cref="IEnumerable{T}"/> as a Non-Working Day.
        /// </summary>
        /// <param name="nonWorkingDays">The days to consider Non-Working Days.</param>
        public WeekendDaysNonWorkingDaySource(IEnumerable<DayOfWeek> nonWorkingDays) => _nonWorkingDays = new HashSet<DayOfWeek>(nonWorkingDays);

        /// <summary>
        /// Initializes a new instance of the <see cref="WeekendDaysNonWorkingDaySource"/> class which considers Saturday &amp; Sunday Non-Working Days.
        /// </summary>
        public WeekendDaysNonWorkingDaySource()
            : this(WeekendDays)
        {
        }

        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date) => _nonWorkingDays.Contains(date.DayOfWeek);
    }
}
