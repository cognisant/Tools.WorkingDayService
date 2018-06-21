// <copyright file="MondayNonWorkingDayTestSource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;

    /// <inheritdoc />
    internal class MondayNonWorkingDayTestSource : NonWorkingDaySource
    {
        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date) => date.DayOfWeek == DayOfWeek.Monday;
    }
}
