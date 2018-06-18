// <copyright file="HttpSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.HttpSource
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// A helper class containing extension methods to build a <see cref="WorkingDayService"/> which uses a <see cref="HttpNonWorkingDaySource{T}"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class HttpSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="HttpNonWorkingDaySource{T}"/> in addition to it;s current sources.
        /// </summary>
        /// <typeparam name="T">The Type of the internal state of the <see cref="HttpNonWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The <see cref="WorkingDayServiceBuilder"/> to configure.</param>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to make to update the internal state of the <see cref="HttpNonWorkingDaySource{T}"/>.</param>
        /// <param name="parseAction">The <see cref="Func{TContent, TResult}"/> used to build the internal state of the <see cref="HttpNonWorkingDaySource{T}"/> from the content of the provided <see cref="HttpRequestMessage"/>'s <see cref="HttpResponseMessage"/>.</param>
        /// <param name="checkAction">The <see cref="Func{TDateTime, TState, TResult}"/> used to check whether a given <see cref="DateTime"/> is on a non-working day based on the current state of the <see cref="HttpNonWorkingDaySource{T}"/>.
        /// Should return <c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        /// <param name="refreshTimer">The interval at which to make the provided HTTP Request to update the internal state.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="HttpNonWorkingDaySource{T}"/>, in addition to it's previously configured sources.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddHttpSource<T>(this WorkingDayServiceBuilder builder, HttpRequestMessage request, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction, TimeSpan refreshTimer)
            => builder.WithSource(new HttpNonWorkingDaySource<T>(request, parseAction, checkAction, refreshTimer));
    }
}
