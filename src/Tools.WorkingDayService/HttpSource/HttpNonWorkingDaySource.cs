// <copyright file="HttpNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.HttpSource
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using CR.Tools.WorkingDayService.StringSource;

    /// <inheritdoc cref="StringNonWorkingDaySource{T}" />
    /// <inheritdoc cref="IDisposable"/>
    /// <summary>
    /// An implementation of <see cref="StringNonWorkingDaySource{T}"/> which uses the body content of a <see cref="HttpResponseMessage"/> from sending the provided <see cref="HttpRequestMessage"/> as the source for determining whether a <see cref="DateTime"/> is on a non-Working Day.
    /// </summary>
    public class HttpNonWorkingDaySource<T> : StringNonWorkingDaySource<T>, IDisposable
    {
        private readonly HttpRequestMessage _request;
        private readonly HttpClient _httpClient;
        private readonly Timer _timer;

#pragma warning disable SA1648 // inheritdoc should be used with inheriting class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpNonWorkingDaySource{T}" /> class which builds a state based on the content returned when sending the the provided <see cref="HttpRequestMessage"/>, which is parsed via the provided <c>parseAction</c>.
        /// The built internal state can be used to determine if a given <see cref="DateTime" /> is on a Working Day or Non-Working Day.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to make whose repsonse will be used to build the <see cref="HttpNonWorkingDaySource{T}"/>'s internal state.</param>
        /// <param name="parseAction">The <see cref="Func{TContent, TResult}"/> which the <see cref="HttpResponseMessage"/> from the <see cref="HttpRequestMessage"/> will be passed to, in order to build the <see cref="HttpNonWorkingDaySource{T}" />'s internal state.</param>
        /// <param name="checkAction">The <see cref="Func{TDateTime, TState, TResult}"/> used to to determine whether a provided <see cref="DateTime" /> is on a Working Day or a Non-Working Day, based on the current state of the <see cref="HttpNonWorkingDaySource{T}"/>.
        /// Should return <c>true</c> if the provided <see cref="DateTime" /> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        /// <param name="refreshTimer">The interval at which the <see cref="HttpRequestMessage"/> should be made (on failure, the state will not change).</param>
        public HttpNonWorkingDaySource(HttpRequestMessage request, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction, TimeSpan refreshTimer)
#pragma warning restore SA1648 // inheritdoc should be used with inheriting class
            : base(parseAction, checkAction)
        {
            _timer = new Timer(_ => UpdateState(), null, (int)refreshTimer.TotalMilliseconds, Timeout.Infinite);
            _httpClient = new HttpClient();
            _request = request;
            UpdateState();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient.Dispose();
            _timer.Dispose();
        }

        private void UpdateState()
        {
            try
            {
                State = ParseAction(_httpClient.SendAsync(_request).Result.Content.ReadAsStringAsync().Result);
            }
            catch
            {
                if (State == null)
                {
                    throw;
                }
            }
        }
    }
}
