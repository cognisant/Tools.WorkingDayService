// <copyright file="GovUkBankHolidayJsonSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.HttpSource.GovUkJsonSource
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension Methods for the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="HttpNonWorkingDaySource{T}"/>, which uses the UK Government's Bank Holiday JSON API to determine whether a given day is a non-working day.
    /// </summary>
    public static class GovUkBankHolidayJsonSourceExtensions
    {
        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="NonWorkingDaySource"/> based on the UK's Bank Holidays, as well as any previously configured sources.
        /// </summary>
        /// <remarks>
        /// The source is based on a <see cref="HttpNonWorkingDaySource{T}"/> created using the UK Government's Bank Holidays JSON API.
        /// </remarks>
        /// <param name="builder">The <see cref="WorkingDayServiceBuilder"/> to configure to use UK Bank Holidays for Non-Working Day detection.</param>
        /// <param name="refreshTime">The amount of time the <see cref="WorkingDayService"/> should wait between attempted refreshes of the Bank Holiday list (on failure to update, the state will not change).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the UK Bank Holidays <see cref="NonWorkingDaySource"/>, as well as any previously configured sources.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddGovUkBankHolidayJsonSource(this WorkingDayServiceBuilder builder, TimeSpan refreshTime)
            => builder.WithSource(GovUkBankHolidayJsonSource(refreshTime));

        /// <summary>
        /// Parses bank holiday dates from a UK Government Bank Holiday JSON <see cref="string"/>.
        /// </summary>
        /// <param name="json">The JSON content.</param>
        /// <returns>A list of <see cref="DateTime.Date"/>s that are bank holidays (Non-Working Days).</returns>
        public static List<DateTime> GovUkBankHolidayJsonParse(string json)
        {
            var jobject = JObject.Parse(json);
            return jobject["england-and-wales"]["events"]?.Select(e => e["date"].ToObject<DateTime>().Date).ToList();
        }

        private static NonWorkingDaySource GovUkBankHolidayJsonSource(TimeSpan refreshTime) => new HttpNonWorkingDaySource<List<DateTime>>(
            new HttpRequestMessage(HttpMethod.Get, "https://www.gov.uk/bank-holidays.json"),
            GovUkBankHolidayJsonParse,
            (dateTime, list) => list.Contains(dateTime.Date),
            refreshTime);
    }
}
