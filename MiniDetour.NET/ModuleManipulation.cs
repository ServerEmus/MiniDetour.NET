using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MiniDetour;

public static partial class ModuleManipulation
{
    public static UIntPtr GetAllExportedSymbols(
        IntPtr moduleHandle,
        UIntPtr exportDetailsCount,
        out ExportDetails[] exportDetails
    )
    {
        exportDetails = new ExportDetails[(int)exportDetailsCount];
        var gc = GCHandle.Alloc(exportDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_GetAllExportedSymbols(moduleHandle, gc.AddrOfPinnedObject(), exportDetailsCount);
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
        var gc = GCHandle.Alloc(iatDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        exportReplaceDetails = new IATDetails[(int)iatDetailsCount];
        var gc = GCHandle.Alloc(exportReplaceDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_ReplaceModuleExports(moduleHandle, gc.AddrOfPinnedObject(), exportReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        List<ExportReplaceParameter> exportReplaceDetails
    )
        => ReplaceModuleExports(moduleHandle, exportReplaceDetails.ToArray(), (UIntPtr)exportReplaceDetails.Count);

    public static UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
    {
        exportReplaceDetails = new IATDetails[(int)exportReplaceDetailsCount];
        var gc = GCHandle.Alloc(exportReplaceDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), exportReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        List<ExportReplaceParameter> exportReplaceDetails
    )
        => RestoreModuleExports(moduleHandle, exportReplaceDetails.ToArray(), (UIntPtr)exportReplaceDetails.Count);

    public static UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        iatReplaceDetails = new IATDetails[(int)iatReplaceDetailsCount];
        var gc = GCHandle.Alloc(iatReplaceDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        List<IATReplaceParameter> iatReplaceDetails
    )
        => ReplaceModuleIATs(moduleHandle, iatReplaceDetails.ToArray(), (UIntPtr)iatReplaceDetails.Count);

    public static UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    )
    {
        iatReplaceDetails = new IATDetails[(int)iatReplaceDetailsCount];
        var gc = GCHandle.Alloc(iatReplaceDetails, GCHandleType.Pinned);
        var ret = MiniDetourLoader.ModuleManipulation_GetAllIATSymbols(moduleHandle, gc.AddrOfPinnedObject(), iatReplaceDetailsCount);
        gc.Free();
        return ret;
    }

    public static UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        List<IATReplaceParameter> iatReplaceDetails
    )
        => RestoreModuleIATs(moduleHandle, iatReplaceDetails.ToArray(), (UIntPtr)iatReplaceDetails.Count);
}
