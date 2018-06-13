// <copyright file="TuesdayNonWorkingDayTestSource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.Tests
{
    using System;

    /// <inheritdoc />
    internal sealed class TuesdayNonWorkingDayTestSource : NonWorkingDaySource
    {
        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;
    }
}
