using System;
using System.Data;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab12
{
    internal class KNSFileManager
    {
        public static event Action<string> OnUpdate;

        public static void ShowListDirectoryAndFileDisk(string diskName)
        {
            if (!Directory.Exists(diskName))
                throw new Exception($"Directory ({diskName}) not find");

            var listDirectory = Directory.GetDirectories(diskName);
            var listFile = Directory.GetFiles(diskName);

            StringBuilder stringBuilder_01 = new StringBuilder("Directories:\n");

            foreach (var directory in listDirectory)
            {
                stringBuilder_01.AppendLine(directory);
            }

            stringBuilder_01.AppendLine("\nFiles:\n");

            foreach (var file in listFile)
            {

                stringBuilder_01.AppendLine(file);
            }

            OnUpdate(stringBuilder_01.ToString());
        }
        public static void CreateDirectory(string patch)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(patch);

            if (directoryInfo.Exists)
            {
                throw new Exception($"Directory ({patch}) already exist");
            }
            else
                Directory.CreateDirectory(patch);
        }
        public static void CreateFile(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);
            if (OnUpdate != null)
            {
                if (fileInfo.Exists)
                {
                    throw new Exception($"File {fileInfo.Name} created:\n");
                }
                else
                {
                    File.Create(patch);
                }
            }
        }

        public static void CopyFile(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);

            if (fileInfo.Exists)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string[] subPatch = patch.Split('.');

                stringBuilder = stringBuilder.Append(subPatch[0]);
                stringBuilder = stringBuilder.Append("Copy");
                stringBuilder = stringBuilder.Append(fileInfo.Extension);
                fileInfo.CopyTo(stringBuilder.ToString());
            }
        }

        public static void DeleteFile(string patch)
        {
            FileInfo fileInfo = new FileInfo(patch);

            if (fileInfo.Exists)
                fileInfo.Delete();
        }

        public static void CopyFileFromDirectory(string patch, string extension)
        {
            CreateDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSFiles");

            DirectoryInfo directoryInfo = new DirectoryInfo(patch);

            if (directoryInfo.Exists)
            {
                foreach (var file in directoryInfo.GetFiles())
                {
                    if (file.Extension == extension)
                    {
                        file.CopyTo("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSFiles\\" + file.Name);
                    }
                }
            }
        }

        public static void MoveDirectory(string patch_01, string patch_02)
        {
            if (!Directory.Exists(patch_01))
                throw new Exception($"Directory ({patch_01}) not find");

            Directory.Move(patch_01, patch_02);
        }

        public static void CreateZipFromDirectory(string patch)
        {
            string zipName = patch + ".zip";

            if (!Directory.Exists(patch))
                throw new Exception($"Directory ({patch}) not find");

            ZipFile.CreateFromDirectory(patch, zipName);

        }

        public static void ShowDirectoryFromZip(string patch_01, string patch_02)
        {
            if (patch_01.IndexOf(".zip") == -1)
                throw new Exception(".zip file not find");

            ZipFile.ExtractToDirectory(patch_01, patch_02);
        }

        public static void FindInformationFromDay(int dayUser, int hour,int action)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int count = 0;

            using (var stream = new StreamReader(@"C:\Users\noname\Desktop\123\OOP\lab12\knslogfile.txt"))
            {

                bool isActual = false;
                var textLine_01 = "";
                string line = "";
                var textData = "";
                
                    while (!stream.EndOfStream)
                    {
                        isActual = false;
                        textLine_01 = stream.ReadLine();
                        textLine_01 += stream.ReadLine();

                        textData = stream.ReadLine();

                        
                        if (Convert.ToInt32(textLine_01[35]) - 48 == action && action != 0 && DateTime.Parse(textData.Substring(13)).Hour == hour && DateTime.Parse(textData.Substring(13)).Day == dayUser)
                        {
                            isActual = true;
                        }
                        if (DateTime.Parse(textData.Substring(13)).Day == dayUser && DateTime.Parse(textData.Substring(13)).Hour == hour && action == 0)
                            isActual = true;

                        if (isActual)
                        {
                            count++;
                            stringBuilder.Append(textLine_01 + "\n\n" + textData);
                        }

                        line = stream.ReadLine();

                        while (line != "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><")
                        {
                            if (isActual)
                            {
                                stringBuilder.Append("\n");
                                stringBuilder.Append(line);

                            }

                            line = stream.ReadLine();
                        }

                        if (isActual) stringBuilder.Append("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><\n");
                    }
               
                

                
            }
            Console.WriteLine($"\n=========================\n");
            Console.WriteLine($"Fing Action = {count}");
            Console.WriteLine($"\n=========================\n");

            Console.Write(stringBuilder);
        }
    }
}
