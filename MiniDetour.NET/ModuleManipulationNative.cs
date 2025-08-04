using System;
using System.Runtime.InteropServices;

namespace MiniDetour;
/*
internal static class ModuleManipulationNative
{
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationGetAllExportedSymbols", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr GetAllExportedSymbols(
        IntPtr moduleHandle,
        [Out] ModuleManipulation.ExportDetails[] exportDetails,
        UIntPtr exportDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationGetAllIATSymbols", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr GetAllIATSymbols(
        IntPtr moduleHandle,
        [Out] ModuleManipulation.IATDetails[] iatDetails,
        UIntPtr iatDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationReplaceModuleExports", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr ReplaceModuleExports(
        IntPtr moduleHandle,
        [In] ModuleManipulation.ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationRestoreModuleExports", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr RestoreModuleExports(
        IntPtr moduleHandle,
        [In] ModuleManipulation.ExportReplaceParameter[] exportReplaceDetails,
        UIntPtr exportReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationReplaceModuleIATs", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr ReplaceModuleIATs(
        IntPtr moduleHandle,
        [In] ModuleManipulation.IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    );

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourModuleManipulationRestoreModuleIATs", CallingConvention = CallingConvention.Cdecl)]
    public static extern UIntPtr RestoreModuleIATs(
        IntPtr moduleHandle,
        [In] ModuleManipulation.IATReplaceParameter[] iatReplaceDetails,
        UIntPtr iatReplaceDetailsCount
    );
}
*/