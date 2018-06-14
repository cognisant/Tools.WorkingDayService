// <copyright file="StringNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.StringSource
{
    using System;

    /// <inheritdoc cref="NonWorkingDaySource"/>
    /// <summary>
    /// An implementation of <see cref="NonWorkingDaySource"/> which uses the content of a <see cref="string"/> to determine if a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.
    /// </summary>
    public class StringNonWorkingDaySource<T> : NonWorkingDaySource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringNonWorkingDaySource{T}"/> class.
        /// </summary>
        /// <param name="content">The <see cref="string"/> who's content the new <see cref="StringNonWorkingDaySource{T}"/> should be based on.</param>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the provided <see cref="string"/>.</param>
        /// <param name="checkAction">The action used to determine if a <see cref="DateTime"/> is on a Working Day (using the <see cref="StringNonWorkingDaySource{T}"/> based on the provided <see cref="string"/>).</param>
        public StringNonWorkingDaySource(string content, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction)
            : this(parseAction, checkAction) => State = parseAction(content);

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNonWorkingDaySource{T}"/> class.
        /// </summary>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the provided <see cref="string"/>.</param>
        /// <param name="checkAction">The action to get whether a <see cref="DateTime"/> is on a Working Day based on the current state.</param>
        protected StringNonWorkingDaySource(Func<string, T> parseAction, Func<DateTime, T, bool> checkAction)
        {
            CheckAction = checkAction ?? throw new ArgumentNullException(nameof(parseAction));
            ParseAction = parseAction ?? throw new ArgumentException(nameof(checkAction));
        }

        /// <summary>
        /// Gets the action used to check whether a <see cref="DateTime"/> is on a Working Day (using the <see cref="StringNonWorkingDaySource{T}"/>).
        /// </summary>
        protected Func<DateTime, T, bool> CheckAction { get; }

        /// <summary>
        /// Gets the action used to parse a <see cref="string"/> into the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.
        /// </summary>
        protected Func<string, T> ParseAction { get; }

        /// <summary>
        /// Gets or sets the current internal state of the <see cref="StringNonWorkingDaySource{T}"/>.
        /// </summary>
        protected T State { get; set; }

        /// <inheritdoc />
        public override bool IsWorkingDay(DateTime date)
        {
            lock (State)
            {
                return !CheckAction(date, State);
            }
        }

        /// <inheritdoc />
        public override bool IsNonWorkingDay(DateTime date)
        {
            lock (State)
            {
                return CheckAction(date, State);
            }
        }
    }
}
