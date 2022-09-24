using Logger_HW1;

namespace Modul2HW5
{
    /// <summary>
    /// Main Program.
    /// </summary>
    public class Starter
    {
        /// <summary>
        /// Starts the App.
        /// </summary>
        public void Run()
        {
            Random rnd = new ();

            for (var i = 0; i < 100; i++)
            {
                int index = rnd.Next(1, 4);

                switch (index)
                {
                    case 1:
                        Actions.First();
                        break;
                    case 2:
                        try
                        {
                            Actions.Second();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        Logger.Instance.Log(DateTime.Now, LogType.Error, nameof(Actions.Second) + " Action got this custom Exception ");
                        break;
                    case 3:
                        try
                        {
                            Actions.Third();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        Logger.Instance.Log(DateTime.Now, LogType.Error, nameof(Actions.Third) + " Action failed by a reason");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}