using System;
using System.Runtime.InteropServices;

namespace MiniDetour.NET;

public static partial class MemoryManipulation
{
    /// <summary>
    /// Changes memory protection. (On Linux, address and rights will be aligned to page size, it is required or it will fail)
    /// </summary>
    /// <param name="address"></param>
    /// <param name="size"></param>
    /// <param name="rights"></param>
    /// <param name="old_rights"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Safely read memory, it doesn't mean it will always succeed, only that on memory not readable or no allocated, it will not crash your application.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static bool SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_SafeMemoryRead(address, buffer, size);

    /// <summary>
    /// Safely read memory, it doesn't mean it will always succeed, only that on memory not readable or no allocated, it will not crash your application.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static bool SafeMemoryRead(
        IntPtr address,
        byte[] buffer,
        UIntPtr size
    )
    {
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        bool ret = SafeMemoryRead(address, handle.AddrOfPinnedObject(), size);
        handle.Free();
        return ret;
    }

    /// <summary>
    /// Safely write memory, it doesn't mean it will always succeed, only that on memory not writable or no allocated, it will not crash your application.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static bool SafeMemoryWrite(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_SafeMemoryWrite(address, buffer, size);

    /// <summary>
    /// Safely write memory, it doesn't mean it will always succeed, only that on memory not writable or no allocated, it will not crash your application.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static bool SafeMemoryWrite(
        IntPtr address,
        byte[] buffer,
        UIntPtr size
    )
    {
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        bool ret = SafeMemoryWrite(address, handle.AddrOfPinnedObject(), size);
        handle.Free();
        return ret;
    }

    /// <summary>
    /// Convenient function to write an absolute jump at an address. Pass NULL in address to get the required size of the absolute jump in bytes.
    /// </summary>
    /// <param name="address">Where to write the jump</param>
    /// <param name="destination">Where should to jump to</param>
    /// <returns>The needed size</returns>
    public static UIntPtr WriteAbsoluteJump(
        IntPtr address,
        IntPtr destination
    )
        => MiniDetourLoader.MemoryManipulation_WriteAbsoluteJump(address, destination);

    /// <summary>
    /// Flush the instruction cache. (only implemented on Windows)
    /// </summary>
    /// <param name="address"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static int FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    )
        => MiniDetourLoader.MemoryManipulation_FlushInstructionCache(address, size);
}
