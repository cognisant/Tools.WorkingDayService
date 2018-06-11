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
        private readonly HashSet<IWorkingDaySource> _sources;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class.
        /// </summary>
        public WorkingDayServiceBuilder() => _sources = new HashSet<IWorkingDaySource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingDayServiceBuilder"/> class.
        /// </summary>
        /// <returns>The new instance of the <see cref="WorkingDayServiceBuilder"/> class.</returns>
        public static WorkingDayServiceBuilder New() => new WorkingDayServiceBuilder();

        /// <summary>
        /// Builds a <see cref="WorkingDayService"/> with the configured set of <see cref="IWorkingDaySource"/>s.
        /// </summary>
        /// <returns>A <see cref="WorkingDayService"/> which uses the <see cref="IWorkingDaySource"/>s in the <see cref="WorkingDayServiceBuilder"/>'s <c>_sources</c>.</returns>
        public WorkingDayService Build() => new WorkingDayService(_sources.ToList());

        /// <summary>
        /// Configure the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="IWorkingDaySource"/> in addition to its current sources.
        /// </summary>
        /// <param name="source">The <see cref="IWorkingDaySource"/> to add.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the new <see cref="IWorkingDaySource"/> which was passed in.</returns>
        public WorkingDayServiceBuilder AddSource(IWorkingDaySource source)
        {
            _sources.Add(source);
            return this;
        }

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to only use the passed in <see cref="IWorkingDaySource"/>.
        /// </summary>
        /// <param name="source">The <see cref="IWorkingDaySource"/> to use.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> using only the <see cref="IWorkingDaySource"/> which was passed in. All all of its current sources will be removed.</returns>
        public WorkingDayServiceBuilder UseSource(IWorkingDaySource source)
        {
            _sources.Clear();
            return AddSource(source);
        }

        /// <summary>
        /// Configure the <see cref="WorkingDayServiceBuilder"/> to only use the specified sources.
        /// </summary>
        /// <param name="sources">The <see cref="IWorkingDaySource"/>s the <see cref="WorkingDayService"/> should use. Sources should be unique; adding the same source multiple times will result in it only being added once.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> using only the <see cref="IWorkingDaySource"/>s which have been passed in. All all of its current sources will be removed.</returns>
        public WorkingDayServiceBuilder UseSources(params WorkingDayService[] sources) => UseSources((IEnumerable<IWorkingDaySource>)sources);

        /// <summary>
        /// Configure the <see cref="WorkingDayServiceBuilder"/> to only use the specified sources.
        /// </summary>
        /// <param name="sources">An <see cref="IEnumerable{T}"/> of the <see cref="IWorkingDaySource"/>s to use. The sources should be unique; adding the same source multiple times will result in it only being added once.</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> using only the <see cref="IWorkingDaySource"/>s contained in the <see cref="IEnumerable{T}"/> which has been passed in. All all of its current sources will be removed.</returns>
        public WorkingDayServiceBuilder UseSources(IEnumerable<IWorkingDaySource> sources)
        {
            _sources.Clear();
            return AddSources(sources);
        }

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified <see cref="IWorkingDaySource"/>s in addition to its current sources.
        /// </summary>
        /// <param name="sources">The <see cref="IWorkingDaySource"/>s to add (they should be unique; adding the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the new <see cref="IWorkingDaySource"/>s which have been passed in.</returns>
        public WorkingDayServiceBuilder AddSources(params IWorkingDaySource[] sources) => AddSources((IEnumerable<IWorkingDaySource>)sources);

        /// <summary>
        /// Configures the <see cref="WorkingDayServiceBuilder"/> to use the specified sources in addition to its current sources.
        /// </summary>
        /// <param name="sources">An <see cref="IEnumerable{T}"/> of the <see cref="IWorkingDaySource"/>s to add (they should be unique; adding the same source multiple times will result in it only being added once).</param>
        /// <returns>The same instance of the <see cref="WorkingDayServiceBuilder"/> with all of its current sources, and the <see cref="IWorkingDaySource"/>s contained in the <see cref="IEnumerable{T}"/> which has been passed in.</returns>
        public WorkingDayServiceBuilder AddSources(IEnumerable<IWorkingDaySource> sources)
        {
            foreach (var source in sources)
            {
                _sources.Add(source);
            }

            return this;
        }
    }
}
