using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Utilities
{
    /// <summary>
    /// Class to provide controls for event execution performance and time
    /// </summary>
    public class ExecutionPerformanceMonitor : IDisposable
    {
        private Stopwatch _StopWatch;
        private readonly string _EventName;
        private readonly ILogger _Logger;

        public ExecutionPerformanceMonitor(string eventName = "Unknown")
        {
            _StopWatch = Stopwatch.StartNew();
            _EventName = eventName;
        }

        public ExecutionPerformanceMonitor(ILogger logger, string eventName = "Unknown")
        {
            _EventName = eventName;
            _Logger = logger;
        }

        /// <summary>
        /// Operation to generate an ellapsed time message for the execution of the provided method name
        /// </summary>
        /// <param name="MethodName">The name of the method that is being executed</param>
        /// <returns>A formatted string documenting the ellapsed time/duration of the method</returns>
        public string CreatePerformanceTimeMessage(string MethodName)
        {
            string result = "";
            if (_StopWatch != null)
            {
                result = string.Format($"{MethodName} ellapsed time = {_StopWatch.Elapsed.ToString("mm\\:ss\\.ff")} (mm:ss.ff)");
            }
            else
            {
                result = string.Format($"No time performance for {MethodName}");
            }
            return result;
        }

        /// <summary>
        /// A test method to handle the logging of an event without waiting for it to complete!
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public async Task CreatePerformanceMetricAndLogEvent(string eventName = "Unknown")
        {
            await Task.Run(() =>
            {
                string message = "";
                if (_StopWatch != null)
                {
                    message = string.Format($"{eventName} ellapsed time = {_StopWatch.Elapsed.ToString("mm\\:ss\\.ff")} (mm:ss.ff)");
                }
                else
                {
                    message = string.Format($"No time performance for {eventName}");
                }
                _Logger.LogDebug($"{_EventName} : {message}");
            });
        }

        /// <summary>
        /// Restarts the stopwatch timer
        /// Allows the monitor to be re-used and re-reported
        /// </summary>
        public void RestartMonitor() => _StopWatch = Stopwatch.StartNew();

        /// <summary>
        /// Inherited interface method
        /// stops the timer
        /// </summary>
        public void Dispose()
        {
            _StopWatch.Stop();
        }
    }
}