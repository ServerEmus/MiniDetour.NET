using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniDetour;

internal static class HookNative
{
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTAlloc", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr Alloc();

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTFree", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void Free(IntPtr handle);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTCanHook", CallingConvention = CallingConvention.Cdecl)]
    internal static extern bool CanHook(IntPtr handle, IntPtr functionToHook);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTHookFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr HookFunction(IntPtr handle, IntPtr functionToHook, IntPtr newFunction);
    
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTRestoreFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr RestoreFunction(IntPtr handle);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTGetHookFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr GetHookFunction(IntPtr handle);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTGetOriginalFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr GetOriginalFunction(IntPtr handle);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourHookTReplaceFunction", CallingConvention = CallingConvention.Cdecl)]
    internal static extern bool ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction);
}