// <copyright file="DaysOfTheWeekSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.DayOfTheWeekSource
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A helper class containing extension methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class DaysOfTheWeekSourceExtensions
    {
        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/> which considers the provided days to be Non-Working days, as well as any previously configured sources.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="workingDays">The days to consider Non-Working Days.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="DaysOfTheWeekNonWorkingDaySource"/> configured with the provided days, as well as any previously configured <see cref="NonWorkingDaySource"/>s.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddDaysOfTheWeekNonWorkingDaySource(this WorkingDayServiceBuilder builder, IEnumerable<DayOfWeek> workingDays) => builder.WithSource(new DaysOfTheWeekNonWorkingDaySource(workingDays));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="DaysOfTheWeekNonWorkingDaySource"/> which considers Monday -> Friday Working Days, and Saturday and Sunday to be Non-Working Days, as well as any previously configured <see cref="NonWorkingDaySource"/>s.
        /// </summary>
        /// <param name="builder">The Builder to configure.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> with the new <see cref="DaysOfTheWeekNonWorkingDaySource"/> added.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddWeekendNonWorkingDaySource(this WorkingDayServiceBuilder builder) => builder.WithSource(new DaysOfTheWeekNonWorkingDaySource(new HashSet<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday }));
    }
}
