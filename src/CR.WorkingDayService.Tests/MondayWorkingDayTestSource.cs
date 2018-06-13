﻿// <copyright file="MondayWorkingDayTestSource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.Tests
{
    using System;

    /// <inheritdoc />
    internal sealed class MondayWorkingDayTestSource : WorkingDaySource
    {
        /// <inheritdoc />
        public override bool IsWorkingDay(DateTime date) => date.DayOfWeek == DayOfWeek.Monday;
    }
}
