using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab12
{
    internal class KNSDirInfo
    {
        public static event Action<string> OnUpdate;

        public static void ShowAmountOfFile(string patch)
        {
            OnUpdate($"The amount of files = {Directory.GetFiles(patch).Length}");
        }
        public static void ShowCreationTime(string patch)
        {
            OnUpdate($"Time of the directory creation: {Directory.GetCreationTime(patch)}");
        }
        public static void ShowAmountOfSubdirectories(string patch)
        {
            OnUpdate($"Amount of subdirectories: {Directory.GetDirectories(patch).Length}");
        }

        public static void ShowParentDirectory(string patch)
        {
            OnUpdate($"Parent Directory: {Directory.GetParent(patch)}");
        }
    }
}
