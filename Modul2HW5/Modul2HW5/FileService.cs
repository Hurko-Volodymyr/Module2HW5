using System.Reflection;
using System.Text;
using Logger_HW1;
using Logger2;
using Newtonsoft.Json;

namespace Modul2HW5
{
    public class FileService
    {
        public void Write()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = $@"{assemblyPath}\{config.Logger.DirectoryPath}";

            DirectoryInfo dirInfo = new (path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string filename = config.Logger.FileName + DateTime.Now.ToString("hh.mm.ss.dd.MM.yyyy");
            var fullname = filename + config.Logger.FileExtention;

            string writePath = $@"{path}\ {filename}.{config.Logger.FileExtention}";
            var start = new Starter();
            StringWriter sw = new ();

            foreach (var file in new DirectoryInfo($@"{path}\").GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(2))
            {
                file.Delete();
            }

            Console.SetOut(sw);
            start.Run();
            string str = sw.GetStringBuilder().ToString();
            Console.WriteLine(str);
            try
            {
                using (StreamWriter strw = new (writePath, false, encoding: Encoding.Default))
                {
                    strw.WriteLine(str);
                }

                using (StreamWriter strw = new (writePath, true, Encoding.Default))
                {
                    strw.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}