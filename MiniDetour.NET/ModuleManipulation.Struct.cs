using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

public static partial class ModuleManipulation
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ExportDetails
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string ExportName;
        public uint ExportOrdinal;
        public IntPtr ExportCallAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IATDetails
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string ImportModuleName;
        [MarshalAs(UnmanagedType.LPStr)]
        public string ImportName;
        public uint ImportOrdinal;
        public IntPtr ImportCallAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ExportReplaceParameter
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string ExportName;
        public IntPtr NewExportAddress;
        public IntPtr ExportCallAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IATReplaceParameter
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string IATModuleName;
        [MarshalAs(UnmanagedType.LPStr)]
        public string IATName;
        public ushort IATOrdinal;
        public IntPtr NewIATAddress;
        public IntPtr IATCallAddress;
    }
}
