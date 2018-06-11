// <copyright file="IWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System;

    /// <summary>
    /// A common interface for implementing a Source of information on days' working/non-working status.
    /// </summary>
    public interface IWorkingDaySource
    {
        /// <summary>
        /// Checks <see cref="IWorkingDaySource"/>s to determine if a particular <see cref="DateTime"/> is on a Working Day.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> who's working/non-working status needs to be checked.</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Working Day, and <c>false</c> if it is on a Non-Working Day.</returns>
        bool IsWorkingDay(DateTime date);
    }
}
