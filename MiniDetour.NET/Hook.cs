using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

// TODO: Disposable!
public class Hook 
{
    IntPtr handle { get; } = MiniDetourLoader.Hook_Alloc();

    public bool CanHook(IntPtr functionToHook)
        => MiniDetourLoader.Hook_CanHook(handle, functionToHook);

    public IntPtr HookFunction<TDelegate>(IntPtr functionToHook, TDelegate tdelegate) where TDelegate : notnull
        => HookFunction(functionToHook, Marshal.GetFunctionPointerForDelegate<TDelegate>(tdelegate));

    public IntPtr HookFunction(IntPtr functionToHook, IntPtr newFunction)
        => MiniDetourLoader.Hook_HookFunction(handle, functionToHook, newFunction);
    
    public IntPtr RestoreFunction()
        => MiniDetourLoader.Hook_RestoreFunction(handle);

    public IntPtr GetHookFunction()
        => MiniDetourLoader.Hook_GetHookFunction(handle);

    public IntPtr GetOriginalFunction()
        => MiniDetourLoader.Hook_GetOriginalFunction(handle);

    public static bool ReplaceFunction<TDelegate>(IntPtr functionToReplace, TDelegate tdelegate) where TDelegate : notnull
        => ReplaceFunction(functionToReplace, Marshal.GetFunctionPointerForDelegate<TDelegate>(tdelegate));

    public static bool ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction)
        => MiniDetourLoader.Hook_ReplaceFunction(functionToReplace, newFunction);

    ~Hook()
    {
        if (handle == IntPtr.Zero)
            return;
        MiniDetourLoader.Hook_Free(handle);
    }
}