using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ZidiumServerMonitor
{
    public static class FreeSpaceHelper
    {
        public static long? GetDriveFreeSpace(string drive)
        {
            DriveInfo di;

            try
            {
                di = new DriveInfo(drive);
            }
            catch
            {
                var comparison = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? StringComparison.OrdinalIgnoreCase
                    : StringComparison.Ordinal;

                var drives = DriveInfo.GetDrives();
                di = drives.OrderBy(t => t.Name.Length).FirstOrDefault(t => t.Name.StartsWith(drive, comparison));

                if (di == null)
                    return null;
            }

            return di.AvailableFreeSpace;
        }
    }
}
