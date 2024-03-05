namespace Tracker.Utils
{
    public static class Misc
    {
        public static string ReadFromFile(string path)
        {
            StreamReader textFile = new StreamReader(path);
            string fileContents = textFile.ReadToEnd();
            textFile.Close();
            return fileContents;
        }
    }
}
