// <copyright file="StringSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.StringSource
{
    using System;

    /// <summary>
    /// A helper class containing extension methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="StringNonWorkingDaySource{T}"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class StringSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="StringNonWorkingDaySource{T}"/> in addition to it's current sources.
        /// </summary>
        /// <typeparam name="T">The type of the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="source">The string content to be used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the provided string content.</param>
        /// <param name="checkAction">The action used to determine whether a given <see cref="DateTime"/> is on a non-Working Day (using the <see cref="StringNonWorkingDaySource{T}"/>, based on the provided string content).
        /// Should return <c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="StringNonWorkingDaySource{T}"/>, in addition to it's previously configured sources.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddStringSource<T>(this WorkingDayServiceBuilder builder, string source, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.WithSource(new StringNonWorkingDaySource<T>(source, parseFileContentAction, checkAction));
    }
}
