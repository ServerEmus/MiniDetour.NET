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
    
    public static bool SafeMemoryRead(
        IntPtr address,
        byte[] buffer,
        UIntPtr size
    )
    {
        int isize = (int)size;
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        bool ret = SafeMemoryRead(address, handle.AddrOfPinnedObject(), size);
        handle.Free();
        return ret;
    }

        public static bool SafeMemoryWrite(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
        => MemoryManipulationNative.SafeMemoryWrite(address, buffer, size);
    
    public static bool SafeMemoryWrite(
        IntPtr address,
        byte[] buffer,
        UIntPtr size
    )
    {
        int isize = (int)size;
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        bool ret = SafeMemoryWrite(address, handle.AddrOfPinnedObject(), size);
        handle.Free();
        return ret;
    }

    public static UIntPtr WriteAbsoluteJump(
        IntPtr address,
        IntPtr destination
    )
        => MemoryManipulationNative.WriteAbsoluteJump(address, destination);

    public static int FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    )
        => MemoryManipulationNative.FlushInstructionCache(address, size);
}
