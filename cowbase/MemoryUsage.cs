using System;

using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace cowbase
{
    public class MemoryUsage
    {
        private ulong totalStorageMemory = 0;
        private ulong freeStorageMemory = 0;
        private long totalProgramMemory = -1;
        private long freeProgramMemory = 0;

#if !COWBASEMOCK
        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
        out ulong lpFreeBytesAvailable,
        out ulong lpTotalNumberOfBytes,
        out ulong lpTotalNumberOfFreeBytes);
#endif


        public MemoryUsage()
        {
            Refresh();
        }

        public void Refresh()
        {
#if !COWBASEMOCK
            //int memoryLoad = OpenNETCF.WindowsCE.MemoryManagement.MemoryLoad;
            freeProgramMemory = OpenNETCF.WindowsCE.MemoryManagement.AvailablePhysicalMemory;
            //int avm = OpenNETCF.WindowsCE.MemoryManagement.AvailableVirtualMemory;
            //int spm = OpenNETCF.WindowsCE.MemoryManagement.SystemProgramMemory;
            //int ssm = OpenNETCF.WindowsCE.MemoryManagement.SystemStorageMemory;
            totalProgramMemory = OpenNETCF.WindowsCE.MemoryManagement.TotalPhysicalMemory;
            //int tvm = OpenNETCF.WindowsCE.MemoryManagement.TotalVirtualMemory;

            ulong FreeBytesAvailable;
            ulong TotalNumberOfBytes;
            ulong TotalNumberOfFreeBytes;
                      

            bool success = GetDiskFreeSpaceEx("\\", out FreeBytesAvailable, out TotalNumberOfBytes,
                               out TotalNumberOfFreeBytes);
            if (success)
            {
                totalStorageMemory = TotalNumberOfBytes;
                freeStorageMemory = FreeBytesAvailable;
            }
            else
            {
                totalStorageMemory = 0;
                freeStorageMemory = 0;
            }
#else
            totalStorageMemory = 0;
            freeStorageMemory = 0;
#endif

        }

        public ulong GetTotalStorageMemory()
        {
            return totalStorageMemory;
        }

        public ulong GetFreeStorageMemory()
        {
            return freeStorageMemory;
        }

        public double GetStorageMemoryUsage()
        {
            if (totalStorageMemory != 0)
            {
                return ((double)(totalStorageMemory - freeStorageMemory) / totalStorageMemory);
            }

            return 0;
        }

        public double GetProgramMemoryUsage()
        {
            return (double)(totalProgramMemory - freeProgramMemory) / (double)totalProgramMemory;
        }

        public long GetTotalProgramMemory()
        {
            return totalProgramMemory;
        }

        public long GetFreeProgramMemory()
        {
            return freeProgramMemory;
        }

        public override string ToString()
        {
            return "PROG: TOTL=" + GetTotalProgramMemory() +
                ", FREE=" + GetFreeProgramMemory() + " (" + Utils.FormatFloat(GetProgramMemoryUsage()*100, 2) + "%); " +
                "STRG: TOTL=" + GetTotalStorageMemory() + 
                ", FREE=" + GetFreeStorageMemory() + " (" + Utils.FormatFloat(GetStorageMemoryUsage()*100, 2) + "%)";
        }

    }
}
