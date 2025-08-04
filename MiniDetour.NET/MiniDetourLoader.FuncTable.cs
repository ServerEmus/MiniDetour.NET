using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    internal static FunctionTable funcTable;

    /// <summary>
    /// Initializes the function table, automatically called. Do not call manually, only after <see cref="FreeApi"/>.
    /// </summary>
    public static void InitApi(INativeContext context)
    {
        funcTable = new FunctionTable(context, ());
        // Hook
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTAlloc, "MiniDetourHookTAlloc");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTFree, "MiniDetourHookTFree");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTCanHook, "MiniDetourHookTCanHook");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTHookFunction, "MiniDetourHookTHookFunction");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTRestoreFunction, "MiniDetourHookTRestoreFunction");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTGetHookFunction, "MiniDetourHookTGetHookFunction");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTGetOriginalFunction, "MiniDetourHookTGetOriginalFunction");
        funcTable.Load((int)FuncTableFunction.MiniDetourHookTReplaceFunction, "MiniDetourHookTReplaceFunction");

        // MemoryManipulation
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationMemoryProtect, "MiniDetourMemoryManipulationMemoryProtect");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationMemoryFree, "MiniDetourMemoryManipulationMemoryFree");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationMemoryAlloc, "MiniDetourMemoryManipulationMemoryAlloc");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryRead, "MiniDetourMemoryManipulationSafeMemoryRead");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationSafeMemoryWrite, "MiniDetourMemoryManipulationSafeMemoryWrite");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationWriteAbsoluteJump, "MiniDetourMemoryManipulationWriteAbsoluteJump");
        funcTable.Load((int)FuncTableFunction.MiniDetourMemoryManipulationFlushInstructionCache, "MiniDetourMemoryManipulationFlushInstructionCache");

        // ModuleManipulator
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationGetAllExportedSymbols, "MiniDetourModuleManipulationGetAllExportedSymbols");
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationGetAllIATSymbols, "MiniDetourModuleManipulationGetAllIATSymbols");
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationReplaceModuleExports, "MiniDetourModuleManipulationReplaceModuleExports");
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationRestoreModuleExports, "MiniDetourModuleManipulationRestoreModuleExports");
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationReplaceModuleIATs, "MiniDetourModuleManipulationReplaceModuleIATs");
        funcTable.Load((int)FuncTableFunction.MiniDetourModuleManipulationRestoreModuleIATs, "MiniDetourModuleManipulationRestoreModuleIATs");
        // Utls
        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageRoundUp, "MiniDetourUtilsPageRoundUp");
        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageRound, "MiniDetourUtilsPageRound");
        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageSize, "MiniDetourUtilsPageSize");
    }

    public static void FreeApi()
    {
        funcTable.Free();
    }
}