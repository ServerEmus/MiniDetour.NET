using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MiniDetour;
/*
public static partial class ModuleManipulation
{
    public static UIntPtr GetAllExportedSymbols(
        IntPtr moduleHandle,
        UIntPtr exportDetailsCount,
        out ExportDetails[] exportDetails
    )
    {
        exportDetails = new ExportDetails[(int)exportDetailsCount];
        return ModuleManipulationNative.GetAllExportedSymbols(moduleHandle, exportDetails, exportDetailsCount);
    }

    public static UIntPtr GetAllIATSymbols(
        IntPtr moduleHandle,
        UIntPtr iatDetailsCount,
        out IATDetails[] iatDetails
    )
    {
        iatDetails = new IATDetails[(int)iatDetailsCount];
        return ModuleManipulationNative.GetAllIATSymbols(moduleHandle, iatDetails, iatDetailsCount);
    }

    public static UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    )
        => ModuleManipulationNative.ReplaceModuleExports(moduleHandle, exportReplaceDetails, exportReplaceDetailsCount);

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
        => ModuleManipulationNative.RestoreModuleExports(moduleHandle, exportReplaceDetails, exportReplaceDetailsCount);

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
        => ModuleManipulationNative.ReplaceModuleIATs(moduleHandle, iatReplaceDetails, iatReplaceDetailsCount);

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
        => ModuleManipulationNative.RestoreModuleIATs(moduleHandle, iatReplaceDetails, iatReplaceDetailsCount);

    public static UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        List<IATReplaceParameter> iatReplaceDetails
    )
        => RestoreModuleIATs(moduleHandle, iatReplaceDetails.ToArray(), (UIntPtr)iatReplaceDetails.Count);
}
*/