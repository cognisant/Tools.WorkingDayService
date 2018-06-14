// <copyright file="WorkingDayServiceBuilder.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Builder Class for the Working Day Service; used for easy configuration.
    /// </summary>
    public sealed class WorkingDayServiceBuilder
    {
        private readonly HashSet<NonWorkingDaySource> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class.
        /// </summary>
        public WorkingDayServiceBuilder() => _sources = new HashSet<NonWorkingDaySource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class.
        /// </summary>
        /// <returns>The new instance of the <see cref="WorkingDayServiceBuilder"/> class.</returns>
        public static WorkingDayServiceBuilder New() => new WorkingDayServiceBuilder();

        /// <summary>
        /// Builds a <see cref="WorkingDayService"/> with the configured set of <see cref="NonWorkingDaySource"/>s.
        /// </summary>
        /// <returns>A <see cref="WorkingDayService"/> which uses the <see cref="NonWorkingDaySource"/>s in the <see cref="WorkingDayServiceBuilder"/>'s <c>_sources</c>.</returns>
        public WorkingDayService Build() => new WorkingDayService(_sources.ToList());

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="NonWorkingDaySource"/> in addition to its current sources.
        /// </summary>
        /// <param name="source">The <see cref="NonWorkingDaySource"/> to add.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the new <see cref="NonWorkingDaySource"/> which was passed in.</returns>
        public WorkingDayServiceBuilder WithSource(NonWorkingDaySource source)
        {
            _sources.Add(source);
            return this;
        }

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="NonWorkingDaySource"/>s in addition to its current sources.
        /// </summary>
        /// <param name="sources">The <see cref="NonWorkingDaySource"/>s to add (they should be unique; adding the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the new <see cref="NonWorkingDaySource"/>s which have been passed in.</returns>
        public WorkingDayServiceBuilder WithSources(params NonWorkingDaySource[] sources) => WithSources((IEnumerable<NonWorkingDaySource>)sources);

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the <see cref="NonWorkingDaySource"/>s containeed in the provided <see cref="IEnumerable{T}"/> in addition to its current sources.
        /// </summary>
        /// <param name="sources">An <see cref="IEnumerable{T}"/> of the <see cref="NonWorkingDaySource"/>s to add (they should be unique; adding the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the <see cref="NonWorkingDaySource"/>s contained in the <see cref="IEnumerable{T}"/> which has been passed in.</returns>
        public WorkingDayServiceBuilder WithSources(IEnumerable<NonWorkingDaySource> sources)
        {
            foreach (var source in sources)
            {
                _sources.Add(source);
            }

            return this;
        }
    }
}
