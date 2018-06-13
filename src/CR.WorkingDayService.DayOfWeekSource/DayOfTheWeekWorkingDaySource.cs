// <copyright file="DayOfTheWeekWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.DayOfWeekSource
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// An implementation of <see cref="WorkingDaySource"/> which uses the <see cref="DayOfWeek"/> of the provided <see cref="DateTime"/> to determine whether the day is a Working Day or Non-Working Day.
    /// </summary>
    public sealed class DayOfTheWeekWorkingDaySource : WorkingDaySource
    {
        private static readonly IEnumerable<DayOfWeek> WeekDays = new HashSet<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

        private readonly HashSet<DayOfWeek> _workingDays;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfTheWeekWorkingDaySource"/> class, which considers each <see cref="DayOfWeek"/> contained in the provided <see cref="IEnumerable{T}"/> as a Working Day.
        /// </summary>
        /// <param name="workingDays">The days to consider Working Days.</param>
        public DayOfTheWeekWorkingDaySource(IEnumerable<DayOfWeek> workingDays) => _workingDays = new HashSet<DayOfWeek>(workingDays);

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfTheWeekWorkingDaySource"/> class, which considers Monday -> Friday Working Days, and Saturday &amp; Sunday Non-Working Days.
        /// </summary>
        public DayOfTheWeekWorkingDaySource()
            : this(WeekDays)
        {
        }

        /// <inheritdoc />
        public override bool IsWorkingDay(DateTime date) => _workingDays.Contains(date.DayOfWeek);
    }
}
