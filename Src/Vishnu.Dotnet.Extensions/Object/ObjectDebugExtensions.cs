using System;
using System.Diagnostics;
using System.Text;

namespace Vishnu.Extensions.ObjectType
{
    /// <summary>
    /// Debug extensions
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Debug levels
        /// </summary>
        private enum LogLevels
        {
            // Exception, Error
            Level1,
            // Exception, Error, Functional, Informative,
            Level2,
            // Exception, Error, Functional, Informative, Debug
            Level3,
            // All
            All,
        }

        /// <summary>
        /// default messasge if no value is specified
        /// </summary>
        private static Func<string> _defaultMessage = () => "";

        /// <summary>
        /// Debug format
        /// {0} Trace Type
        /// {1} Class
        /// {2} ThreadID
        /// {3} Line Number
        /// {4} Current Member
        /// {5} Method Name
        /// {6} Message
        /// </summary>
        private static string _debugFormat = "{0} {1} : {2} - [ {3} ] {4}.{5} - {6}";

        /// <summary>
        /// Current log level
        /// </summary>
        private static LogLevels _logLevel = LogLevels.All;
        /// <summary>
        /// Is exception trace enabled.
        /// </summary>
        private static bool _isExceptionEnabled = true;
        /// <summary>
        /// Is error trace enabled.
        /// </summary>
        private static bool _isErrorEnabled = true;
        /// <summary>
        /// Is warning trace enabled.
        /// </summary>
        private static bool _isWarningEnabled = true;
        /// <summary>
        /// Is functional trace enabled.
        /// </summary>
        private static bool _isFunctionalEnabled = true;
        /// <summary>
        /// Is informative trace enabled.
        /// </summary>
        private static bool _isInformativeEnabled = true;
        /// <summary>
        /// Is debug trace enabled.
        /// </summary>
        private static bool _isDebugEnabled = true;
        /// <summary>
        /// Is Begin trace enabled.
        /// </summary>
        private static bool _isBeginEnabled = true;
        /// <summary>
        /// Is end trace enabled.
        /// </summary>
        private static bool _isEndEnabled = true;

        /// <summary>
        /// Sets log level. Default level is All
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="level">1,2,3,All</param>
        public static void SetLogLevel(this object obj, string level)
        {
            switch (level)
            {
                case "1":
                    UpdateLogLevel(obj, LogLevels.Level1);
                    break;
                case "2":
                    UpdateLogLevel(obj, LogLevels.Level2);
                    break;
                case "3":
                    UpdateLogLevel(obj, LogLevels.Level3);
                    break;
                case "4":
                    UpdateLogLevel(obj, LogLevels.All);
                    break;
                default:
                    UpdateLogLevel(obj, LogLevels.All);
                    break;
            }
        }

        /// <summary>
        /// Update Log levels
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="level">LogLevels</param>
        private static void UpdateLogLevel(this object obj, LogLevels level)
        {
            _logLevel = level;
            switch (_logLevel)
            {
                case LogLevels.Level1:
                    {
                        _isExceptionEnabled = true;
                        _isErrorEnabled = true;
                        _isWarningEnabled = true;
                        _isFunctionalEnabled = false;
                        _isInformativeEnabled = false;
                        _isDebugEnabled = false;
                        _isBeginEnabled = false;
                        _isEndEnabled = false;
                    }
                    break;
                case LogLevels.Level2:
                    {
                        _isExceptionEnabled = true;
                        _isErrorEnabled = true;
                        _isWarningEnabled = true;
                        _isFunctionalEnabled = true;
                        _isInformativeEnabled = false;
                        _isDebugEnabled = false;
                        _isBeginEnabled = false;
                        _isEndEnabled = false;
                    }
                    break;
                case LogLevels.Level3:
                    {
                        _isExceptionEnabled = true;
                        _isErrorEnabled = true;
                        _isWarningEnabled = true;
                        _isFunctionalEnabled = true;
                        _isInformativeEnabled = true;
                        _isDebugEnabled = true;
                        _isBeginEnabled = false;
                        _isEndEnabled = false;
                    }
                    break;
                case LogLevels.All:
                    {
                        _isExceptionEnabled = true;
                        _isErrorEnabled = true;
                        _isWarningEnabled = true;
                        _isFunctionalEnabled = true;
                        _isInformativeEnabled = true;
                        _isDebugEnabled = true;
                        _isBeginEnabled = true;
                        _isEndEnabled = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Log exception trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="ex">Exception</param>
        public static void LogExeception(this object obj, Exception ex)
        {
            if (_isExceptionEnabled)
            {
                StringBuilder sb = new StringBuilder();
                if (ex != null)
                {
                    sb.Append(ex.Message);
                    sb.AppendLine(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        sb.AppendLine(ex.InnerException.Message);
                        sb.AppendLine(ex.InnerException.StackTrace);
                    }
                }

                Func<string> message = ex == null ? _defaultMessage : () => sb.ToString();
                string buildMessage = BuildMessage("[EX]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log begin trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogBegin(this object obj, Func<string> message = null)
        {
            if (_isBeginEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[BGN]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log end trace.
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogEnd(this object obj, Func<string> message = null)
        {
            if (_isEndEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[END]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log warning trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogWarning(this object obj, Func<string> message = null)
        {
            if (_isWarningEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[WAR]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log error trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogError(this object obj, Func<string> message = null)
        {
            if (_isErrorEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[ERR]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log information trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogInformation(this object obj, Func<string> message = null)
        {
            if (_isInformativeEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[INF]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log debug trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">messaage</param>
        public static void LogDebug(this object obj, Func<string> message = null)
        {
            if (_isDebugEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[DBG]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Log functional trace
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="message">message</param>
        public static void LogFunctional(this object obj, Func<string> message = null)
        {
            if (_isFunctionalEnabled)
            {
                message = message ?? _defaultMessage;
                string buildMessage = BuildMessage("[FUN]", obj.GetType().FullName, message());
                Debug.WriteLine(buildMessage);
            }
        }

        /// <summary>
        /// Build message
        /// </summary>
        /// <param name="debugType">type</param>
        /// <param name="component">component</param>
        /// <param name="message">message</param>
        /// <returns>formatted message</returns>
        private static string BuildMessage(string debugType, string component, string message)
        {
            string result = string.Empty;

            StackTrace st = new StackTrace(0, true);
            for (int frame = 0; frame < st.FrameCount; frame++)
            {
                StackFrame frm = st.GetFrame(frame);
                System.Reflection.MethodBase method = frm.GetMethod();

                if (method.DeclaringType != typeof(ObjectExtension))
                {
                    result = string.Format(_debugFormat,
                        debugType,
                        component,
                        System.Threading.Thread.CurrentThread.ManagedThreadId,
                        frm.GetFileLineNumber(),
                        method.DeclaringType.Name,
                        method.Name,
                        message);

                    break;
                }
            }

            return result;
        }
    }
}
