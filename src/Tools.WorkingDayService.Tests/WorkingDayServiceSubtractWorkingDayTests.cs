// <copyright file="WorkingDayServiceSubtractWorkingDayTests.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace CorshamScience.Tools.WorkingDayService.Tests
{
    using System;
    using CorshamScience.Tools.WorkingDayService.DayOfTheWeekSource;
    using NUnit.Framework;

    /// <summary>
    /// Tests for subtracting working days to a Working Day via the Working Day Service.
    /// </summary>
    [TestFixture]
    public class WorkingDayServiceSubtractWorkingDayTests
    {
        private static readonly CorshamScience.Tools.WorkingDayService.WorkingDayService WorkingDayService =
            WorkingDayServiceBuilder.New().AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Monday).AddDaysOfTheWeekNonWorkingDaySource(DayOfWeek.Tuesday);

        /// <summary>
        /// Test to ensure that PreviousWorkingDay returns the correct DateTime (previous working day date).
        /// </summary>
        [Test]
        public static void PreviousWorkingDayReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.PreviousWorkingDay(new DateTime(2018, 5, 17, 9, 30, 0)), new DateTime(2018, 5, 16));
            Assert.AreEqual(WorkingDayService.PreviousWorkingDay(new DateTime(2018, 5, 16, 10, 30, 55)), new DateTime(2018, 5, 13));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day date) when passed 0.
        /// </summary>
        [Test]
        public static void Subtract0WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(0, new DateTime(2018, 5, 14, 9, 30, 0)), new DateTime(2018, 5, 14));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(0, new DateTime(2018, 5, 15, 10, 30, 55)), new DateTime(2018, 5, 15));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day date) when passed 1.
        /// </summary>
        [Test]
        public static void Subtract1WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(1, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 13));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(1, new DateTime(2018, 5, 17, 10, 30, 55)), new DateTime(2018, 5, 16));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day date) when passed 2.
        /// </summary>
        [Test]
        public static void Subtract2WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(2, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 12));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(2, new DateTime(2018, 5, 18, 10, 30, 55)), new DateTime(2018, 5, 16));
        }
    }
}
