// <copyright file="GovUkBankHolidayJsonSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.GovUkJsonSource
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using HttpSource;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension Methods for the <see cref="WorkingDayServiceBuilder"/> to use the UK Government Bank Holiday Endpoint.
    /// </summary>
    public static class GovUkBankHolidayJsonSourceExtensions
    {
        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="WorkingDaySource"/> based on the UK's Bank Holidays.
        /// </summary>
        /// <remarks>
        /// The source is based on a <see cref="HttpWorkingDaySource{T}"/> created using the UK Government's Bank Holidays JSON API Endpoint.
        /// </remarks>
        /// <param name="builder">The <see cref="WorkingDayServiceBuilder"/> to configure to use the UK Bank Holidays for Working Day detection.</param>
        /// <param name="refreshTime">The time interval for which the <see cref="WorkingDayService"/> should wait between attempted refreshes of the Bank Holiday list (on failure to update, the state will not change).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using only the UK Bank Holidays <see cref="WorkingDaySource"/>.</returns>
        public static WorkingDayServiceBuilder UseGovUkBankHolidayJsonSource(this WorkingDayServiceBuilder builder, TimeSpan refreshTime)
            => builder.UseSource(GovUkBankHolidayJsonSource(refreshTime));

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use a <see cref="WorkingDaySource"/> based on the UK's Bank Holidays.
        /// </summary>
        /// <remarks>
        /// The source is based on a <see cref="HttpWorkingDaySource{T}"/> created using the UK Government's Bank Holidays JSON API Endpoint.
        /// </remarks>
        /// <param name="builder">The <see cref="WorkingDayServiceBuilder"/> to configure to use the UK Bank Holidays for Working Day detection.</param>
        /// <param name="refreshTime">The time interval for which the <see cref="WorkingDayService"/> should wait between attempted refreshes of the Bank Holiday list (on failure to update, the state will not change).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the UK Bank Holidays <see cref="WorkingDaySource"/> in addition to its current sources.</returns>
        public static WorkingDayServiceBuilder AddGovUkBankHolidayJsonSource(this WorkingDayServiceBuilder builder, TimeSpan refreshTime)
            => builder.AddSource(GovUkBankHolidayJsonSource(refreshTime));

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

        private static WorkingDaySource GovUkBankHolidayJsonSource(TimeSpan refreshTime) => new HttpWorkingDaySource<List<DateTime>>(
            new HttpRequestMessage(HttpMethod.Get, "https://www.gov.uk/bank-holidays.json"),
            GovUkBankHolidayJsonParse,
            (dateTime, list) => !list.Contains(dateTime.Date),
            refreshTime);
    }
}
