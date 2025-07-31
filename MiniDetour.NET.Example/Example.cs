using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using MiniDetour;

public class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool CanHookDelegate(IntPtr handle, IntPtr functionToHook);

    public static void Main(string[] _)
    {
        IntPtr detour = NativeLibrary.Load("mini_detour");
        IntPtr canHookPtr = NativeLibrary.GetExport(detour, "MiniDetourHookTCanHook");
        Hook testHook = new();
        IntPtr hookedFuncPtr = testHook.HookFunction(canHookPtr, new CanHookDelegate(CanHook));
        testHook.CanHook(IntPtr.Zero);
    }

    static bool CanHook(IntPtr handle, IntPtr functionToHook)
    {
        Console.WrieLine("yeys");
        return true;
    }
}