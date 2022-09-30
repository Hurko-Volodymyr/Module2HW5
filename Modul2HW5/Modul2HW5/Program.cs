using Logger_HW1;

namespace Modul2HW5
{
    /// <summary>
    /// Main Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the App.
        /// </summary>
        /// <param name="args">console call params.</param>
        private static void Main(string[] args)
        {
            var res = new Starter();
            res.Run();
            var file = new FileService();
            file.Write();
        }
    }
}