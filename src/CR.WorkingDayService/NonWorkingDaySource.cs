// <copyright file="NonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System;

    /// <summary>
    /// An <see cref="object"/> which, given a <see cref="DateTime"/>, returns whether it is on a working day, or a non-working day.
    /// </summary>
    public abstract class NonWorkingDaySource
    {
        /// <summary>
        /// Checks whether the provided <see cref="DateTime"/> is on a Non-Working Day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to check is on a non-working day.</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day</returns>
        public abstract bool IsNonWorkingDay(DateTime date);

        /// <summary>
        /// Checks whether the provided <see cref="DateTime"/> is on a Working Day.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to check is on a working day.</param>
        /// <returns><c>true</c> if the provided <see cref="DateTime"/> is on a Working Day, and <c>false</c> if it is on a Non-Working Day.</returns>
        public virtual bool IsWorkingDay(DateTime date) => !IsNonWorkingDay(date);
    }
}
