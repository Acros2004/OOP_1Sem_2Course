using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class KNSFileInfo
    {
        public static event Action<string> OnUpdate;

        public static void ShowFullPatch(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);

            if (fileInfo.Exists)
            {
                OnUpdate($"File {fileInfo.Name}:\n\n " +
                         $"File full name: {fileInfo.FullName}");
            }
            else
            {
                OnUpdate($"File {patch}:\n\n" +
                         $"- File search error!\n");
            }
        }

        public static void ShowFileInformation(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);

            if (fileInfo.Exists)
            {
                OnUpdate($"File {fileInfo.Name}:\n\n " +
                         $"File full name: {fileInfo.FullName}\n" +
                         $"File Size: {fileInfo.Length}\n" +
                         $"File Extension: {fileInfo.Extension}\n");
            }
            else
            {
                OnUpdate($"File {patch}:\n\n" +
                         $"- File search error!\n");
            }
        }

        public static void ShowFileDatesCreateAndUpdate(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);

            if (fileInfo.Exists)
            {
                OnUpdate($"File {fileInfo.Name}:\n\n " +
                         $"File full name: {fileInfo.FullName}\n" +
                         $"Date of creation: {fileInfo.CreationTime}\n" +
                         $"Date of last edit: {fileInfo.LastWriteTime}\n");
            }
            else
            {
                OnUpdate($"File {patch}:\n\n" +
                         $"- File search error!\n");
            }
        }
    }
}
