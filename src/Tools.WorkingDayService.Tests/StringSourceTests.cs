// <copyright file="StringSourceTests.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using StringSource;

    /// <summary>
    /// Tests for the String Working Day Source.
    /// </summary>
    [TestFixture]
    public class StringSourceTests
    {
        private static readonly WorkingDayService WorkingDayService = WorkingDayServiceBuilder.New().AddStringSource("2018/05/14,2018/05/15", ParseMethod, CheckMethod);

        /// <summary>
        /// Checks that a Working Day Service with a String Source's IsWorkingDay method returns true when passed a working day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithStringSourceReturnsTrueWhenIsWorkingDayIsCalledWithWorkingDay()
            => Assert.IsTrue(WorkingDayService.IsWorkingDay(new DateTime(2018, 05, 16)));

        /// <summary>
        /// Checks that a Working Day Service with a String Source's IsWorkingDay method returns false when passed a non-working day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithStringSourceReturnsTrueWhenIsWorkingDayIsCalledWithNonWorkingDay()
            => Assert.IsFalse(WorkingDayService.IsWorkingDay(new DateTime(2018, 05, 15)));

        private static IReadOnlyList<DateTime> ParseMethod(string value) => value.Split(',').Select(DateTime.Parse).ToList();

        private static bool CheckMethod(DateTime date, IReadOnlyList<DateTime> state) => state.Contains(date);
    }
}
