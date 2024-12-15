namespace AdventOfCode_Library
{
    public static partial class Shared
    {
        public static void SendOutputToFile(string path, string outputText)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"============Output at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}============");
                sw.WriteLine(outputText);
                sw.WriteLine("============End of output============");
            }
        }
    }
}
