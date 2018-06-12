// <copyright file="WorkingDaySourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System;

    /// <summary>
    /// Extension methods for the <see cref="IWorkingDaySource"/> interface.
    /// </summary>
    public static class WorkingDaySourceExtensions
    {
        /// <summary>
        /// Checks the <see cref="IWorkingDaySource"/> to determine if a <see cref="DateTime"/> is on a Non-Working Day.
        /// </summary>
        /// <param name="source">The <see cref="IWorkingDaySource"/> to use.</param>
        /// <param name="date">The <see cref="DateTime"/> to check is on a Non-Working Day.</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day according to the source, and <c>false</c> if it is on a Working Day</returns>
        public static bool IsNonWorkingDay(this IWorkingDaySource source, DateTime date) => !source.IsWorkingDay(date);
    }
}
