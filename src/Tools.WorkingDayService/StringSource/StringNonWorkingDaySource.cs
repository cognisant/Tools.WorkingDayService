// <copyright file="StringNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.StringSource
{
    using System;

    /// <inheritdoc cref="NonWorkingDaySource"/>
    /// <summary>
    /// An implementation of <see cref="NonWorkingDaySource"/> which uses the content of a <see cref="string"/> to determine whether a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.
    /// </summary>
    public class StringNonWorkingDaySource<T> : NonWorkingDaySource
    {
#pragma warning disable SA1648 // inheritdoc should be used with inheriting class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="StringNonWorkingDaySource{T}" /> class using the provided content, parsing method and non-working day check.
        /// </summary>
        /// <param name="content">The <see cref="string" /> whose content the new <see cref="StringNonWorkingDaySource{T}" /> should be built from.</param>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}" /> from the provided <see cref="string" />.</param>
        /// <param name="checkAction">The action used to determine whether a <see cref="DateTime" /> is on a Non-Working Day (based on the current state of the <see cref="StringNonWorkingDaySource{T}" />).
        /// Should return <c>true</c> if the provided <see cref="DateTime" /> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        public StringNonWorkingDaySource(string content, Func<string, T> parseAction, Func<DateTime, T, bool> checkAction)
            : this(parseAction, checkAction) => State = parseAction(content);
#pragma warning restore SA1648 // inheritdoc should be used with inheriting class

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNonWorkingDaySource{T}"/> class using the provided parsing method and non-working day check.
        /// </summary>
        /// <param name="parseAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the current string state.</param>
        /// <param name="checkAction">The action to determine whether a <see cref="DateTime"/> is on a Non-Working Day based on the current state.
        /// Should return <c>true</c> if the provided date is a Non-Working Day and <c>false</c> if it is a Working Day.</param>
        protected StringNonWorkingDaySource(Func<string, T> parseAction, Func<DateTime, T, bool> checkAction)
        {
            CheckAction = checkAction ?? throw new ArgumentNullException(nameof(parseAction));
            ParseAction = parseAction ?? throw new ArgumentException(nameof(checkAction));
        }

        /// <summary>
        /// Gets the action used to determine whether a <see cref="DateTime"/> is on a Non-Working Day (using the current state of the <see cref="StringNonWorkingDaySource{T}"/>).
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
