namespace MiniDetour.NET;

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
        MiniDetourHookTRestoreOnDestroy,

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