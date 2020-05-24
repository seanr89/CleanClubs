using Microsoft.Extensions.Logging;

namespace Utilities
{
    /// <summary>
    /// Static class to handle creation of loggers for classes that are not directly connected
    /// to the routing DI flow and therefore cannot interact and inject the logger directly
    /// </summary>
    public static class ApplicationLoggerProvider
    {
        /// <summary>
        /// Static object of the LoggerFactory implementation
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        /// <summary>
        /// Create a logger object for the provided type(T) class
        /// </summary>
        /// <typeparam name="T"> generic type parameter allows arbitrary type T to a method at compile-time, without specifying a concrete type in the method or class declaration.</typeparam>
        /// <returns>And object of the ILogger</returns>
        public static ILogger CreateLogger<T>() =>
          LoggerFactory.CreateLogger<T>();

        /// <summary>
        /// TODO - Unknown if this is relevant anymore
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public static ILogger CreateLogger(string CategoryName) =>
                LoggerFactory.CreateLogger(CategoryName);
    }
}