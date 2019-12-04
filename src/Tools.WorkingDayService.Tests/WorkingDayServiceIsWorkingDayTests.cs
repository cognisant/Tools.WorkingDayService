// <copyright file="WorkingDayServiceIsWorkingDayTests.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace CorshamScience.Tools.WorkingDayService.Tests
{
    using System;
    using CorshamScience.Tools.WorkingDayService.DayOfTheWeekSource;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the Working Day Service's IsWorkingDay method.
    /// </summary>
    [TestFixture]
    public class WorkingDayServiceIsWorkingDayTests
    {
        /// <summary>
        /// Test to check that a Working Day Service which has no sources considers any Day a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithNoSourcesThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() =>
            { // ReSharper disable once UnusedVariable
                CorshamScience.Tools.WorkingDayService.WorkingDayService workingDayService = WorkingDayServiceBuilder.New();
            });

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a Working Day a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsTrueWhenIsWorkingDayIsCalledOnAWorkingDay()
            => Assert.IsTrue(((CorshamScience.Tools.WorkingDayService.WorkingDayService)WorkingDayServiceBuilder.New().AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Monday))
                .IsWorkingDay(new DateTime(2018, 5, 15)));

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a non-Working Day a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsFalseWhenIsWorkingDayIsCalledOnANonWorkingDay()
            => Assert.IsTrue(((CorshamScience.Tools.WorkingDayService.WorkingDayService)WorkingDayServiceBuilder.New().AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Monday))
                .IsNonWorkingDay(new DateTime(2018, 5, 14)));

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources considers a date which is a Non-Working Day according to any of its sources a Non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsTrueForAnyDayConsideredAWorkingDayByAtLeastOneSourcePassedToIsNonWorkingDay()
        {
            CorshamScience.Tools.WorkingDayService.WorkingDayService workingDayService = WorkingDayServiceBuilder.New()
                .AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Monday)
                .AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Tuesday);

            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 14)));
            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 15)));
        }

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources considers a date which is a Working Day according to all of its sources a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsFalseForAnyDayConsideredAWorkingDayByAtLeastOneSourcePassedToIsWorkingDay()
        {
            CorshamScience.Tools.WorkingDayService.WorkingDayService workingDayService = WorkingDayServiceBuilder.New()
                .AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Monday)
                .AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Tuesday);

            Assert.IsTrue(workingDayService.IsWorkingDay(new DateTime(2018, 5, 16)));
            Assert.IsTrue(workingDayService.IsWorkingDay(new DateTime(2018, 5, 17)));
        }
    }
}
