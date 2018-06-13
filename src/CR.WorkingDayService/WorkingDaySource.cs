// <copyright file="WorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System;

    /// <summary>
    /// Methods for implementing a source of information on days' working/non-working status.
    /// </summary>
    public abstract class WorkingDaySource
    {
        /// <summary>
        /// Checks <see cref="WorkingDaySource"/>s to determine if a particular <see cref="DateTime"/> is on a Working Day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to check (is it on a Working Day?)</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Working Day, and <c>false</c> if it is on a Non-Working Day.</returns>
        public abstract bool IsWorkingDay(DateTime date);

        /// <summary>
        /// Checks <see cref="WorkingDaySource"/>s to determine if a <see cref="DateTime"/> is on a Non-Working Day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to check (is it on a Non-Working Day?)</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day</returns>
        public bool IsNonWorkingDay(DateTime date) => !IsWorkingDay(date);
    }
}
