// <copyright file="WorkingDayServiceBuilder.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace CorshamScience.Tools.WorkingDayService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Builder Class for the <see cref="WorkingDayService"/>; used to easily configure a <see cref="WorkingDayService"/> to use a range of <see cref="NonWorkingDaySource"/>s.
    /// </summary>
    public class WorkingDayServiceBuilder
    {
        private readonly HashSet<NonWorkingDaySource> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class with no configured <see cref="NonWorkingDaySource"/>s.
        /// </summary>
        public WorkingDayServiceBuilder() => _sources = new HashSet<NonWorkingDaySource>();

        /// <summary>
        /// Converts a <see cref="WorkingDayServiceBuilder"/> into a new instance of the <see cref="WorkingDayService"/> class.
        /// </summary>
        /// <param name="builder">The <see cref="WorkingDayServiceBuilder"/> to use to build the new <see cref="WorkingDayService"/> with.
        /// The new <see cref="WorkingDayService"/>'s sources will match the provided <see cref="WorkingDayServiceBuilder"/>'s sources.</param>
        public static implicit operator WorkingDayService(WorkingDayServiceBuilder builder)
        {
            var sources = builder._sources;
            if (sources == null || sources.Count == 0)
            {
                throw new ArgumentException("Tried to build a WorkingDayService with no sources.", nameof(sources));
            }

            return new WorkingDayService(sources.ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class.
        /// </summary>
        /// <returns>The new instance of the <see cref="WorkingDayServiceBuilder"/> class.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder New() => new WorkingDayServiceBuilder();

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="NonWorkingDaySource"/> in addition to any previously configured sources.
        /// </summary>
        /// <param name="source">The <see cref="NonWorkingDaySource"/> to use.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> using the new <see cref="NonWorkingDaySource"/>, as well as any previously configured <see cref="NonWorkingDaySource"/>s.</returns>
        /// <remarks>Will do nothing if the provided <see cref="NonWorkingDaySource"/> is null.</remarks>
        public WorkingDayServiceBuilder WithSource(NonWorkingDaySource source)
        {
            if (source == null)
            {
                return this;
            }

            _sources.Add(source);
            return this;
        }

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="NonWorkingDaySource"/>s in addition to any previously configured sources.
        /// </summary>
        /// <param name="sources">The <see cref="NonWorkingDaySource"/>s to add (they should be unique; attempting to add the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with any previously configured <see cref="NonWorkingDaySource"/>s, as well as the provided <see cref="NonWorkingDaySource"/>s.</returns>
        // ReSharper disable once UnusedMember.Global
        public WorkingDayServiceBuilder WithSources(params NonWorkingDaySource[] sources) => WithSources((IEnumerable<NonWorkingDaySource>)sources);

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="NonWorkingDaySource"/>s in addition to any previously configured sources.
        /// </summary>
        /// <param name="sources">The <see cref="NonWorkingDaySource"/>s to add (they should be unique; attempting to add the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with any previously configured <see cref="NonWorkingDaySource"/>s, as well as the provided <see cref="NonWorkingDaySource"/>s.</returns>
        /// <remarks>Will do nothing if the provided <see cref="IEnumerable{NonWorkingDaySource}"/> is null.</remarks>
        public WorkingDayServiceBuilder WithSources(IEnumerable<NonWorkingDaySource> sources)
        {
            if (sources == null)
            {
                return this;
            }

            foreach (var source in sources)
            {
                _sources.Add(source);
            }

            return this;
        }
    }
}
