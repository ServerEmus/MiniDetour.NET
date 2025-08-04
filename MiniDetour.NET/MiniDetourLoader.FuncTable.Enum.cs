using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace MiniDetour;

public static unsafe partial class MiniDetourLoader
{
    internal enum FuncTableFunction
    {
        // Hooks
        MiniDetourHookTAlloc,
        MiniDetourHookTFree,
        MiniDetourHookTCanHook,
        MiniDetourHookTHookFunction,
        MiniDetourHookTRestoreFunction,
        MiniDetourHookTGetHookFunction,
        MiniDetourHookTGetOriginalFunction,
        MiniDetourHookTReplaceFunction,

        // MemoryManipulation
        MiniDetourMemoryManipulationMemoryProtect,
        MiniDetourMemoryManipulationMemoryFree,
        MiniDetourMemoryManipulationMemoryAlloc,
        MiniDetourMemoryManipulationSafeMemoryRead,
        MiniDetourMemoryManipulationSafeMemoryWrite,
        MiniDetourMemoryManipulationWriteAbsoluteJump,
        MiniDetourMemoryManipulationFlushInstructionCache,

        // ModuleManipulation
        MiniDetourModuleManipulationGetAllExportedSymbols,
        MiniDetourModuleManipulationGetAllIATSymbols,
        MiniDetourModuleManipulationReplaceModuleExports,
        MiniDetourModuleManipulationRestoreModuleExports,
        MiniDetourModuleManipulationReplaceModuleIATs,
        MiniDetourModuleManipulationRestoreModuleIATs,

        // Utils
        MiniDetourUtilsPageRoundUp,
        MiniDetourUtilsPageRound,
        MiniDetourUtilsPageSize,

        MAX
    }
}