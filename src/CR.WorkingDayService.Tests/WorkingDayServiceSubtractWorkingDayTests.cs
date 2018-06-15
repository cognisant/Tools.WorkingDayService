// <copyright file="WorkingDayServiceSubtractWorkingDayTests.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for subtracting working days to a Working Day via the Working Day Service.
    /// </summary>
    [TestFixture]
    public class WorkingDayServiceSubtractWorkingDayTests
    {
        private static readonly WorkingDayService WorkingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });

        /// <summary>
        /// Test to ensure that PreviousWorkingDay returns the correct DateTime (previous working day with the time preserved).
        /// </summary>
        [Test]
        public static void PreviousWorkingDayReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.PreviousWorkingDay(new DateTime(2018, 5, 17, 9, 30, 0)), new DateTime(2018, 5, 16, 9, 30, 0));
            Assert.AreEqual(WorkingDayService.PreviousWorkingDay(new DateTime(2018, 5, 16, 10, 30, 55)), new DateTime(2018, 5, 13, 10, 30, 55));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day with the time preserved) when passed 0.
        /// </summary>
        [Test]
        public static void Subtract0WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(0, new DateTime(2018, 5, 14, 9, 30, 0)), new DateTime(2018, 5, 14, 9, 30, 0));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(0, new DateTime(2018, 5, 15, 10, 30, 55)), new DateTime(2018, 5, 15, 10, 30, 55));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day with the time preserved) when passed 1.
        /// </summary>
        [Test]
        public static void Subtract1WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(1, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 13, 9, 30, 0));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(1, new DateTime(2018, 5, 17, 10, 30, 55)), new DateTime(2018, 5, 16, 10, 30, 55));
        }

        /// <summary>
        /// Test to ensure that SubtractWorkingDays returns the correct DateTime (previous working day with the time preserved) when passed 2.
        /// </summary>
        [Test]
        public static void Subtract2WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(2, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 12, 9, 30, 0));
            Assert.AreEqual(WorkingDayService.SubtractWorkingDays(2, new DateTime(2018, 5, 18, 10, 30, 55)), new DateTime(2018, 5, 16, 10, 30, 55));
        }
    }
}
