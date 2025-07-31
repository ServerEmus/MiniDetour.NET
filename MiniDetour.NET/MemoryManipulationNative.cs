using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

internal static class MemoryManipulationNative
{
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationMemoryProtect", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool MemoryProtect(
        IntPtr address,
        UIntPtr size,
        MemoryManipulation.MemoryRights rights,
        out MemoryManipulation.MemoryRights old_rights
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationMemoryFree", CallingConvention = CallingConvention.Cdecl)]
    public static extern void MemoryFree(
        IntPtr address,
        UIntPtr size
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationMemoryAlloc", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryManipulation.MemoryRights rights
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationSafeMemoryRead", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationSafeMemoryWrite", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SafeMemoryWrite(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationWriteAbsoluteJump", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr WriteAbsoluteJump(
        IntPtr address,
        IntPtr destination
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourMemoryManipulationFlushInstructionCache", CallingConvention = CallingConvention.Cdecl)]
    public static extern int FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    );
}