using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
