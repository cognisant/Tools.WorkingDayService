// <copyright file="DayOfTheWeekSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.DayOfWeekSource
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An Extension Methods class containing methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use <see cref="WeekendDaysNonWorkingDaySource"/>s.
    /// </summary>
    public static class DayOfTheWeekSourceExtensions
    {
        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="WeekendDaysNonWorkingDaySource"/> which considers the provided days to be Working days.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="workingDays">The days to consider Working Days.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new <see cref="WeekendDaysNonWorkingDaySource"/> configured with the provided days.</returns>
        public static WorkingDayServiceBuilder UseDayOfTheWeekSource(this WorkingDayServiceBuilder builder, IEnumerable<DayOfWeek> workingDays) => builder.UseSource(new WeekendDaysNonWorkingDaySource(workingDays));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="WeekendDaysNonWorkingDaySource"/> which considers the provided days to be Working Days, in addition to its current sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="workingDays">The days to consider Working Days.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> with the new <see cref="WeekendDaysNonWorkingDaySource"/> configured with the provided days added.</returns>
        public static WorkingDayServiceBuilder AddDayOfTheWeekSource(this WorkingDayServiceBuilder builder, IEnumerable<DayOfWeek> workingDays) => builder.AddSource(new WeekendDaysNonWorkingDaySource(workingDays));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="WeekendDaysNonWorkingDaySource"/> which considers the Monday -> Friday to be Working days.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new Monday -> Friday <see cref="WeekendDaysNonWorkingDaySource"/>.</returns>
        public static WorkingDayServiceBuilder UseMondayToFridayDayOfTheWeekSource(this WorkingDayServiceBuilder builder) => builder.UseSource(new WeekendDaysNonWorkingDaySource());

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="WeekendDaysNonWorkingDaySource"/> which considers Monday -> Friday Working Days, in addition to its current sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> with the new Monday -> Friday <see cref="WeekendDaysNonWorkingDaySource"/> added.</returns>
        public static WorkingDayServiceBuilder AddMondayToFridayDayOfTheWeekSource(this WorkingDayServiceBuilder builder) => builder.AddSource(new WeekendDaysNonWorkingDaySource());
    }
}
