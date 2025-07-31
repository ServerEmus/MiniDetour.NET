using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniDetour;

internal static class HookNative
{
    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTAlloc", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr Alloc();

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTFree", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void Free(IntPtr handle);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTCanHook", CallingConvention = CallingConvention.Cdecl)]
    internal static extern bool CanHook(IntPtr handle, IntPtr functionToHook);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTHookFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr HookFunction(IntPtr handle, IntPtr function_to_hook, IntPtr new_function);
    
    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTRestoreFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr RestoreFunction(IntPtr handle);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTGetHookFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr GetHookFunction(IntPtr handle);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTGetOriginalFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr GetOriginalFunction(IntPtr handle);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTReplaceFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern bool ReplaceFunction(IntPtr function_to_replace, IntPtr new_function);
}