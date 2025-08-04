using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MiniDetour.NET;

public static partial class ModuleManipulation
{
    public static UIntPtr GetAllExportedSymbols(
        IntPtr moduleHandle,
        UIntPtr exportDetailsCount,
        out ExportDetails[] exportDetails
    )
    {
        exportDetails = new ExportDetails[(int)exportDetailsCount];
        GCHandle gc = GCHandle.Alloc(exportDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_GetAllExportedSymbols(moduleHandle, gc.AddrOfPinnedObject(), exportDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr GetAllIATSymbols(
        IntPtr moduleHandle,
        UIntPtr iatDetailsCount,
        out IATDetails[] iatDetails
    )
    {
        iatDetails = new IATDetails[(int)iatDetailsCount];
        GCHandle gc = GCHandle.Alloc(iatDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        GCHandle gc = GCHandle.Alloc(exportReplaceDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_ReplaceModuleExports(moduleHandle, gc.AddrOfPinnedObject(), exportReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        List<ExportReplaceParameter> exportReplaceDetails
    )
        => ReplaceModuleExports(moduleHandle, [.. exportReplaceDetails], (UIntPtr)exportReplaceDetails.Count);

    public static UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        GCHandle gc = GCHandle.Alloc(exportReplaceDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), exportReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        List<ExportReplaceParameter> exportReplaceDetails
    )
        => RestoreModuleExports(moduleHandle, [.. exportReplaceDetails], (UIntPtr)exportReplaceDetails.Count);

    public static UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        GCHandle gc = GCHandle.Alloc(iatReplaceDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        List<IATReplaceParameter> iatReplaceDetails
    )
        => ReplaceModuleIATs(moduleHandle, [.. iatReplaceDetails], (UIntPtr)iatReplaceDetails.Count);

    public static UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        GCHandle gc = GCHandle.Alloc(iatReplaceDetails, GCHandleType.Pinned);
        UIntPtr ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        List<IATReplaceParameter> iatReplaceDetails
    )
        => RestoreModuleIATs(moduleHandle, [.. iatReplaceDetails], (UIntPtr)iatReplaceDetails.Count);
}
