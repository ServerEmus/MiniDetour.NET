namespace MiniDetour;

// TODO: Disposable!
public class Hook 
{
    IntPtr handle { get; } = HookNative.Alloc();

    public bool CanHook(IntPtr function_to_hook)
        => HookNative.CanHook(handle, function_to_hook);

    public IntPtr HookFunction(IntPtr function_to_hook, System.Delegate new_function)
        => HookFunction(function_to_hook, Marshal.GetFunctionPointerForDelegate(_delegate));

    public IntPtr HookFunction(IntPtr function_to_hook, IntPtr new_function)
        => HookNative.HookFunction(handle, function_to_hook, new_function);
    
    public IntPtr RestoreFunction()
        => HookNative.RestoreFunction(handle);

    public IntPtr GetHookFunction()
        => HookNative.GetHookFunction(handle);

    public IntPtr GetOriginalFunction()
        => HookNative.GetOriginalFunction(handle);

    public static bool ReplaceFunction(IntPtr function_to_replace, IntPtr new_function)
        => HookFunction(function_to_replace, Marshal.GetFunctionPointerForDelegate(_delegate));

    public static bool ReplaceFunction(IntPtr function_to_replace, IntPtr new_function)
        => HookNative.ReplaceFunction(function_to_replace, new_function);

    ~Hook()
    {
        if (handle == IntPtr.Zero)
            return;
        HookNative.Free(handle);
        handle = IntPtr.Zero;
    }
}