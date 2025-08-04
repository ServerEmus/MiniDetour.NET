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
        funcTable = new FunctionTable(context, 1);
        // Hook
        funcTable.Load(0, "MiniDetourHookTAlloc");
        funcTable.Load(1, "MiniDetourHookTFree");
        funcTable.Load(2, "MiniDetourHookTCanHook");
        funcTable.Load(3, "MiniDetourHookTHookFunction");
        funcTable.Load(4, "MiniDetourHookTRestoreFunction");
        funcTable.Load(5, "MiniDetourHookTGetHookFunction");
        funcTable.Load(6, "MiniDetourHookTGetOriginalFunction");
        funcTable.Load(7, "MiniDetourHookTReplaceFunction");

        // MemoryManipulation
        funcTable.Load(8, "MiniDetourMemoryManipulationMemoryProtect");
        funcTable.Load(9, "MiniDetourMemoryManipulationMemoryFree");
        funcTable.Load(10, "MiniDetourMemoryManipulationMemoryAlloc");
        funcTable.Load(11, "MiniDetourMemoryManipulationSafeMemoryRead");
        funcTable.Load(12, "MiniDetourMemoryManipulationSafeMemoryWrite");
        funcTable.Load(13, "MiniDetourMemoryManipulationWriteAbsoluteJump");
        funcTable.Load(14, "MiniDetourMemoryManipulationFlushInstructionCache");

        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageRoundUp, "MiniDetourUtilsPageRoundUp");
        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageRound, "MiniDetourUtilsPageRound");
        funcTable.Load((int)FuncTableFunction.MiniDetourUtilsPageSize, "MiniDetourUtilsPageSize");

    }

    public static void FreeApi()
    {
        funcTable.Free();
    }
}