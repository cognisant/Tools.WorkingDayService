// <copyright file="WorkingDayServiceIsWorkingDayTests.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;
    using System.Collections.Generic;
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
        public static void WorkingDayServiceWithNoSourcesReturnsAnyDayAsWorkingDay() => Assert.IsTrue(new WorkingDayService(new List<NonWorkingDaySource>()).IsWorkingDay(DateTime.Now));

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a Working Day a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsTrueWhenIsWorkingDayIsCalledOnAWorkingDay() => Assert.IsTrue(new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource() }).IsWorkingDay(new DateTime(2018, 5, 15)));

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a non-Working Day a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsFalseWhenIsWorkingDayIsCalledOnANonWorkingDay() => Assert.IsTrue(new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource() }).IsNonWorkingDay(new DateTime(2018, 5, 14)));

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources considers a date which is a Non-Working Day according to any of its sources a Non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsTrueForAnyDayConsideredAWorkingDayByAtLeastOneSourcePassedToIsNonWorkingDay()
        {
            var workingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });
            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 14)));
            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 15)));
        }

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources considers a date which is a Working Day according to all of its sources a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsFalseForAnyDayConsideredAWorkingDayByAtLeastOneSourcePassedToIsWorkingDay()
        {
            var workingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });
            Assert.IsTrue(workingDayService.IsWorkingDay(new DateTime(2018, 5, 16)));
            Assert.IsTrue(workingDayService.IsWorkingDay(new DateTime(2018, 5, 17)));
        }
    }
}
