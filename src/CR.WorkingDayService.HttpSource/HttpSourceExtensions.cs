// <copyright file="HttpSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.HttpSource
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// An Extension Methods class containing methods relating to the HttpWorkingDaySource.
    /// </summary>
    public static class HttpSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="HttpWorkingDaySource{T}"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the internal state of the <see cref="HttpWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="request">The request to make to update the internal state of the <see cref="HttpWorkingDaySource{T}"/>.</param>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="HttpWorkingDaySource{T}"/> from the content of the provided <see cref="HttpRequestMessage"/>'s Response.</param>
        /// /// <param name="checkAction">The Action used to check the internal state to determine if a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.</param>
        /// <param name="refreshTimer">The interval on which to make the provided HTTP Request to update the internal state.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new <see cref="HttpWorkingDaySource{T}"/>.</returns>
        public static WorkingDayServiceBuilder UseHttpSource<T>(this WorkingDayServiceBuilder builder, HttpRequestMessage request, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction, TimeSpan refreshTimer)
            => builder.UseSource(new HttpWorkingDaySource<T>(request, parseAction, checkAction, refreshTimer));

        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="HttpWorkingDaySource{T}"/> in addition to its current sources.
        /// </summary>
        /// <typeparam name="T">The Type of the internal state of the <see cref="HttpWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="request">The request to make to update the internal state of the <see cref="HttpWorkingDaySource{T}"/>.</param>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="HttpWorkingDaySource{T}"/> from the content of the provided <see cref="HttpRequestMessage"/>'s Response.</param>
        /// /// <param name="checkAction">The Action used to check the internal state to determine if a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.</param>
        /// <param name="refreshTimer">The interval on which to make the provided HTTP Request to update the internal state.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="HttpWorkingDaySource{T}"/> in addition to its current sources.</returns>
        public static WorkingDayServiceBuilder AddHttpSource<T>(this WorkingDayServiceBuilder builder, HttpRequestMessage request, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction, TimeSpan refreshTimer)
            => builder.AddSource(new HttpWorkingDaySource<T>(request, parseAction, checkAction, refreshTimer));
    }
}
