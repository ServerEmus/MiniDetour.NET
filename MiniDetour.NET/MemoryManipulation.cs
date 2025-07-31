using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

public static partial class MemoryManipulation
{
   public static bool MemoryProtect(
        IntPtr address,
        UIntPtr size,
        MemoryManipulation.MemoryRights rights,
        out MemoryManipulation.MemoryRights old_rights
    )
        => MemoryManipulationNative.MemoryProtect(address, size, rights, out old_rights);

    public static void MemoryFree(
        IntPtr address,
        UIntPtr size
    )
        => MemoryManipulationNative.MemoryFree(address, size);

    public static IntPtr MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryManipulation.MemoryRights rights
    )
        => MemoryManipulationNative.MemoryAlloc(addressHint, size, rights);

    public static bool SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
        => MemoryManipulationNative.SafeMemoryRead(address, buffer, size);
    
    // This need test.
    public static bool SafeMemoryRead(
        IntPtr address,
        byte[] buffer,
        UIntPtr size,
    )
    {
        int isize = (int)size;
        IntPtr bufferptr = Marshal.AllocHGlobal(isize);
        bool ret = SafeMemoryRead(address, bufferptr, size);
        Marshal.Copy(bufferptr, buffer, 0, isize);
        Marshal.FreeHGlobal(bufferptr);
        return ret;
    }
}
