using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal static class KNSDiskInfo
    {
        public static event Action<string> OnUpdate;

        internal static void ShowFreeSpace(string diskName)
        {
            DriveInfo driveInfo = DriveInfo.GetDrives().Single(drive => drive.Name == diskName);
            OnUpdate($"Free space on the disk {driveInfo.Name} = {driveInfo.AvailableFreeSpace} bytes");
        }

        internal static void ShowFileSystemInformation(string diskName)
        {
            DriveInfo driveInfo = DriveInfo.GetDrives().Single(drive => drive.Name == diskName);

            OnUpdate($"File System Information {driveInfo.Name} :\n" +
                     $"Type: {driveInfo.DriveType}\n" +
                     $"Format: {driveInfo.DriveFormat}\n" +
                     $"TotalSize: {driveInfo.TotalSize} bytes\n");
        }
        internal static void ShowInformationAllDrivers()
        {
            var message = new StringBuilder("All drives information: \n\n");

            foreach (var drive in DriveInfo.GetDrives())
            {
                message.Append($"Disk {drive.Name}:\n\n" +
                               $"Type: {drive.DriveType}\n" +
                               $"Format: {drive.DriveFormat}\n" +
                               $"TotalSize: {drive.TotalSize} bytes\n" +
                               $"Free space: {drive.AvailableFreeSpace} bytes\n" +
                               $"- - - - - - - - - - - - - - - - - - - - -\n");
            }
            OnUpdate(message.ToString());
        }
    }
}
