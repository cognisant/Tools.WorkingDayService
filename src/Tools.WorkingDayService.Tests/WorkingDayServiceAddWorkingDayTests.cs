﻿// <copyright file="WorkingDayServiceAddWorkingDayTests.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for adding working days to a Working Day via the Working Day Service.
    /// </summary>
    [TestFixture]
    public class WorkingDayServiceAddWorkingDayTests
    {
        private static readonly WorkingDayService WorkingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });

        /// <summary>
        /// Test to ensure that NextWorkingDay returns the correct DateTime (next working day date).
        /// </summary>
        [Test]
        public static void NextWorkingDayReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.NextWorkingDay(new DateTime(2018, 5, 18, 9, 30, 0)), new DateTime(2018, 5, 19));
            Assert.AreEqual(WorkingDayService.NextWorkingDay(new DateTime(2018, 5, 14, 10, 30, 55)), new DateTime(2018, 5, 16));
        }

        /// <summary>
        /// Test to ensure that AddWorkingDays returns the correct DateTime (next working day date) when passed 0.
        /// </summary>
        [Test]
        public static void Add0WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.AddWorkingDays(0, new DateTime(2018, 5, 14, 9, 30, 0)), new DateTime(2018, 5, 14));
            Assert.AreEqual(WorkingDayService.AddWorkingDays(0, new DateTime(2018, 5, 16, 10, 30, 55)), new DateTime(2018, 5, 16));
        }

        /// <summary>
        /// Test to ensure that AddWorkingDays returns the correct DateTime (next working day date) when passed 1.
        /// </summary>
        [Test]
        public static void Add1WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.AddWorkingDays(1, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 17));
            Assert.AreEqual(WorkingDayService.AddWorkingDays(1, new DateTime(2018, 5, 14, 10, 30, 55)), new DateTime(2018, 5, 17));
        }

        /// <summary>
        /// Test to ensure that AddWorkingDays returns the correct DateTime (next working day date) when passed 2.
        /// </summary>
        [Test]
        public static void Add2WorkingDaysReturnsCorrectDay()
        {
            Assert.AreEqual(WorkingDayService.AddWorkingDays(2, new DateTime(2018, 5, 16, 9, 30, 0)), new DateTime(2018, 5, 18));
            Assert.AreEqual(WorkingDayService.AddWorkingDays(2, new DateTime(2018, 5, 14, 10, 30, 55)), new DateTime(2018, 5, 18));
        }
    }
}
