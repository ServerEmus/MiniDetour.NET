using System;
using System.Runtime.InteropServices;

namespace MiniDetour.NET;

public class Hook : IDisposable
{
    public Hook()
    {
        Handle = MiniDetourLoader.Hook_Alloc();
    }

    public Hook(bool autoRestore) : this()
    {
        RestoreOnDestroy(autoRestore);
    }

    private bool _disposed;
    private IntPtr Handle { get; } = MiniDetourLoader.Hook_Alloc();

    public bool CanHook(IntPtr functionToHook)
        => MiniDetourLoader.Hook_CanHook(Handle, functionToHook);

    public IntPtr HookFunction<TDelegate>(IntPtr functionToHook, TDelegate tdelegate) where TDelegate : notnull
        => HookFunction(functionToHook, Marshal.GetFunctionPointerForDelegate(tdelegate));

    public IntPtr HookFunction(IntPtr functionToHook, IntPtr newFunction)
        => MiniDetourLoader.Hook_HookFunction(Handle, functionToHook, newFunction);
    
    public IntPtr RestoreFunction()
        => MiniDetourLoader.Hook_RestoreFunction(Handle);

    public IntPtr GetHookFunction()
        => MiniDetourLoader.Hook_GetHookFunction(Handle);

    public IntPtr GetOriginalFunction()
        => MiniDetourLoader.Hook_GetOriginalFunction(Handle);

    public static bool ReplaceFunction<TDelegate>(IntPtr functionToReplace, TDelegate tdelegate) where TDelegate : notnull
        => ReplaceFunction(functionToReplace, Marshal.GetFunctionPointerForDelegate(tdelegate));

    public static bool ReplaceFunction(IntPtr functionToReplace, IntPtr newFunction)
        => MiniDetourLoader.Hook_ReplaceFunction(functionToReplace, newFunction);

    public void RestoreOnDestroy(bool restore)
    => MiniDetourLoader.Hook_RestoreOnDestroy(Handle, restore);

    ~Hook() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool _)
    {
        if (_disposed)
            return;
        MiniDetourLoader.Hook_Free(Handle);
        _disposed = true;
    }
}