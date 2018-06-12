// <copyright file="FileSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.FileSource
{
    using System;

    /// <summary>
    /// An Extension Methods class containing methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use <see cref="FileWorkingDaySource{T}"/>s.
    /// </summary>
    public static class FileSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="FileWorkingDaySource{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the internal state for the <see cref="FileWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="filePath">The path to the file which should be used to create the <see cref="FileWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action to build the internal state of the <see cref="FileWorkingDaySource{T}"/> from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine if a <see cref="DateTime"/> is on a Working Day (using the <see cref="FileWorkingDaySource{T}"/> based on the file at the provided file path).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new <see cref="FileWorkingDaySource{T}"/> configured with the file at the provided file path.</returns>
        public static WorkingDayServiceBuilder UseFileSource<T>(this WorkingDayServiceBuilder builder, string filePath, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.UseSource(new FileWorkingDaySource<T>(filePath, parseFileContentAction, checkAction));

        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="FileWorkingDaySource{T}"/> in addition to its current sources.
        /// </summary>
        /// <typeparam name="T">The type of the internal state for the <see cref="FileWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="filePath">The path to the file to which should be used to create the <see cref="FileWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action to build the internal state of the File Working Day Source from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine if a <see cref="DateTime"/> is on a Working Day (using the <see cref="FileWorkingDaySource{T}"/>).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="FileWorkingDaySource{T}"/> configured with the file at the provided file path, in addition to its current sources.</returns>
        public static WorkingDayServiceBuilder AddFileSource<T>(this WorkingDayServiceBuilder builder, string filePath, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.AddSource(new FileWorkingDaySource<T>(filePath, parseFileContentAction, checkAction));
    }
}
