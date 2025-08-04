using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

public static partial class MemoryManipulation
{
   public static bool MemoryProtect(
        IntPtr address,
        UIntPtr size,
        MemoryRights rights,
        out MemoryRights old_rights
    )
        => MiniDetourLoader.MemoryManipulation_MemoryProtect(address, size, rights, out old_rights);

    public static void MemoryFree(
        IntPtr address,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_MemoryFree(address, size);

    public static IntPtr MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryRights rights
    )
        => MiniDetourLoader.MemoryManipulation_MemoryAlloc(addressHint, size, rights);

    public static bool SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_SafeMemoryRead(address, buffer, size);
    
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
        => MiniDetourLoader.MemoryManipulation_SafeMemoryWrite(address, buffer, size);
    
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
        => MiniDetourLoader.MemoryManipulation_WriteAbsoluteJump(address, destination);

    public static int FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_FlushInstructionCache(address, size);
}
