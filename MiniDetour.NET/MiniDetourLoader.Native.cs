using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    delegate IntPtr IntPtrVoidDelegate();
    delegate UIntPtr UIntPtrVoidDelegate();

    public static IntPtr Hook_Alloc()
    {
        IntPtrVoidDelegate d = Marshal.GetDelegateForFunctionPointer<IntPtrVoidDelegate>((IntPtr)funcTable[(int)FuncTableFunction.MiniDetourHookTAlloc]);
        return d();
    }

    public static void Hook_Free(IntPtr handle)
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, void>)funcTable[(int)FuncTableFunction.MiniDetourHookTFree])(handle);
    }

    public static bool Hook_CanHook(IntPtr handle, IntPtr functionToHook)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>)funcTable[(int)FuncTableFunction.MiniDetourHookTCanHook])(handle, functionToHook);
    }

    public static IntPtr Hook_HookFunction(IntPtr handle, IntPtr functionToHook, IntPtr newFunction)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourHookTHookFunction])(handle, functionToHook, newFunction);
    }

    public static IntPtr Hook_RestoreFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourHookTRestoreFunction])(handle);
    }

    public static IntPtr Hook_GetHookFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourHookTGetHookFunction])(handle);
    }

    public static IntPtr Hook_GetOriginalFunction(IntPtr handle)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourHookTGetOriginalFunction])(handle);
    }

    public static bool Hook_ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>)funcTable[(int)FuncTableFunction.MiniDetourHookTReplaceFunction])(functionToReplace, newFunction);
    }

    public static bool MemoryManipulation_MemoryProtect(
        IntPtr address,
        UIntPtr size,
        MemoryRights rights,
        out MemoryRights old_rights
    )
    {
        old_rights =  MemoryRights.None;
        fixed (MemoryRights* out_ptr = &old_rights)
        {
            return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, MemoryRights, MemoryRights*, bool>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationMemoryProtect])(address, size, rights, out_ptr);
        }    
    }

    public static void MemoryManipulation_MemoryFree(
        IntPtr address,
        UIntPtr size
    )
    {
        ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, void>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(address, size);
    }
    public static IntPtr MemoryManipulation_MemoryAlloc(
        IntPtr addressHint,
        UIntPtr size,
        MemoryRights rights
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, MemoryRights, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationMemoryFree])(addressHint, size, rights);
    }

    public static bool MemoryManipulation_SafeMemoryRead(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr, bool>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryRead])(address, buffer, size);
    }

    public static bool MemoryManipulation_SafeMemoryWrite(
        IntPtr address,
        IntPtr buffer,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr, bool>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryWrite])(address, buffer, size);
    }

    public static UIntPtr MemoryManipulation_WriteAbsoluteJump(
        IntPtr address,
        IntPtr destination
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationWriteAbsoluteJump])(address, destination);
    }

    public static int MemoryManipulation_FlushInstructionCache(
        IntPtr address,
        UIntPtr size
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, int>)funcTable[(int)FuncTableFunction.MiniDetourMemoryManipulationFlushInstructionCache])(address, size);
    }


    public static UIntPtr ModuleManipulation_GetAllExportedSymbols(
        IntPtr moduleHandle,
        IntPtr exportDetails,
        UIntPtr exportDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationGetAllExportedSymbols])
        (moduleHandle, exportDetails, exportDetailsCount);
    }

    public static UIntPtr ModuleManipulation_GetAllIATSymbols(
        IntPtr moduleHandle,
        IntPtr iatDetails,
        UIntPtr iatDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationGetAllIATSymbols])
        (moduleHandle, iatDetails, iatDetailsCount);
    }

    public static UIntPtr ModuleManipulation_ReplaceModuleExports(
        IntPtr moduleHandle,
        IntPtr exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationReplaceModuleExports])
        (moduleHandle, exportReplaceDetails, exportReplaceDetailsCount);
    }

    public static UIntPtr ModuleManipulation_RestoreModuleExports(
        IntPtr moduleHandle,
        IntPtr exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationRestoreModuleExports])
        (moduleHandle, exportReplaceDetails, exportReplaceDetailsCount);
    }

    public static UIntPtr ModuleManipulation_ReplaceModuleIATs(
        IntPtr moduleHandle,
        IntPtr iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationReplaceModuleIATs])
        (moduleHandle, iatReplaceDetails, iatReplaceDetailsCount);
    }

    public static UIntPtr ModuleManipulation_RestoreModuleIATs(
        IntPtr moduleHandle,
        IntPtr iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, UIntPtr ,UIntPtr>)funcTable
        [(int)FuncTableFunction.MiniDetourModuleManipulationRestoreModuleIATs])
        (moduleHandle, iatReplaceDetails, iatReplaceDetailsCount);
    }

    internal static IntPtr Utils_PageRoundUp(IntPtr address, UIntPtr pageSize)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourUtilsPageRoundUp])(address, pageSize);
    }

    internal static IntPtr Utils_PageRound(IntPtr address, UIntPtr pageSize)
    {
        return ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr, IntPtr>)funcTable[(int)FuncTableFunction.MiniDetourUtilsPageRound])(address, pageSize);
    }

    internal static UIntPtr Utils_PageSize()
    {
        UIntPtrVoidDelegate d = Marshal.GetDelegateForFunctionPointer<UIntPtrVoidDelegate>((IntPtr)funcTable[(int)FuncTableFunction.MiniDetourUtilsPageSize]);
        return d();
    }
}