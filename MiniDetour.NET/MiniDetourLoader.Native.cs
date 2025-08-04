using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    delegate IntPtr AllocDelegate();

    public static IntPtr Hook_Alloc()
    {
        AllocDelegate d = Marshal.GetDelegateForFunctionPointer<AllocDelegate>(funcTable[FuncTableFunction.MiniDetourHookTAlloc]);
        return d();
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

    public static void MemoryManipulation_MemoryFree(
        IntPtr address,
        UIntPtr size
    )
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, void>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(address, size);
    }
    public static IntPtr MemoryManipulation_MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryRights rights
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, MemoryRights, IntPtr>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(addressHint, size, rights);
    }

    public static bool MemoryManipulation_SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr, bool>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryRead])(address, buffer, size);
    }

    public static bool MemoryManipulation_SafeMemoryWrite(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr, bool>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryWrite])(address, buffer, size);
    }

    public static UIntPtr MemoryManipulation_WriteAbsoluteJump(
        IntPtr address,
        IntPtr destination
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationWriteAbsoluteJump])(address, destination);
    }

    public static int MemoryManipulation_FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, int>)funcTable[FuncTableFunction.MiniDetourMemoryManipulationFlushInstructionCache])(address, size);
    }



    internal static IntPtr Utils_PageRoundUp(IntPtr address, UIntPtr pageSize)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourUtilsPageRoundUp])(address, pageSize);
    }

    internal static IntPtr Utils_PageRound(IntPtr address, UIntPtr pageSize)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, IntPtr>)funcTable[FuncTableFunction.MiniDetourUtilsPageRound])(address, pageSize);
    }

    internal static UIntPtr Utils_PageSize()
    {
        return ((delegate* unmanaged[Cdecl]<void, UIntPtr>)funcTable[FuncTableFunction.MiniDetourUtilsPageSize])();
    }
}