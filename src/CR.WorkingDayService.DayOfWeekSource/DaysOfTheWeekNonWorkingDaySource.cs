// <copyright file="DaysOfTheWeekNonWorkingDaySource.cs" company="Cognisant">
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
    public class DaysOfTheWeekNonWorkingDaySource : NonWorkingDaySource
    {
        private readonly HashSet<DayOfWeek> _nonWorkingDays;

        /// <summary>
        /// Initializes a new instance of the <see cref="DaysOfTheWeekNonWorkingDaySource"/> class, which considers each <see cref="DayOfWeek"/> contained in the provided <see cref="IEnumerable{T}"/> as a Non-Working Day.
        /// </summary>
        /// <param name="nonWorkingDays">The days to consider Non-Working Days.</param>
        public DaysOfTheWeekNonWorkingDaySource(IEnumerable<DayOfWeek> nonWorkingDays) => _nonWorkingDays = new HashSet<DayOfWeek>(nonWorkingDays);

        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date) => _nonWorkingDays.Contains(date.DayOfWeek);
    }
}
