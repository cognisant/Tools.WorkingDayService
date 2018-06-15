// <copyright file="HttpNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.HttpSource
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using StringSource;

    /// <inheritdoc cref="StringNonWorkingDaySource{T}" />
    /// <inheritdoc cref="IDisposable"/>
    /// <summary>
    /// An implementation of <see cref="StringNonWorkingDaySource{T}"/> which uses the returned content of a HTTP Endpoint as the source for determining if a <see cref="DateTime"/> is on a non-Working Day.
    /// </summary>
    public sealed class HttpNonWorkingDaySource<T> : StringNonWorkingDaySource<T>, IDisposable
    {
        private readonly HttpRequestMessage _request;
        private readonly HttpClient _httpClient;
        private readonly Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpNonWorkingDaySource{T}"/> class which builds a state based on the content returned by the provided <see cref="HttpRequestMessage"/> which is parsed via the provided <c>parseAction</c>.
        /// The built internal state can be used to determine if a given <see cref="DateTime"/> is on a Working Day or Non-Working Day.
        /// </summary>
        /// <param name="request">The HTTP Request to make who's repsonse will be used to build the <see cref="HttpNonWorkingDaySource{T}"/>'s internal state.</param>
        /// <param name="parseAction">The Action which the response from the HTTP endpoint will be passed to, in order to build the<see cref="HttpNonWorkingDaySource{T}"/>'s internal state.</param>
        /// <param name="checkAction">The Action used to to determine if a given <see cref="DateTime"/> is a Working Day or a Non-Working Day.
        /// Should return <c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        /// <param name="refreshTimer">The interval of time that should be left between attempts to update the state by making the request again (on failure to update, the state will not change).</param>
        public HttpNonWorkingDaySource(HttpRequestMessage request, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction, TimeSpan refreshTimer)
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
