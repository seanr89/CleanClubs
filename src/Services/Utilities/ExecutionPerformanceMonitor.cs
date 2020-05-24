using System;
using System.Diagnostics;

namespace APIGenerator.Utilities
{
    /// <summary>
    /// Class to provide controls for event execution performance and time
    /// </summary>
    public class ExecutionPerformanceMonitor : IDisposable
    {
        private Stopwatch _StopWatch;

        public ExecutionPerformanceMonitor()
        {
            _StopWatch = Stopwatch.StartNew();
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
        /// Inherited interface method
        /// stops the timer
        /// </summary>
        public void Dispose()
        {
            _StopWatch.Stop();
        }
    }
}