using System;
using System.Runtime.InteropServices;

namespace MiniDetour;

// TODO: Disposable!
public class Hook 
{
    IntPtr handle { get; } = HookNative.Alloc();

    public bool CanHook(IntPtr functionToHook)
        => HookNative.CanHook(handle, functionToHook);

    public IntPtr HookFunction<TDelegate>(IntPtr functionToHook, TDelegate tdelegate) where TDelegate : notnull
        => HookFunction(functionToHook, Marshal.GetFunctionPointerForDelegate<TDelegate>(tdelegate));

    public IntPtr HookFunction(IntPtr functionToHook, IntPtr newFunction)
        => HookNative.HookFunction(handle, functionToHook, newFunction);
    
    public IntPtr RestoreFunction()
        => HookNative.RestoreFunction(handle);

    public IntPtr GetHookFunction()
        => HookNative.GetHookFunction(handle);

    public IntPtr GetOriginalFunction()
        => HookNative.GetOriginalFunction(handle);

    public static bool ReplaceFunction<TDelegate>(IntPtr functionToReplace, TDelegate tdelegate) where TDelegate : notnull
        => ReplaceFunction(functionToReplace, Marshal.GetFunctionPointerForDelegate<TDelegate>(tdelegate));

    public static bool ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction)
        => HookNative.ReplaceFunction(functionToReplace, newFunction);

    ~Hook()
    {
        if (handle == IntPtr.Zero)
            return;
        HookNative.Free(handle);
    }
}