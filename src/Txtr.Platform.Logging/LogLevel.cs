namespace Txtr.Platform.Logging
{
    /// <summary>
    /// Signifies the level at which to write a <see cref="ILogEntry"/>.
    /// Are used to exclude log entries that have log levels
    /// less than the current <see cref="ILogStrategy"/> threshold level.
    /// <seealso cref="ILogStrategy.GetLogLevel"/>.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// The least restrictive level.
        /// </summary>
        All = 0,
        /// <summary>
        /// For debugging purposes.
        /// </summary>
        Debug = 2,
        /// <summary>
        /// Signifies verbose information.
        /// </summary>
        Info = 4,
        /// <summary>
        /// Signifies a warning from e.g. an unexpected event.
        /// </summary>
        Warn = 8,
        /// <summary>
        /// When the application is no longer
        /// able to function or is in an unreliable state.
        /// Highly restrive logging.
        /// </summary>
        Exception = 32,
        /// <summary>
        /// Logging is disabled.
        /// </summary>
        None = 64
    }
}
