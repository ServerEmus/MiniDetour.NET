using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    delegate IntPtr IntPtrVoidDelegate();

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


    public static UIntPtr GetAllExportedSymbols(
        IntPtr moduleHandle,
        ModuleManipulation.ExportDetails[] exportDetails,
        UIntPtr exportDetailsCount
    )
    {
        fixed (ModuleManipulation.ExportDetails* ptr = exportDetails)
        {
            return ((delegate* unmanaged[Cdecl]<IntPtr, ModuleManipulation.ExportDetails*, UIntPtr,UIntPtr>)funcTable[(int)FuncTableFunction.MiniDetourModuleManipulationGetAllExportedSymbols])(moduleHandle, ptr, exportDetailsCount);
        }
    }
/*
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationGetAllIATSymbols", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr GetAllIATSymbols(
        IntPtr moduleHandle,
        ModuleManipulation.IATDetails[] iatDetails,
        UIntPtr iatDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationReplaceModuleExports", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        ModuleManipulation.ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationRestoreModuleExports", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        ModuleManipulation.ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationReplaceModuleIATs", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        ModuleManipulation.IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationRestoreModuleIATs", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        ModuleManipulation.IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    );
*/
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
        IntPtrVoidDelegate d = Marshal.GetDelegateForFunctionPointer<IntPtrVoidDelegate>((IntPtr)funcTable[(int)FuncTableFunction.MiniDetourUtilsPageSize]);
        return d();
    }
}