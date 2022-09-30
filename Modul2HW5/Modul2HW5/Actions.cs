using Logger2;

namespace Logger_HW1
{
    /// <summary>
    /// Main Program.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// First.
        /// </summary>
        /// <returns>Result. </returns>
        public static bool First()
        {
            Logger.Instance.Log(DateTime.Now, LogType.Info, $"{nameof(First)}");
            return true;
        }

        /// <summary>
        /// Second.
        /// </summary>
        /// <returns>Result. </returns>
        public static bool Second()
        {
            Logger.Instance.Log(DateTime.Now, LogType.Warning, $"{nameof(Second)}");
            throw new BusinessException("Skipped logic");
        }

        /// <summary>
        /// Third.
        /// </summary>
        /// <returns>Result. </returns>
        public static bool Third()
        {
            Logger.Instance.Log(DateTime.Now, LogType.Error, nameof(Third));
            throw new Exception(message: "I broke a logic");
        }
    }
}
