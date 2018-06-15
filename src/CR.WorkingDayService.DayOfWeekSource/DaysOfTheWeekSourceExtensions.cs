// <copyright file="DaysOfTheWeekSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.DayOfWeekSource
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An Extension Methods class containing methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use <see cref="DaysOfTheWeekNonWorkingDaySource"/>s.
    /// </summary>
    public static class DaysOfTheWeekSourceExtensions
    {
        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/> which considers the provided days to be Working days, in addition to its current sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="workingDays">The days to consider Working Days.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new <see cref="DaysOfTheWeekNonWorkingDaySource"/> configured with the provided days.</returns>
        public static WorkingDayServiceBuilder AddDaysOfTheWeekNonWorkingDaySource(this WorkingDayServiceBuilder builder, IEnumerable<DayOfWeek> workingDays) => builder.WithSource(new DaysOfTheWeekNonWorkingDaySource(workingDays));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/> which considers Monday -> Friday Working Days, in addition to its current sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> with the new Monday -> Friday <see cref="DaysOfTheWeekNonWorkingDaySource"/> added.</returns>
        public static WorkingDayServiceBuilder AddMondayToFridayDaysOfTheWeekNonWorkingDaySource(this WorkingDayServiceBuilder builder) =>
            builder.WithSource(new DaysOfTheWeekNonWorkingDaySource(new HashSet<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Tuesday, DayOfWeek.Friday }));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/> which considers Monday -> Friday Working Days, in addition to its current sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> with the weekend <see cref="DaysOfTheWeekNonWorkingDaySource"/> added.</returns>
        public static WorkingDayServiceBuilder AddWeekendDaysOfTheWeekNonWorkingDaySource(this WorkingDayServiceBuilder builder) => builder.WithSource(new DaysOfTheWeekNonWorkingDaySource(new HashSet<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday }));
    }
}
