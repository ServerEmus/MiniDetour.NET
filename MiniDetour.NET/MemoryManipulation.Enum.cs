using System;

namespace MiniDetour;

public static partial class MemoryManipulation
{
    [Flags]
    public enum MemoryRights
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        ReadWrite = Read | Write,
        ReadExecute = Read | Execute,
        WriteExecute = Write | Execute,
        ReadWriteExecute = Read | Write | Execute,
        Unset = 8,
    }
}