// <copyright file="TuesdayNonWorkingDayTestSource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;

    /// <inheritdoc />
    internal class TuesdayNonWorkingDayTestSource : NonWorkingDaySource
    {
        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;
    }
}
