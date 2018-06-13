// <copyright file="FileNonWorkingDaySource.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.FileSource
{
    using System;
    using System.IO;
    using StringSource;

    /// <inheritdoc cref="StringNonWorkingDaySource{T}"/>
    /// <inheritdoc cref="IDisposable"/>
    /// <summary>
    /// An implementation of <see cref="StringNonWorkingDaySource{T}"/> which uses the content of a File to determine whether a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.
    /// </summary>
    public sealed class FileNonWorkingDaySource<T> : StringNonWorkingDaySource<T>, IDisposable
    {
        private readonly FileSystemWatcher _fileWatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNonWorkingDaySource{T}"/> class with a <see cref="FileSystemWatcher"/> that watches the file at the provided file path and updates its internal state with any new content.
        /// The internal state is used to determine if a given <see cref="DateTime"/> is on a Working Day or a Non-Working Day.
        /// </summary>
        /// <param name="filePath">The path to the file who's content should be used to create and update the <see cref="FileNonWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action used to build the internal state of the <see cref="FileNonWorkingDaySource{T}"/> from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine if a <see cref="DateTime"/> is on a Working Day (using the <see cref="FileNonWorkingDaySource{T}"/> based on the file at the provided file path).</param>
        public FileNonWorkingDaySource(string filePath, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            : base(parseFileContentAction, checkAction)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "Cannot initialize a File Working Day Source without a File Path.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"The File Path provided to the constructor of a File Working Day Source was invalid; the file '{filePath}' doesn't exist.", nameof(filePath));
            }

            _fileWatcher = new FileSystemWatcher(filePath);
            _fileWatcher.Changed += OnChange;

            State = ParseAction(File.ReadAllText(filePath));
        }

        /// <inheritdoc />
        public void Dispose() => _fileWatcher?.Dispose();

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            lock (State)
            {
                State = ParseAction(File.ReadAllText(e.FullPath));
            }
        }
    }
}
