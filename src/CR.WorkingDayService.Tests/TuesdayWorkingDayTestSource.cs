// <copyright file="TuesdayWorkingDayTestSource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.Tests
{
    using System;

    /// <inheritdoc />
    internal sealed class TuesdayWorkingDayTestSource : WorkingDaySource
    {
        /// <inheritdoc />
        public override bool IsWorkingDay(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;
    }
}
