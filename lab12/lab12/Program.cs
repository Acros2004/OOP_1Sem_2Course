using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab12
{
     internal class Programm
    {
        static void Main()
        {
            
            try
            {
                //KNSLog knsLog_01 = new KNSLog("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\knslogfile.txt");
                //KNSDiskInfo.OnUpdate += knsLog_01.WriteActionInFile;
                //KNSFileInfo.OnUpdate += knsLog_01.WriteActionInFile;
                //KNSDirInfo.OnUpdate += knsLog_01.WriteActionInFile;

                ////test DiskInfo
                //KNSDiskInfo.ShowFreeSpace(@"D:\");
                //KNSDiskInfo.ShowFileSystemInformation(@"D:\");
                //KNSDiskInfo.ShowInformationAllDrivers();

                ////test FileInfo
                //KNSFileInfo.ShowFullPatch("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\knslogfile.txt");
                //KNSFileInfo.ShowFileInformation("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\knslogfile.txt");
                //KNSFileInfo.ShowFileDatesCreateAndUpdate("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\knslogfile.txt");

                ////test DirInfo
                //KNSDirInfo.ShowAmountOfFile("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12");
                //KNSDirInfo.ShowCreationTime("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12");
                //KNSDirInfo.ShowAmountOfSubdirectories("C:\\Users\\noname\\Desktop\\123\\OOP");
                //KNSDirInfo.ShowParentDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12");

                ////test FileManger
                //KNSFileManager.CreateDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect");
                //KNSFileManager.CreateFile("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12KNSInspect\\knsdirinfo.txt");

                //KNSLog knsLog_02 = new KNSLog("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect\\knsdirinfo.txt");

                //KNSFileManager.OnUpdate += knsLog_02.WriteActionInFile;

                //KNSFileManager.ShowListDirectoryAndFileDisk("D:\\");
                //KNSFileManager.CopyFile("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect\\knsdirinfo.txt");
                //KNSFileManager.DeleteFile("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect\\knsdirinfo.txt");
                //KNSFileManager.CopyFileFromDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect", ".txt");

                //KNSFileManager.MoveDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSFiles\\", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect\\KNSFiles");

                //KNSFileManager.CreateZipFromDirectory("C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\KNSInspect\\KNSFiles");

                //KNSFileManager.ShowDirectoryFromZip(@"C:\Users\noname\Desktop\123\OOP\lab12\KNSInspect\KNSFiles.zip", "C:\\Users\\noname\\Desktop\\123\\OOP\\lab12\\UnArhive");

                Console.WriteLine("Enter day: ");
                int dayUser = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter hour: ");
                int hourUser = int.Parse(Console.ReadLine());
               
                KNSFileManager.FindInformationFromDay(dayUser,hourUser,0);
                Console.WriteLine("=======================================================================");
                Console.WriteLine("Enter number of action: ");
                int actionUser = int.Parse(Console.ReadLine());
                KNSFileManager.FindInformationFromDay(dayUser,hourUser,actionUser);
                Console.WriteLine();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}