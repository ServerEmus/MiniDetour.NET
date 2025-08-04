using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    public static IntPtr Hook_Alloc()
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr>)funcTable[FuncTableFunction.MiniDetourHookTAlloc])();
    }

    public static void Hook_Free(IntPtr handle)
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, void>)funcTable[FuncTableFunction.MiniDetourHookTFree])(handle);
    }

    public static bool Hook_CanHook(IntPtr handle, IntPtr functionToHook)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>)funcTable[FuncTableFunction.MiniDetourHookTCanHook])(handle, functionToHook);
    }

    public static IntPtr Hook_HookFunction(IntPtr handle, IntPtr functionToHook, IntPtr newFunction)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourHookTHookFunction])(handle, functionToHook, newFunction);
    }

    public static IntPtr Hook_RestoreFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourHookTRestoreFunction])(handle);
    }

    public static IntPtr Hook_GetHookFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourHookTGetHookFunction])(handle);
    }

    public static IntPtr Hook_GetOriginalFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourHookTGetOriginalFunction])(handle);
    }

    public static bool Hook_ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>)funcTable[FuncTableFunction.MiniDetourHookTReplaceFunction])(functionToReplace, newFunction);
    }

    public static bool MemoryManipulation_MemoryProtect(
        IntPtr address,
        UIntPtr size,
        MemoryRights rights,
        out MemoryRights old_rights
    )
    {
        old_rights =  MemoryRights.None;
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, MemoryManipulation.MemoryRights, MemoryManipulation.MemoryRights*, bool>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationMemoryProtect])(address, size, rights, &old_rights);
    }

    public static void MemoryFree(
        IntPtr address,
        UIntPtr size
    )
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, void>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(address, size);
    }
    public static IntPtr MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryRights rights
    )
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, MemoryRights, IntPtr>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(addressHint, size, rights);
    }
/*
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
    */
}